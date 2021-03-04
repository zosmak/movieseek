using Movieseek.Models;
using Movieseek.Services;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movieseek.Pages.Main
{
    public partial class Movieseek : Form
    {
        #region constructor
        public OMDBService _OMDBService;
        public APIService _APIService;

        public Movieseek()
        {
            _OMDBService = new OMDBService();
            _APIService = new APIService();
            InitializeComponent();
            InitializeOMDBDataSource();
            UpdateMyListDataSource();
        }
        #endregion

        private async void buttonBackPage_Click(object sender, EventArgs e)
        {
            int currentPageValue = short.Parse(labelPage.Text);
            if (currentPageValue > 1)
            {
                currentPageValue += -1;
                labelPage.Text = currentPageValue.ToString();
                await UpdateOMDBDataSource();
            }
        }

        private async void buttonNextPage_Click(object sender, EventArgs e)
        {
            int rowsPerPage = 10;
            int currentPageValue = short.Parse(labelPage.Text);
            int total = short.Parse(labelResultsValue.Text);

            // validate if next page exists
            if (currentPageValue * rowsPerPage < total)
            {
                int pageValue = short.Parse(labelPage.Text) + 1;
                labelPage.Text = pageValue.ToString();
                await UpdateOMDBDataSource();
            }
        }

        private void InitializeOMDBDataSource()
        {
            // configure columns
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Year");
            dt.Columns.Add("Type");
            gridOMDB.DataSource = dt;
            gridOMDB.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UpdateMyListDataSource()
        {
            // configure columns
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Year");
            dt.Columns.Add("Type");

            // read the movies from file
            foreach (var item in APIService.movies)
            {
                dt.Rows.Add(item.ID, item.Title, item.Year, item.Type);
            }

            gridMyList.DataSource = dt;
            gridMyList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async Task UpdateOMDBDataSource()
        {
            try
            {
                int page = short.Parse(labelPage.Text);
                OMDBMoviesResult result = await _OMDBService.GetMoviesList(page, textBoxSearch.Text);

                // update form values with result
                textBoxRequestValue.Text = "Request was successfull";
                labelResultsValue.Text = result.totalResults ?? "0";

                // configure columns
                DataTable dt = new DataTable();
                dt.Columns.Add("Title");
                dt.Columns.Add("Year");
                dt.Columns.Add("Type");

                if (result.Search != null)
                {
                    foreach (var item in result.Search)
                    {
                        dt.Rows.Add(item.Title, item.Year, item.Type);
                    }
                }
                gridOMDB.DataSource = dt;
            }
            catch (Exception e)
            {
                textBoxRequestValue.Text = e.Message;
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            // reset the page number
            labelPage.Text = "1";
            if (IsSearchTextValid())
                await UpdateOMDBDataSource();
        }

        private async void gridOMDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedMovie = gridOMDB.Rows[e.RowIndex];
            string title = selectedMovie.Cells[0].FormattedValue.ToString();
            string year = selectedMovie.Cells[1].FormattedValue.ToString();
            string type = selectedMovie.Cells[2].FormattedValue.ToString();

            // save new movie
            var savedMovie = await _APIService.AddNewMovie(title, year, type);

            // update local file
            APIService.movies.Add(savedMovie);

            // update data table
            UpdateMyListDataSource();
            tabControl.SelectedTab = tabMyList;
        }

        private async void gridMyList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var selectedIndex = e.Row.Index;
            var selectedMovie = gridMyList.Rows[e.Row.Index];
            string id = selectedMovie.Cells[0].FormattedValue.ToString();
            await _APIService.RemoveMovie(id);

            // update local movie list
            APIService.movies.RemoveAt(selectedIndex);
        }

        private void buttonLoadMyList_Click(object sender, EventArgs e)
        {
            UpdateMyListDataSource();
        }

        private bool IsSearchTextValid()
        {
            // validate if its a valid search
            string regexValidation = "^([a-zA-Z0-9]+( [a-zA-Z0-9_]+)*){3,}$";

            if (Regex.IsMatch(textBoxSearch.Text, regexValidation))
                return true;

            textBoxRequestValue.Text = "Invalid search text";
            return false;
        }
    }
}

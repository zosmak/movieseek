using Movieseek.Models;
using Movieseek.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movieseek
{
    public partial class Movieseek : Form
    {
        #region constructor
        public LocalFileService _localFileService;
        public OMDBService _OMDBService;

        public Movieseek()
        {
            _localFileService = new LocalFileService();
            _OMDBService = new OMDBService();
            InitializeComponent();
            InitializeOMDBDataSource();
            UpdateMyListDataSource();
        }
        #endregion

        private void OnLoadForm(object sender, EventArgs e)
        {
        }

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
            dt.Columns.Add("Title");
            dt.Columns.Add("Year");
            dt.Columns.Add("Type");

            // read the movies from file
            foreach (var item in _localFileService.localMovies)
            {
                dt.Rows.Add(item.Title, item.Year, item.Type);
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

        private void gridOMDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedMovie = gridOMDB.Rows[e.RowIndex];
            string title = selectedMovie.Cells[0].FormattedValue.ToString();
            string year = selectedMovie.Cells[1].FormattedValue.ToString();
            string type = selectedMovie.Cells[2].FormattedValue.ToString();

            Movie newMovie = new Movie()
            {
                Title = title,
                Year = year,
                Type = type
            };

            // update local file
            _localFileService.localMovies.Add(newMovie);
            _localFileService.SaveMoviesFromFile(_localFileService.localMovies);

            // update data table
            UpdateMyListDataSource();
            tabControl.SelectedTab = tabMyList;
        }

        private void gridMyList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // update local file
            _localFileService.localMovies.RemoveAt(e.Row.Index);
            _localFileService.SaveMoviesFromFile(_localFileService.localMovies);
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

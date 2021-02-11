using Movieseek.Models;

namespace Movieseek.Pages.Main
{
    partial class Movieseek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMyList = new System.Windows.Forms.TabPage();
            this.gridMyList = new System.Windows.Forms.DataGridView();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.gridOMDB = new System.Windows.Forms.DataGridView();
            this.textBoxRequestValue = new System.Windows.Forms.TextBox();
            this.labelResultsValue = new System.Windows.Forms.Label();
            this.labelResults = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.RequestStatus = new System.Windows.Forms.Label();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonBackPage = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabMyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMyList)).BeginInit();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOMDB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMyList);
            this.tabControl.Controls.Add(this.tabSearch);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(803, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabMyList
            // 
            this.tabMyList.Controls.Add(this.gridMyList);
            this.tabMyList.Location = new System.Drawing.Point(4, 22);
            this.tabMyList.Name = "tabMyList";
            this.tabMyList.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyList.Size = new System.Drawing.Size(795, 424);
            this.tabMyList.TabIndex = 0;
            this.tabMyList.Text = "My List";
            this.tabMyList.UseVisualStyleBackColor = true;
            // 
            // gridMyList
            // 
            this.gridMyList.AllowUserToAddRows = false;
            this.gridMyList.AllowUserToResizeColumns = false;
            this.gridMyList.AllowUserToResizeRows = false;
            this.gridMyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMyList.Location = new System.Drawing.Point(8, 8);
            this.gridMyList.Name = "gridMyList";
            this.gridMyList.Size = new System.Drawing.Size(776, 408);
            this.gridMyList.TabIndex = 0;
            this.gridMyList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridMyList_UserDeletingRow);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.gridOMDB);
            this.tabSearch.Controls.Add(this.textBoxRequestValue);
            this.tabSearch.Controls.Add(this.labelResultsValue);
            this.tabSearch.Controls.Add(this.labelResults);
            this.tabSearch.Controls.Add(this.buttonSearch);
            this.tabSearch.Controls.Add(this.RequestStatus);
            this.tabSearch.Controls.Add(this.labelPage);
            this.tabSearch.Controls.Add(this.buttonNextPage);
            this.tabSearch.Controls.Add(this.buttonBackPage);
            this.tabSearch.Controls.Add(this.labelSearch);
            this.tabSearch.Controls.Add(this.textBoxSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(795, 424);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // gridOMDB
            // 
            this.gridOMDB.AllowUserToAddRows = false;
            this.gridOMDB.AllowUserToDeleteRows = false;
            this.gridOMDB.AllowUserToResizeColumns = false;
            this.gridOMDB.AllowUserToResizeRows = false;
            this.gridOMDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOMDB.Location = new System.Drawing.Point(16, 132);
            this.gridOMDB.MultiSelect = false;
            this.gridOMDB.Name = "gridOMDB";
            this.gridOMDB.ReadOnly = true;
            this.gridOMDB.Size = new System.Drawing.Size(761, 263);
            this.gridOMDB.TabIndex = 13;
            this.gridOMDB.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOMDB_CellDoubleClick);
            // 
            // textBoxRequestValue
            // 
            this.textBoxRequestValue.Location = new System.Drawing.Point(16, 83);
            this.textBoxRequestValue.Multiline = true;
            this.textBoxRequestValue.Name = "textBoxRequestValue";
            this.textBoxRequestValue.ReadOnly = true;
            this.textBoxRequestValue.Size = new System.Drawing.Size(761, 43);
            this.textBoxRequestValue.TabIndex = 12;
            // 
            // labelResultsValue
            // 
            this.labelResultsValue.AutoSize = true;
            this.labelResultsValue.Location = new System.Drawing.Point(64, 406);
            this.labelResultsValue.Name = "labelResultsValue";
            this.labelResultsValue.Size = new System.Drawing.Size(0, 13);
            this.labelResultsValue.TabIndex = 11;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(13, 406);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(45, 13);
            this.labelResults.TabIndex = 10;
            this.labelResults.Text = "Results:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(702, 29);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 28);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // RequestStatus
            // 
            this.RequestStatus.AutoSize = true;
            this.RequestStatus.Location = new System.Drawing.Point(13, 67);
            this.RequestStatus.Name = "RequestStatus";
            this.RequestStatus.Size = new System.Drawing.Size(80, 13);
            this.RequestStatus.TabIndex = 8;
            this.RequestStatus.Text = "Request Status";
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(350, 406);
            this.labelPage.MaximumSize = new System.Drawing.Size(80, 13);
            this.labelPage.MinimumSize = new System.Drawing.Size(80, 13);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(80, 13);
            this.labelPage.TabIndex = 4;
            this.labelPage.Text = "1";
            this.labelPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(446, 401);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(75, 23);
            this.buttonNextPage.TabIndex = 3;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonBackPage
            // 
            this.buttonBackPage.Location = new System.Drawing.Point(251, 401);
            this.buttonBackPage.Name = "buttonBackPage";
            this.buttonBackPage.Size = new System.Drawing.Size(75, 23);
            this.buttonBackPage.TabIndex = 2;
            this.buttonBackPage.Text = "<";
            this.buttonBackPage.UseVisualStyleBackColor = true;
            this.buttonBackPage.Click += new System.EventHandler(this.buttonBackPage_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(13, 13);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(100, 13);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Movie / Serie name";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(16, 30);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(678, 26);
            this.textBoxSearch.TabIndex = 0;
            // 
            // Movieseek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Name = "Movieseek";
            this.RightToLeftLayout = true;
            this.Text = "Movieseek";
            this.tabControl.ResumeLayout(false);
            this.tabMyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMyList)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOMDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabMyList;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.DataGridView gridMyList;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonBackPage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label RequestStatus;
        private System.Windows.Forms.Label labelResultsValue;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.TextBox textBoxRequestValue;
        private System.Windows.Forms.DataGridView gridOMDB;
    }
}


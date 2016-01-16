using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    /*
      * ArticleTabPage TabPage .
      * Main purpose - Implements customize TabPage for articles.
      */
    public class ArticleTabPage:TabPage
    {
        private List<Article> _articleList;
        private Dictionary<string, bool> _journalToView;
        private DataGridView dataGridView;

        //Initilize the TabPage with it components, fill the table with articles details and set the TabPage title.
        public ArticleTabPage(string tabName, List<Article> list)
        {
            this.MouseEnter += (s, e) => this.Focus();
            this.Text = tabName;
            _articleList = list;
            _journalToView = new Dictionary<string, bool>();
            foreach (Article a in _articleList)
            {
                if (!_journalToView.ContainsKey(a.Journal))
                    _journalToView.Add(a.Journal, true);
            }
            dataGridView = new DataGridView();
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            

            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Columns[0].HeaderText = "Title";
            dataGridView.Columns[1].HeaderText = "Journal";
            dataGridView.Columns[2].HeaderText = "Year";
            dataGridView.Columns[3].HeaderText = "Author";


            dataGridView.CellContentClick += dataGridView1_CellClick;

            fillTable();

            dataGridView.AllowUserToAddRows = false;

            this.Controls.Add(dataGridView);
        }

        //Occurs when article title clicked, open the article source in default browser.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start("http://www.ncbi.nlm.nih.gov/pubmed/" + _articleList.ElementAt(e.RowIndex).PubMedID);
            }
                
        }
        
        //Fill the table with articles details.
        public void fillTable()
        {
            dataGridView.Rows.Clear();
            
            foreach(Article a in _articleList)
            {
                if(_journalToView[a.Journal])
                {
                    DataGridViewRow tempRow = new DataGridViewRow();
                    tempRow.CreateCells(dataGridView);
                    tempRow.Cells[0] = new DataGridViewLinkCell();
                    tempRow.Cells[0].Value = a.Title;
                    tempRow.Cells[1].Value = a.Journal;
                    tempRow.Cells[2].Value = a.Year;
                    tempRow.Cells[3].Value = a.Author;

                    dataGridView.Rows.Add(tempRow);
                }
            }
            dataGridView.Refresh();
        }

        //Open the FilterArticlesForm for current TabPage.
        internal void filterTable()
        {
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if((_journalToView[row.Cells[1].Value.ToString()]))
                    row.Visible=true;
                else
                    row.Visible=false;
            }
        }

        public Dictionary<string, bool> getJournalToView()
        {
            return _journalToView;
        }
    }
}

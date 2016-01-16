using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    /*
    * Article UserControl.
    * Main purpose - Get and show the Articles for important Mutation.
    * Part of MainForm. 
    */
    public partial class ArticlesUserControl : UserControl
    {
        private CosmicWebService _cosmicWebService;
        private List<Mutation> _mutationList;
        private MainForm _mainForm;
        
        //Initialize the UserControl.
        public ArticlesUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _cosmicWebService = new CosmicWebService();
        }

        //initialize with mutation list
        public void initArticleUC(List<Mutation> mutationList)
        {
            _mutationList = mutationList;
            getArticlesButton.Enabled = true;
        }

        //Occurs when get articles clicked, start the BackgroundWorker.
        private void getArticlesButton_Click(object sender, EventArgs e)
        {
            _articlesBackgroundWorker.RunWorkerAsync();
        }

        //Connect to COSMIC, preform login and get the Articles for each mutatin that has cosmic details.
        private void _articlesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                _articleTabControl.TabPages.Clear();
            });
            _articlesBackgroundWorker.ReportProgress(0);
            bool logedIn = _cosmicWebService.loginToCosmic(Properties.Settings.Default.CosmicEmail, Properties.Settings.Default.CosmicPassword, 5);

            if (_cosmicWebService.isLogedIn())
            {
                _articlesBackgroundWorker.ReportProgress(1);
                foreach (Mutation m in _mutationList)
                {
                    if (!m.CosmicName.Equals("-----"))
                    {
                        foreach(int i in m.getCosmicNums())
                        {
                            string tsvStringFromCosmic = _cosmicWebService.getTsvFromCosmic(i);
                            string tabName = m.GeneName + "  " + m.PMutationName + "  COSM"+i;
                            ArticleTabPage p = new ArticleTabPage(tabName, TSVHandler.getArticleListFromTsv(tsvStringFromCosmic));
                            BeginInvoke((MethodInvoker)delegate
                            {
                                _articleTabControl.TabPages.Add(p);
                            });
                        }
                    }
                }
            }
            else
            {
                _articlesBackgroundWorker.ReportProgress(2);
            }
        }
        //Use progressChanged to change the status text
        private void _articlesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    _cosmicStatusText.Text = "Trying To Log In.....";
                    _cosmicStatusText.ForeColor = Color.Blue;
                    break;
                case 1:
                    _cosmicStatusText.Text = "Successful";
                    _cosmicStatusText.ForeColor = Color.Green;
                    break;
                case 2:
                    _cosmicStatusText.Text = "Failed to log in. Check cosmic email and password in settings and/or check internet connection";
                    _cosmicStatusText.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
        }
        private void _articlesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_articleTabControl.TabCount != 0)
                filterButton.Enabled = true;
        }

        //Open the filter Article Form for selected TabPage.
        private void filterButton_Click(object sender, EventArgs e)
        {
            MainForm parentForm = (this.Parent as MainForm);
            parentForm.Enabled = false;
            FilterArticlesForm filterArticleForm = new FilterArticlesForm(parentForm, ((ArticleTabPage)_articleTabControl.SelectedTab));
            filterArticleForm.Show();
        }

        //Clear the Artile User Control.
        public void clearAll()
        {
            _articleTabControl.TabPages.Clear();
            filterButton.Enabled = false;
            getArticlesButton.Enabled = false;
            _cosmicStatusText.Text = "Disconnected";
            _cosmicStatusText.ForeColor = Color.Red;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace FinalProject.UI
{
    /*
    * Info Analyze UserControl.
    * Main purpose - analyze data that recived from csv files.
    * Second purpose - show show the analized data in MutatinUserControl.
    * Part of MainForm. 
    */
    public partial class InfoAnalyzeUserControl : UserControl
    {
        enum XlsMinPlace { Chrom = 0, Position, GeneName, Ref, Var, NumOfShows };

        private List<string[]> _csv1Mutations = null;
        private List<string[]> _csv2Mutations = null;

        private string _xls1Path = null;
        private string _xls2Path = null;
        private List<Mutation> _mutationList = null;
        List<string[]> _mutationsDetailsList = null;
        private MainForm _mainForm;
        private bool hadError;

        public InfoAnalyzeUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        //Occurs when csv1 or csv2 load button clicked, 
        private void LoadCsvButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string tempPath = null, fileName; ;
            TextBox tempTextBox = null;
            string[] tempStringArray;
            if (clickedButton == null) // just to be on the safe side
                return;

            if (clickedButton == Xls1Button)
            {
                _xls1Path = getFilePath();
                tempPath = _xls1Path;
                tempTextBox = xls1TextBox;
            }
            else if (clickedButton == Xls2Button)
            {
                _xls2Path = getFilePath();
                tempPath = _xls2Path;
                tempTextBox = xls2TextBox;
            }
            if (tempPath != null)
            {
                tempStringArray = tempPath.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1];

                if (_xls2Path == _xls1Path)
                {
                    GeneralMethods.showErrorMessageBox("Same File Selected.");
                }
                else
                {
                    tempTextBox.Text = fileName;
                    if (clickedButton == Xls1Button)
                        _csv1Mutations=CSVHandler.getMutationsImportantDetails(tempPath);
                   else if (clickedButton == Xls2Button)
                        _csv2Mutations=CSVHandler.getMutationsImportantDetails(tempPath);

                }
            }
        }

        //Show Open File Dialog for file selecting.
        private string getFilePath()
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return _openFileDialog.FileName;
            }
            return null;
        }

        //Gets the selected files, analyze and show the results.
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            Boolean startAnalyze = false;
            /*
            if (!isConnectedToWeb())
            {
                MessageBox.Show("Internet Connections seems to be down. You will only have access to existing Patients and tests",
    "Connectivity Warning",
    MessageBoxButtons.OKCancel,
    MessageBoxIcon.Warning
    );
            }
             * */
            //if 2 files loaded.
            if (_xls1Path == null && _xls2Path == null)
            {
                GeneralMethods.showErrorMessageBox("No files selected.");
            }
            //If only 1 file loaded.
            else if (_xls1Path == null ^ _xls2Path == null)
            {
                if (MessageBox.Show("Only one file selected, Continue?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    startAnalyze = true;
                }
            }
            //If no file loaded
            else
            {
                startAnalyze = true;
            }
            if (startAnalyze)
            {
                _mutationsDetailsList = intersectionLists(_csv1Mutations, _csv2Mutations);
                analyzeButton.Enabled = false;
                _mainForm.ArticlesUC.clearAll();
                _analyzeBackgroundWorker.RunWorkerAsync();
            }
        }

        //Analyze Background Worker start. use Backgroun Worker to keep UI active while analizing.
        private void analyzeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            hadError = false;
            _mutationList = new List<Mutation>();
            int i = 1;
            foreach (string[] s in _mutationsDetailsList)
            {
                string chrom = s[(int)XlsMinPlace.Chrom];
                int position = Convert.ToInt32(s[(int)XlsMinPlace.Position]);
                string geneName = s[(int)XlsMinPlace.GeneName];
                char refNuc = s[(int)XlsMinPlace.Ref][0];
                char varNuc = s[(int)XlsMinPlace.Var][0];
                try
                {
                    Mutation tempMutation = MainBL.getMutationByDetails(chrom, position, refNuc, varNuc);
                    if (tempMutation == null)
                    {
                        tempMutation = new Mutation(chrom, position, geneName, refNuc, varNuc);
                    }
                    tempMutation.NumOfShows = Convert.ToInt16(s[(int)XlsMinPlace.NumOfShows]);
                    _mutationList.Add(tempMutation);
                    //_analyzeBackgroundWorker.ReportProgress(_mainForm.progressBarCounter);
                    _analyzeBackgroundWorker.ReportProgress(i);
                    i++;
                }
                catch (Exception)
                {
                    hadError = true;
                    GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");
                    break;
                }
            }
        }

        //added

       
        //Report analyze progress.
        private void analyzeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBarLabel.Text = "Status: Analyzing Line: " + (e.ProgressPercentage) + " of " + _mutationsDetailsList.Count;
            this.progressBarLabel.Text = "Status: Analyzing, this may take several minutes";
            //this.progressBarLabel.Text = "Status: Analyzing Information,";
            progressBar1.Value = (100 / _mutationsDetailsList.Count) * e.ProgressPercentage;
        }

        //Finish the analyze, sets the mutation table and clear the rest.
        private void analyzeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _mainForm.MutationList = _mutationList;
            _mainForm.MutationUC.clearAll();
            _mainForm.MutationUC.initTable(_mutationList);
            _mainForm.PatientUC.clearAll();
            _mainForm.PatientUC.initPatientUC(_mutationList,generateTestName());
            if (hadError)
            {
                progressBar1.Value = 0;
                progressBarLabel.Text = "Status: ";
            }
            else
            {
                _mainForm.ArticlesUC.initArticleUC(_mutationList);
                progressBar1.Value = 100;
                progressBar1.ForeColor = System.Drawing.Color.LightBlue;//"#00CED1";
                progressBarLabel.Text = "Analyzation of Lines: " + _mutationsDetailsList.Count +" of " + _mutationsDetailsList.Count + ", Completed!";
                //progressBarLabel.Text += "Analyzation of Lines:" + _mutationsDetailsList.Count + " of " + _mutationsDetailsList.Count + ", Complete!";
                MessageBox.Show("Analyzation Completed with no Errors");
            }
            analyzeButton.Enabled = true;
        }
        //generate the test name from csv file names.
        private string generateTestName()
        {
            string testName = "";
            string[] tempStringArray;
            string fileName;
            if(_xls1Path!=null)
            {
                tempStringArray = _xls1Path.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1].Split('.')[0];
                testName += fileName;
                if (_xls2Path != null)
                    testName += "_";
            }
            if (_xls2Path != null)
            {
                tempStringArray = _xls2Path.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1].Split('.')[0];
                testName +=  fileName;
            }
            return testName;
        }

        //inersect 2 mutation list from csvHandlers,create 1 list and sets the numOfShows in each mutation.
        private List<string[]> intersectionLists(List<string[]> csvMut1, List<string[]> csvMut2)
        {
            bool twoFiles = true;
            List<string[]> toReturn = new List<string[]>();
            if (csvMut1 == null ^ csvMut2 == null)
            {
                twoFiles = false;
            }
            if (csvMut1 != null)
                foreach (string[] s in csvMut1)
                {
                    bool found = false;
                    foreach (string[] d in toReturn)
                    {
                        if (d[0].Equals(s[0]) && d[1].Equals(s[1]) && d[2].Equals(s[2]) && d[3].Equals(s[3]) && d[4].Equals(s[4]))
                        {
                            found = true;
                        }
                    }
                    if (!found)
                        toReturn.Add(s);
                }
            if (csvMut2 != null)
                foreach (string[] s in csvMut2)
                {
                    bool found = false;
                    foreach (string[] d in toReturn)
                    {
                        if (d[0].Equals(s[0]) && d[1].Equals(s[1]) && d[2].Equals(s[2]) && d[3].Equals(s[3]) && d[4].Equals(s[4]))
                        {
                            found = true;
                            if (twoFiles)
                                d[5] = "2";
                        }
                    }
                    if (!found)
                        toReturn.Add(s);
                }
            return toReturn;
        }
       
        //Clear all analyze data
        public void clearAll()
        {
            _csv1Mutations = null;
            _csv2Mutations = null;
            _xls1Path = null;
            _xls2Path = null;
            _mutationList = null;
            _mutationsDetailsList = null;
            xls1TextBox.Text = "";
            xls2TextBox.Text = "";
            progressBarLabel.Text = "Status:";
            progressBar1.Value = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBarLabel_Click(object sender, EventArgs e)
        {

        }

        private void xls1TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        public bool isConnectedToWeb()
        {
            
            try
            {
                string URL = "https://www.google.com";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
         * */
    }
}

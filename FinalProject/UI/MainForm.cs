using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinalProject.FileHendlers;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;



namespace FinalProject.UI
{
    /*
     * Main Form .
     * Main purpose - Implement the main Interface of the software.
     */
    public partial class MainForm : Form
    {
        private InfoAnalyzeUserControl infoAnalyzeUserControl;
        private ArticlesUserControl articlesUserControl;
        private PatientUserControl patientUserControl;
        private MutationUserControl mutationUserControl;

        private List<Mutation> _mutationList;
        private Patient _currPatient;
        public int progressBarCounter;


        //Initialize the MainForm with all User Controls, positioning them on the form
        public MainForm()
        {
            InitializeComponent();
            infoAnalyzeUserControl = new InfoAnalyzeUserControl(this);
            articlesUserControl = new ArticlesUserControl(this);
            patientUserControl = new PatientUserControl(this);
            mutationUserControl = new MutationUserControl(this);

            this.Controls.Add(infoAnalyzeUserControl);
            this.Controls.Add(articlesUserControl);
            this.Controls.Add(patientUserControl);
            this.Controls.Add(mutationUserControl);

            mutationUserControl.Left = 5;
            infoAnalyzeUserControl.Left = 5;
            articlesUserControl.Left = 5;
            patientUserControl.Left = 5;

            infoAnalyzeUserControl.Top = 20;
            articlesUserControl.Top = 295;//280
            patientUserControl.Top = 455;//465
            mutationUserControl.Top = 80;
        }
        
        //Open the settings form,disable main form.
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
        }

        //Clear all data from MainForm.
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBarCounter = 0;
            _mutationList = null;
            _currPatient = null;
            articlesUserControl.clearAll();
            infoAnalyzeUserControl.clearAll();
            patientUserControl.clearAll();
            mutationUserControl.clearAll();
        }

        //Exit the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Handle the exporting of data to XLSX and DOCX files
        private void ExportMenuItem_Click(object sender, EventArgs e)
        {
            string path = Properties.Settings.Default.ExportSavePath;
            ToolStripMenuItem clicked = sender as ToolStripMenuItem;
            string clickedName = clicked.Name;
            if (path.Equals(""))
                GeneralMethods.showErrorMessageBox("Error, Please select directory to save in settings");
            else
            {
                //If Export to DOCX selected.
                if (clickedName.Equals("docxWithDetailsMenuItem") || clicked.Name.Equals("docxWithoutDetailsMenuItem"))
                {
                    if (_currPatient == null || _mutationList == null)
                    {
                        MessageBox.Show("No Details To Export");
                    }
                    else
                    {
                        bool includeDetails = false;
                        if (clickedName.Equals("docxWithDetailsMenuItem"))
                        {
                            includeDetails = true;
                        }
                        try
                        {
                            DOCExportHandler.saveDOC(_currPatient, _mutationList, includeDetails);
                            MessageBox.Show("File Saved Successfully To: " + Properties.Settings.Default.ExportSavePath);
                        }
                        catch (IOException)
                        {
                            GeneralMethods.showErrorMessageBox("Error, Please select directory to save in settings");
                        }
                    }
                }
                //If Export to XLSX selected.
                else if (clickedName.Equals("xlsxMutationMenuItem"))
                {
                    if (_mutationList == null)
                    {
                        MessageBox.Show("No Details To Export");
                    }
                    else
                    {
                        try
                        {
                            XLSExportHandler.saveXLS(patientUserControl.TestName, _mutationList);
                            MessageBox.Show("File Saved Successfully To: " + Properties.Settings.Default.ExportSavePath);
                        }
                        catch (IOException)
                        {
                            GeneralMethods.showErrorMessageBox("Error, Please select directory to save in settings");
                        }
                    }
                }
            }
        }
        //Show the about message.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                      AutoAnalyze v2.0\n\n" +
                            "                              2016 \n\n" +
                            "                          Created By \n\n" +
                            "                           Etye Myer \n\n" +     
                            "                     Moti Monsonego\n\n" +
                            "        Jerusalem College Of Engineering\n\n" +
                            "         Email: etyemyer@gmail.com\n\n" +
                            "         Email: motimonso@gmail.com", "About");

        }

        //add handler when clicking on the rs# link to browser will open


        public ArticlesUserControl ArticlesUC{get{return articlesUserControl;}}
        public PatientUserControl PatientUC{get{return patientUserControl;}}
        public MutationUserControl MutationUC{get{return mutationUserControl;}}
        public Patient CurrPatient{
            get{return _currPatient;}
            set{_currPatient = value;}
        }
        public List<Mutation> MutationList
        {
            get{return _mutationList;}
            set{_mutationList = value;}
        }

        private void xMLWithGermlineDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currPatient == null || _mutationList == null)
            {
                MessageBox.Show("No Details To Export");
            }
            DataTable dt = GetDataTableFromDGV(mutationUserControl.getDGV());
            XLSExportHandler handler = new XLSExportHandler();
            DataSet dS = new DataSet();
            dS.Tables.Add(dt);
            handler.saveXLS(patientUserControl.TestName, dS);
            MessageBox.Show("Export Completed");

        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        public InfoAnalyzeUserControl getInfoAnalyzerfromMainForm(){
            return this.infoAnalyzeUserControl;
        }
    }

}

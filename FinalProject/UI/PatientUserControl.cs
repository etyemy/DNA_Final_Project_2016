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
    * Patient UserControl.
    * Main purpose - manage patient details in MainForm.
    * Second purpose - show patient details in HistoryForm.
    * Part of MainForm. 
    */
    public partial class PatientUserControl : UserControl
    {
        MainForm _mainForm;
        List<Mutation> _mutationList = null;
        Patient _patient;
        string testNmae;

        //Initialize the empty UserControl.
        public PatientUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        //Initialize UserControl with patient details.
        public PatientUserControl(Patient p)
        {
            InitializeComponent();
            loadPatientDetails(p, false);
            PatientButtonPanel.Visible = false;
        }

        //When search clicked, get the id from the idTextBox, search if patient with that id exist.
        //If exist creates a new SerchResultForm and show the results, If not, Shows appropriate message
        private void _searchPatientButton_Click(object sender, EventArgs e)
        {
            string patientId = idToLoadTextBox.Text;
            try
            {
                List<Patient> patientList = MainBL.getPatientListById(patientId);
                if (patientList != null)
                {
                    _mainForm.Enabled = false;
                    SearchResultForm srf = new SearchResultForm(patientList, _mainForm);
                    srf.Show();
                }
                else
                    GeneralMethods.showErrorMessageBox("Wrong ID, No patient found.");
            }
            catch (Exception)
            {
                GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");
            }
        }

        //When save clicked, gets all patient details from textBoxs and save patient to database.
        private void _savePatientButton_Click(object sender, EventArgs e)
        {
            string testName = _testNameTextBox.Text;
            string id = _idTextBox.Text;
            string fName = _firstNameTextBox.Text;
            string lName = _lastNameTextBox.Text;
            string pathoNum = _pathologicalNoTextBox.Text;
            string runNum = _runNoTextBox.Text;
            string tumourSite = _tumourSiteTextBox.Text;
            string diseaseLevel = _diseaseLevelTextBox.Text;
            string prevTreatment = _previousTreatmentTextBox.Text;
            string currTreatment = _currentTreatmentTextBox.Text;
            string background = _backgroundTextBox.Text;
            string conclusion = _conclusionsTextBox1.Text;
            //validate textboxs text
            if (!(id.Equals("") || fName.Equals("") || lName.Equals("") || pathoNum.Equals("") || runNum.Equals("") || tumourSite.Equals("")))
            {
                //check if patient with same test name allready exist.
                Patient p = new Patient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                try
                {
                    //If Exist, show message for overwriting.
                    if (MainBL.patientExistByTestName(testNmae))
                    {
                        if (MessageBox.Show("TEST NAME allready exist, Overwrite?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MainBL.updatePatient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                            _mainForm.CurrPatient = p;
                            _mutationList = MainBL.getMutationListByTestName(p.TestName);
                            _mainForm.MutationList = _mutationList;
                            MessageBox.Show("Patient saved successfully");
                        }
                    }
                    //If not Exist, insert new patient to database.
                    else
                    {
                        MainBL.addPatient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, prevTreatment, currTreatment, background, conclusion);
                        _mainForm.CurrPatient = p;
                        _mainForm.MutationList = _mutationList;
                        foreach (Mutation m in _mutationList)
                        {
                            MainBL.addMatch(testName, m.MutId);
                        }
                        MessageBox.Show("Patient saved successfully");
                    }
                }
                catch (Exception)
                {
                    GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");
                }
            }
            else
            {
                ToolTip errorToolTip = new ToolTip();
                errorToolTip.SetToolTip(_savePatientButton, "digit only");
                errorToolTip.Show("Please Fill All Details", _savePatientButton, 800);
            }
            colorTextBoxs();
        }
        //Check all textboxs and color the ones that failed validation.
        private void colorTextBoxs()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(_idTextBox);
            textBoxList.Add(_firstNameTextBox);
            textBoxList.Add(_lastNameTextBox);
            textBoxList.Add(_pathologicalNoTextBox);
            textBoxList.Add(_runNoTextBox);
            textBoxList.Add(_tumourSiteTextBox);
            List<Label> lebalList = new List<Label>();
            lebalList.Add(_idLabel);
            lebalList.Add(_firstNameLabel);
            lebalList.Add(_lastNameLabel);
            lebalList.Add(_pathologicalNoLabel);
            lebalList.Add(_runNoLabel);
            lebalList.Add(_tumourSiteLabel);

            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (textBoxList.ElementAt(i).Text.Equals(""))
                    lebalList.ElementAt(i).ForeColor = Color.Red;
                else
                    lebalList.ElementAt(i).ForeColor = Color.Black;
            }
        }
        //Sets the Patient User Control with mutation list and test name.
        public void initPatientUC(List<Mutation> mutationList, string testName)
        {
            _mutationList = mutationList;
            this.testNmae = testName;
        }

        //Clear all text box and buttons to initial state.
        public void clearAll()
        {
            _savePatientButton.Enabled = false;
            _idTextBox.Text = "";
            _idTextBox.ReadOnly = false;
            _firstNameTextBox.Text = "";
            _lastNameTextBox.Text = "";
            _pathologicalNoTextBox.Text = "";
            _runNoTextBox.Text = "";
            _tumourSiteTextBox.Text = "";
            _diseaseLevelTextBox.Text = "";
            _backgroundTextBox.Text = "";
            _previousTreatmentTextBox.Text = "";
            _currentTreatmentTextBox.Text = "";
            _testNameTextBox.Text = "";
            _conclusionsTextBox1.Text = "";
            patientDetailPanel.Visible = false;
        }

        //When new clicked, check if has tests loaded, if loaded, clear all fields and show all text boxs.
        private void newPatientButton_Click(object sender, EventArgs e)
        {
            if (_mainForm.MutationList != null)
            {
                clearAll();
                _savePatientButton.Enabled = true;
                patientDetailPanel.Visible = true;
                if (testNmae != null)
                {
                    _testNameTextBox.Text = testNmae;
                }
                _mainForm.CurrPatient = null;
            }
            else
            {
                MessageBox.Show("Please Load Test files.");
            }
        }

        //Load patient details to text boxs, fullView=true when in mainForm,fullView=false when in historyForm.
        internal void loadPatientDetails(Patient patient, bool fullView)
        {
            _savePatientButton.Enabled = true;
            patientDetailPanel.Visible = true;

            _patient = patient;
            _testNameTextBox.Text = _patient.TestName;
            _idTextBox.Text = _patient.PatientID;
            _idTextBox.ReadOnly = true;
            _firstNameTextBox.Text = _patient.FName;
            _lastNameTextBox.Text = _patient.LName;
            _pathologicalNoTextBox.Text = _patient.PathoNum;
            _runNoTextBox.Text = _patient.RunNum;
            _tumourSiteTextBox.Text = _patient.TumourSite;
            _diseaseLevelTextBox.Text = _patient.DiseaseLevel;
            _backgroundTextBox.Text = _patient.Background;
            _previousTreatmentTextBox.Text = _patient.PrevTreatment;
            _currentTreatmentTextBox.Text = _patient.CurrTreatment;
            _conclusionsTextBox1.Text = _patient.Conclusion;
            patientDetailPanel.Visible = true;
            if (fullView)
                _mainForm.CurrPatient = _patient;
        }

        //Get mutation list of patient by test name, and sets the list to the MutationUserControl in MainForm
        public void loadMutationDetails(Patient p)
        {
            try
            {
                _mutationList = MainBL.getMutationListByTestName(_patient.TestName);
                _mainForm.MutationList = _mutationList;
                initPatientUC(_mutationList, _patient.TestName);
                _mainForm.MutationUC.initTable(_mutationList);
                _mainForm.ArticlesUC.initArticleUC(_mutationList);
            }
            catch (Exception)
            {
                GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");
            }
        }

        //occurs when id text boxes test changed, validates that text entered is digit only and limit length to 9.
        private void DigitTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox changedTextBox = sender as TextBox;
            string s = changedTextBox.Text;

            if ((s.Length > 0 && !Char.IsNumber(s[s.Length - 1])) || s.Length > 9)
            {
                string errorText = "Please Enter Digits Only";
                if (s.Length > 9)
                    errorText = "Maximum 9 Digits";
                s = s.Substring(0, s.Length - 1);
                ToolTip errorToolTip = new ToolTip();
                errorToolTip.SetToolTip(idToLoadTextBox, "digit only");
                errorToolTip.Show(errorText, idToLoadTextBox, 800);
                changedTextBox.Text = s;
                changedTextBox.Focus();
                changedTextBox.SelectionStart = changedTextBox.Text.Length;
            }
        }

        //occurs when patient personal details text boxes changed, limit length to 20.
        private void SmallDetailsTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox changedTextBox = sender as TextBox;
            string s = changedTextBox.Text;

            if (s.Length > 20)
            {
                string errorText = "Maximum 20 Characters";
                s = s.Substring(0, s.Length - 1);
                ToolTip errorToolTip = new ToolTip();
                errorToolTip.SetToolTip(idToLoadTextBox, "digit only");
                errorToolTip.Show(errorText, idToLoadTextBox, 800);
                changedTextBox.Text = s;
                changedTextBox.Focus();
                changedTextBox.SelectionStart = changedTextBox.Text.Length;
            }
        }
        public string TestName { get { return testNmae; } }
    }
}

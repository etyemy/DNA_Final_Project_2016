using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            relativeDataGridView.Columns[0].Width = 115;
                
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
            string tumourSite = _tumorSiteTextBox.Text;
            string diseaseLevel = _diseaseLevelTextBox.Text;
            string prevTreatment = _previousTreatmentTextBox.Text;
            string currTreatment = _currentTreatmentTextBox.Text;
            string background = _backgroundTextBox.Text;
            string conclusion = _conclusionsTextBox1.Text;
            //validate textboxs text
            if (!(id.Equals("") || fName.Equals("") || lName.Equals("")))     //removed    runNum.Equals("")    || pathoNum.Equals("")  || tumourSite.Equals("")
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
            //textBoxList.Add(_pathologicalNoTextBox);
            //textBoxList.Add(_runNoTextBox);
            //textBoxList.Add(_tumourSiteTextBox);
            List<Label> lebalList = new List<Label>();
            lebalList.Add(_idLabel);
            lebalList.Add(_firstNameLabel);
            lebalList.Add(_lastNameLabel);
            //lebalList.Add(_pathologicalNoLabel);
            //lebalList.Add(_runNoLabel);
            //lebalList.Add(_tumorSiteLabel);

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
            this._familyHistoryComboBox.Items.Clear();//
            this._relativeRelationComboBox.Items.Clear();//
            this._tumorComboBox.Items.Clear();
            _tumorComboBox.Items.Add("No");
            _tumorComboBox.Items.Add("Yes");
            _familyHistoryComboBox.Items.Add("No");//
            _familyHistoryComboBox.Items.Add("Yes");//
            _familyHistoryComboBox.Items.Add("Unknown");
            _relativeRelationComboBox.Items.Add("1st Relation - Father");
            _relativeRelationComboBox.Items.Add("1st Relation - Mother");
            _relativeRelationComboBox.Items.Add("1st Relation - Son");
            _relativeRelationComboBox.Items.Add("1st Relation - Daughter");
            _relativeRelationComboBox.Items.Add("1st Relation - Brother");
            _relativeRelationComboBox.Items.Add("1st Relation - Sister");
            _relativeRelationComboBox.Items.Add("2nd Relation - Grandfather");
            _relativeRelationComboBox.Items.Add("2nd Relation - Grandmother");
            _relativeRelationComboBox.Items.Add("2nd Relation - Aunt");
            _relativeRelationComboBox.Items.Add("2nd Relation - Uncle");
            _relativeRelationComboBox.Items.Add("2nd Relation - Cousin");
            if (!isRelativeHistoryExist())//
            {
                _familyHistoryComboBox.SelectedIndex = _familyHistoryComboBox.FindStringExact("No");

            }
            if (!doesPatientHaveTumors())
            {
                _tumorComboBox.SelectedIndex = _tumorComboBox.FindStringExact("No");

            }
            if(_idTextBox.Text!="" && _idTextBox.Text.Count()!=9){
                updateRelativeTable();
                updateTumorTable();
            }


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
            _tumorSiteTextBox.Text = "";
            _diseaseLevelTextBox.Text = "";
            _backgroundTextBox.Text = "";
            _previousTreatmentTextBox.Text = "";
            _currentTreatmentTextBox.Text = "";
            _testNameTextBox.Text = "";
            _conclusionsTextBox1.Text = "";
            patientDetailPanel.Visible = false;
            idToLoadTextBox.Text = "";
            _tumorSiteTextBox.Text = "";
            _pathologicalNoTextBox.Text = "";
            _bloodTestNumTextBox.Text = "";
            updateRelativeTable();
            updateTumorTable();


                
            
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
            _tumorSiteTextBox.Text = _patient.TumourSite;
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
            if (LocalDbDAL.patientExist(_testNameTextBox.Text))
            {
                updateRelativeTable();
                updateTumorTable();
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

        private void _relativescComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void _relativeRelationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _diseaseLevelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void patientDetailPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void testNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.relativesTableAdapter.Fill(this.relativesTable_SQL_Express.Relatives);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void _addRelativeButton_Click(object sender, EventArgs e)
        {
            if (_relativeRelationComboBox.Text == "")
            {
                _familyRelationLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if(!LocalDbDAL.patientExist(_testNameTextBox.Text)){
                 MessageBox.Show("Please save patient before adding relative");
                return;
            }
            if(!(_idTextBox.Text=="")){
                LocalDbDAL.addRelative(_relativeRelationComboBox.Text, _idTextBox.Text, _dateOfIllnessDateTimePicker.Value.Date.ToString(),_locationOfIllnessTextBox.Text,_aboutTextBox.Text);
                updateRelativeTable();
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.relativesTableAdapter.FillBy(this.relativesTable_SQL_Express.Relatives);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.relativesTableAdapter.Fill(this.relativesTable_SQL_Express.Relatives);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        
        public void updateRelativeTable()
        {
            string id = _idTextBox.Text;
            SqlConnection con = new SqlConnection(LocalDbDAL.getConnectionString());


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@patient_id", SqlDbType.NChar).Value = id;
            sqlCmd.CommandText = "SELECT * FROM Relatives WHERE patient_id=@patient_id"; 
            
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            relativeDataGridView.DataSource = dtRecord;
            if (isRelativeHistoryExist())
            {
                _familyHistoryComboBox.SelectedIndex = _familyHistoryComboBox.FindStringExact("Yes");
                relativeDataGridView.Rows[0].Selected = true;
                setRelativeFieldsByRowNum(0);
            }
            

        }
        
        public void updateTumorTable()
        {
            string id = _idTextBox.Text;
            SqlConnection con = new SqlConnection(LocalDbDAL.getConnectionString());


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@patientId", SqlDbType.NChar).Value = id;
            sqlCmd.CommandText = "SELECT * FROM Tumors WHERE patientId=@patientId";

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            tumorsDataGridView.DataSource = dtRecord;
            if (doesPatientHaveTumors())
            {
                _tumorComboBox.SelectedIndex = _tumorComboBox.FindStringExact("Yes");
                tumorsDataGridView.Rows[0].Selected = true;
                setTumorFieldsByRowNum(0);
            }


        }
        
        private bool isRelativeHistoryExist()
        {
            string id = _idTextBox.Text;
            SqlConnection con = new SqlConnection(LocalDbDAL.getConnectionString());

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@patient_id", SqlDbType.NChar).Value = id;
            sqlCmd.CommandText = "SELECT COUNT(*) FROM Relatives WHERE patient_id=@patient_id";

            con.Open();
            int count = (int)sqlCmd.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            else
                return false;
        }
        
        private bool doesPatientHaveTumors()
        {
            string id = _idTextBox.Text;
            SqlConnection con = new SqlConnection(LocalDbDAL.getConnectionString());

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@patientId", SqlDbType.NChar).Value = id;
            sqlCmd.CommandText = "SELECT COUNT(*) FROM Tumors WHERE patientId=@patientId";

            con.Open();
            int count = (int)sqlCmd.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            else
                return false;
        }
        
        private bool isTumorExist(string tumorSite,string pathNum,string bloodTestNum)
        {
            string id = _idTextBox.Text;
            SqlConnection con = new SqlConnection(LocalDbDAL.getConnectionString());

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@patientId", SqlDbType.NChar).Value = id;
            sqlCmd.Parameters.Add("@tumorSite", SqlDbType.NChar).Value = tumorSite;
            sqlCmd.Parameters.Add("@pathNum", SqlDbType.NChar).Value = pathNum;
            sqlCmd.Parameters.Add("@bloodTestNum", SqlDbType.NChar).Value = bloodTestNum;

            sqlCmd.CommandText = "SELECT COUNT(*) FROM Tumors WHERE patientId=@patientId AND tumorSite=@tumorSite AND pathNum=@pathNum AND bloodTestNum = @bloodTestNum";

            con.Open();
            int count = (int)sqlCmd.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            else
                return false;
        }
        
        private void relativeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != null)
            {
                _relativeRelationComboBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                _dateOfIllnessDateTimePicker.Text = relativeDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                _locationOfIllnessTextBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                _aboutTextBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void _familyHistoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_familyHistoryComboBox.Text == "Yes")
            {
                _familyRelationLabel.Visible = true;
                _relativeRelationComboBox.Visible = true;
                _dateOfIllnessDateTimePicker.Visible = true;
                _dateOfIllnessLabel.Visible = true;
                _locationOfIllnessLabel.Visible = true;
                _locationOfIllnessTextBox.Visible = true;
                _aboutLabel.Visible = true;
                _aboutTextBox.Visible = true;
                _addRelativeButton.Visible = true;
            }
            if ((_familyHistoryComboBox.Text == "No") || (_familyHistoryComboBox.Text == "Unknown"))
            {
                _familyRelationLabel.Visible = false;
                _relativeRelationComboBox.Visible = false;
                _dateOfIllnessDateTimePicker.Visible = false;
                _dateOfIllnessLabel.Visible = false;
                _locationOfIllnessLabel.Visible = false;
                _locationOfIllnessTextBox.Visible = false;
                _aboutLabel.Visible = false;
                _aboutTextBox.Visible = false;
                _addRelativeButton.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _familyHistoryComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (_familyHistoryComboBox.Text == "Yes")
            {
                _familyRelationLabel.Visible = true;
                _relativeRelationComboBox.Visible = true;
                _dateOfIllnessDateTimePicker.Visible = true;
                _dateOfIllnessLabel.Visible = true;
                _locationOfIllnessLabel.Visible = true;
                _locationOfIllnessTextBox.Visible = true;
                _aboutLabel.Visible = true;
                _aboutTextBox.Visible = true;
                _addRelativeButton.Visible = true;
            }
            if ((_familyHistoryComboBox.Text == "No") || (_familyHistoryComboBox.Text == "Unknown"))
            {
                _familyRelationLabel.Visible = false;
                _relativeRelationComboBox.Visible = false;
                _dateOfIllnessDateTimePicker.Visible = false;
                _dateOfIllnessLabel.Visible = false;
                _locationOfIllnessLabel.Visible = false;
                _locationOfIllnessTextBox.Visible = false;
                _aboutLabel.Visible = false;
                _aboutTextBox.Visible = false;
            }
        }

        private void _previousTreatmentLabel_Click(object sender, EventArgs e)
        {

        }

        private void _addRelativeButton_Click_1(object sender, EventArgs e)
        {
            if (_familyHistoryComboBox.Text == "No")
            {
                return;
            }
            if (_relativeRelationComboBox.Text == "")
            {
                _familyRelationLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!LocalDbDAL.patientExist(_testNameTextBox.Text))
            {
                MessageBox.Show("Please save patient before adding relative");
                return;
            }
            if (!(_idTextBox.Text == ""))
            {
                LocalDbDAL.addRelative(_relativeRelationComboBox.Text, _idTextBox.Text, _dateOfIllnessDateTimePicker.Value.Date.ToString(), _locationOfIllnessTextBox.Text, _aboutTextBox.Text);
                updateRelativeTable();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PatientButtonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void relativeDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (relativeDataGridView.CurrentCell != null)
            {
                _relativeRelationComboBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                _dateOfIllnessDateTimePicker.Text = relativeDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                _locationOfIllnessTextBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                _aboutTextBox.Text = relativeDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
                
        }

        private void _deleteRelativeButton_Click(object sender, EventArgs e)
        {
            if (relativeDataGridView.CurrentCell != null)
            {
                LocalDbDAL.deleteRelative(_relativeRelationComboBox.Text, _idTextBox.Text, _dateOfIllnessDateTimePicker.Value.Date.ToString(), _locationOfIllnessTextBox.Text, _aboutTextBox.Text);
                updateRelativeTable();
                
            }
            if (!isRelativeHistoryExist())
            {
                _familyHistoryComboBox.SelectedIndex = _familyHistoryComboBox.FindStringExact("No");

            }
        }

        private void setRelativeFieldsByRowNum(int rowNum)
        {

            _relativeRelationComboBox.Text = relativeDataGridView.Rows[rowNum].Cells[0].Value.ToString();
            _dateOfIllnessDateTimePicker.Text = relativeDataGridView.Rows[rowNum].Cells[2].Value.ToString();
            _locationOfIllnessTextBox.Text = relativeDataGridView.Rows[rowNum].Cells[3].Value.ToString();
            _aboutTextBox.Text = relativeDataGridView.Rows[rowNum].Cells[4].Value.ToString();
        }
       
        private void setTumorFieldsByRowNum(int rowNum)
        {

            _tumorSiteTextBox.Text = tumorsDataGridView.Rows[rowNum].Cells[0].Value.ToString();
            _pathologicalNoTextBox.Text = tumorsDataGridView.Rows[rowNum].Cells[1].Value.ToString();
            _bloodTestNumTextBox.Text = tumorsDataGridView.Rows[rowNum].Cells[2].Value.ToString();
        }

        private void _addTumorButton_Click(object sender, EventArgs e)
        {
            if (_tumorComboBox.Text == "No")
            {
                return;
            }
            if (!LocalDbDAL.patientExist(_testNameTextBox.Text))
            {
                MessageBox.Show("Please save patient before adding relative");
                return;
            }
            if (_pathologicalNoTextBox.Text != "" && _bloodTestNumTextBox.Text != "")
            {
                MessageBox.Show("Please enter either Pathological Number or Blood Test Number");
                return;
            }
            if (isTumorExist(_tumorSiteTextBox.Text,_pathologicalNoTextBox.Text,_bloodTestNumTextBox.Text))
            {
                MessageBox.Show("Tumor already exists");
                return;
            }

            if (!LocalDbDAL.patientExist(_testNameTextBox.Text))
            {
                MessageBox.Show("Please save patient before adding tumor");
                return;
            }
            if (!(_idTextBox.Text == ""))
            {
                LocalDbDAL.addTumor(_idTextBox.Text,_tumorSiteTextBox.Text,_pathologicalNoTextBox.Text,_bloodTestNumTextBox.Text);
                updateTumorTable();
            }
        }

        private void _deleteTumorButton_Click(object sender, EventArgs e)
        {
            if (tumorsDataGridView.CurrentCell != null)
            {
                LocalDbDAL.deleteTumor(_idTextBox.Text,_tumorSiteTextBox.Text,_pathologicalNoTextBox.Text,_bloodTestNumTextBox.Text);
                updateTumorTable();

            }
            if (!doesPatientHaveTumors())
            {
                _tumorComboBox.SelectedIndex = _tumorComboBox.FindStringExact("No");

            }
        }

        private void _tumorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tumorComboBox.Text == "Yes")
            {
                _tumorSiteLabel.Visible = true;
                _tumorSiteTextBox.Visible = true;
                pathNumLinkLabel.Visible = true;
                bloodTestNumLinkLabel.Visible = true;

            }
            else if (_tumorComboBox.Text == "No")
            {
                _tumorSiteLabel.Visible = false;
                _tumorSiteTextBox.Visible = false;
                _pathologicalNoLabel.Visible = false;
                _pathologicalNoTextBox.Visible = false;
                _bloodTestNumLabel.Visible = false;
                _bloodTestNumTextBox.Visible = false;
                pathNumLinkLabel.Visible = false;
                bloodTestNumLinkLabel.Visible = false;
            }
        }

        private void clearTumorTextBoxes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _pathologicalNoTextBox.Text = "";
            _tumorSiteTextBox.Text = "";
            _bloodTestNumTextBox.Text = "";
        }

        private void _relativesClearTextBoxesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _locationOfIllnessTextBox.Text = "";
            _aboutTextBox.Text = "";
        }

        private void tumorsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                _tumorSiteTextBox.Text = tumorsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                _pathologicalNoTextBox.Text = tumorsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                _bloodTestNumTextBox.Text = tumorsDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void pathNumLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _pathologicalNoLabel.Visible = true;
            _pathologicalNoTextBox.Visible = true;
            _bloodTestNumLabel.Visible = false;
            _bloodTestNumTextBox.Visible = false;

        }

        private void bloodTestNumLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _bloodTestNumLabel.Visible = true;
            _bloodTestNumTextBox.Visible = true;
            _pathologicalNoLabel.Visible = false;
            _pathologicalNoTextBox.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    /*
     * Search Result Form .
     * Main purpose - Shows the results for the patient search.
     */
    public partial class SearchResultForm : Form
    {
        private List<Patient> _patientList;
        private MainForm _mainForm;

        //Initialize the form with the patient list.
        public SearchResultForm(List<Patient> patientList,MainForm mainForm)
        {
            InitializeComponent();
            _patientList = patientList;
            _mainForm = mainForm;
            foreach(Patient p in patientList)
            {
                listView1.Items.Add(p.ToString());
            }
        }

        //When Load clicked, sets the selected patient to Patint User Control in MainForm and close the current form.
        //If none selected, show appropriate message.
        private void loadPatienButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                _mainForm.PatientUC.loadPatientDetails(_patientList[listView1.SelectedIndices[0]],true);
                _mainForm.MutationUC.clearAll();
                _mainForm.PatientUC.loadMutationDetails(_patientList[listView1.SelectedIndices[0]]);
                _mainForm.Enabled = true;
                this.Close();
            }
            else
                MessageBox.Show("No Selection Made");
        }

        //when cancel clicked, doesnt save anything, set main form enabled.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            _mainForm.Enabled = true;
            this.Close();
        }
    }
}

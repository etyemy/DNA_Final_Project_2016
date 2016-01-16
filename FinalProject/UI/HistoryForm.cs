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
     * History Form .
     * Main purpose - show all the patints that share the same mutation.
     */
    public partial class HistoryForm : Form
    {
        MainForm _mainForm;
        int nextPosition = 15;
        //Initialize the form with all patient from patientList.
        //Use the PatientUserControl without the button, only details to show.
        public HistoryForm(List<Patient> patientList, MainForm mainForm)
        {
            if (patientList != null)
            {
                _mainForm = mainForm;
                InitializeComponent();
                foreach (Patient p in patientList)
                {
                    PatientUserControl puc = new PatientUserControl(p);
                    this.Controls.Add(puc);
                    puc.Top = nextPosition;
                    puc.Left = -200;
                    nextPosition += 215;
                    puc.BackColor = System.Drawing.ColorTranslator.FromHtml("#ABCDEF");
                    puc.BorderStyle = BorderStyle.Fixed3D;
                }

            }
        }

        //Close the form.
        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}

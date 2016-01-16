using FinalProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    /*
     * Setting Form .
     * Main purpose - Implement an interface for managing software settings.
     */
    public partial class SettingForm : Form
    {
        //Holds the parent form that called the SettingForm.
        private MainForm mainForm;
       
        //Initialize the settings form.
        //Get the settings from Properties.
        public SettingForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            emailTextBox.Text = Properties.Settings.Default.CosmicEmail;
            passwordTextBox.Text = Properties.Settings.Default.CosmicPassword;
            exportPathTextBox.Text = Properties.Settings.Default.ExportSavePath;
        }

        //when cancel clicked, doesnt save anything, set main form enabled.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }
        
        //when save clicked, save the settings, set main form enabled.
        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CosmicEmail = emailTextBox.Text;
            Properties.Settings.Default.CosmicPassword = passwordTextBox.Text;
            Properties.Settings.Default.ExportSavePath = exportPathTextBox.Text;
            Properties.Settings.Default.Save();
            mainForm.Enabled = true;
            this.Close();
        }

        //when browse clicked, open directory select dialog,set the path diroctory to selected.
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                exportPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }
    }
}

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
     * Filter Article Form .
     * Main purpose - filter the articles in tab page table by journal field.
     */
    public partial class FilterArticlesForm : Form
    {
        private MainForm mainForm;
        private ArticleTabPage articleTabPage;
       
        //Initialize the form, get all journals and present them as a list of checkboxs.
        public FilterArticlesForm(MainForm mainForm, ArticleTabPage articleTabPage)
        {
            this.mainForm = mainForm;
            this.articleTabPage = articleTabPage;
            Dictionary<string, bool> dictionary = articleTabPage.getJournalToView();
            InitializeComponent();
            foreach (KeyValuePair<string, bool> entry in dictionary)
            {
                journalCheckedListBox.Items.Add(entry.Key,entry.Value);
            }
        }

        //Close the form without filtering.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        //Filter the table, shows only the articles that their journal checkbox was checked.
        private void saveButton_Click(object sender, EventArgs e)
        {
            Dictionary<string,bool> dic=articleTabPage.getJournalToView();
            for(int i=0;i<journalCheckedListBox.Items.Count;i++)
            {
                   string str = (string)journalCheckedListBox.Items[i];
                   dic[str]=journalCheckedListBox.GetItemChecked(i);
            }
            articleTabPage.filterTable();
            mainForm.Enabled = true;
            this.Close();
        }

        //Set all checkboxs to false.
        private void checkNoneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < journalCheckedListBox.Items.Count; i++)
            {
                journalCheckedListBox.SetItemChecked(i, false);
            }
        }

        //Set all checkboxs to true.
        private void checkAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < journalCheckedListBox.Items.Count; i++)
            {
                journalCheckedListBox.SetItemChecked(i, true);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DNA_Part_2;

namespace FinalProject.UI
{
    /*
    * Patient UserControl.
    * Main purpose - show mutations details in MainForm.
    * Part of MainForm. 
    */
    public partial class MutationUserControl : UserControl
    {
        private List<Mutation> _mutationList;
        private MainForm _mainForm;

        //initialize the MutationUserControl
        public MutationUserControl(MainForm mainForm)
        {

            InitializeComponent();
            _mainForm = mainForm;
            _mutationList = null;
            _mainForm.progressBarCounter = 0;//progress item counter
            mutationDataGridView.MouseEnter += (s, e) => this.Focus();
            mutationDataGridView.CellContentClick += dataGridView1_CellClick;
        }

        //occurs when cell clicked in dataGridView, use only in history field,Open the history form for current mutation.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)//if press on history column
            {
                string mutationId = _mutationList.ElementAt(e.RowIndex).MutId;
                try
                {
                    List<Patient> patientList = MainBL.getPatientListWithMutation(mutationId);
                    HistoryForm hf = new HistoryForm(patientList, _mainForm);
                    _mainForm.Enabled = false;
                    hf.Show();
                }
                catch (Exception)
                {
                    GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");

                }
                
            }
            if(e.ColumnIndex==15)//ADDED LINK TO NCBI REFSNP TO OPEN BROWSER WHEN CLICKED
            {
                String tempRs = mutationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                String ncbiUrl = "http://www.ncbi.nlm.nih.gov/SNP/snp_ref.cgi?rs=" + tempRs;
                try
                {
                    System.Diagnostics.Process.Start(ncbiUrl);
                }
                catch (Exception)
                {
                    GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");

                }

            }
        }
        //Initialize the table with the details from the mutation list.
        public void initTable(List<Mutation> mutationList)
        {

            _mutationList = mutationList;
            if (_mutationList != null)
            {
                RefSNP refSnp;
                foreach (Mutation m in _mutationList)
                {
                    DataGridViewRow tempRow = new DataGridViewRow();
                    tempRow.CreateCells(mutationDataGridView);
                    tempRow.Cells[0].Value = m.Chrom;
                    tempRow.Cells[1].Value = m.Position;
                    tempRow.Cells[2].Value = m.GeneName;
                    tempRow.Cells[3].Value = m.Ref;
                    tempRow.Cells[4].Value = m.Var;
                    tempRow.Cells[5].Value = m.Strand;
                    tempRow.Cells[6].Value = m.RefCodon;
                    tempRow.Cells[7].Value = m.VarCodon;
                    tempRow.Cells[8].Value = m.RefAA;
                    tempRow.Cells[9].Value = m.VarAA;
                    tempRow.Cells[10].Value = m.PMutationName;
                    tempRow.Cells[11].Value = m.CMutationName;
                    tempRow.Cells[12].Value = m.CosmicName;
                    tempRow.Cells[13].Value = m.NumOfShows;



                    //here we start the process
                    if (!LocalDbDAL.isRefSnpExists(m.Chrom.Substring(3), m.Position.ToString(), m.Var.ToString(), m.Ref.ToString()))
                    {
                        refSnp = new RefSNP(m.Chrom.Substring(3), m.Position.ToString(), m.Ref.ToString(), m.Var.ToString());//added
                    }
                    else
                    {
                        List<String> tempRefList = LocalDbDAL.getRefSnp(m.Chrom.Substring(3), m.Position.ToString(), m.Ref.ToString(), m.Var.ToString());
                        refSnp = new RefSNP(tempRefList);
                    }

                    if (!refSnp.RsId.Equals(""))
                    {
                        tempRow.Cells[15].Value = refSnp.RsId;//added
                        tempRow.Cells[16].Value = refSnp.ClinicalSignificance;//added
                        tempRow.Cells[17].Value = refSnp.Maf;//added
                        tempRow.Cells[18].Value = refSnp.ChromSampleCount;
                        tempRow.Cells[19].Value = refSnp.Alleles;
                        tempRow.Cells[20].Value = refSnp.AllelesPerc; 
                    }
                    else
                    {

                        tempRow.Cells[15].Value = "No known variants";//refSnp.rsId;//added
                        tempRow.Cells[16].Value = "-----";//refSnp.clinicalSignificance;//added
                        tempRow.Cells[17].Value = "-----";//refSnp.maf;//added
                        tempRow.Cells[18].Value = "-----";//refSnp.chromSampleCount;
                        tempRow.Cells[19].Value = "-----";//refSnp.alleles;
                        tempRow.Cells[20].Value = "-----";//refSnp.allelesPerc; 
                    }

                    try
                    {
                        int historyNum = MainBL.getNumOfPatientWithSameMutation(m.MutId);
                        if (historyNum == 0)
                            tempRow.Cells[14] = new DataGridViewTextBoxCell();
                        tempRow.Cells[14].Value = historyNum;
                        if (!m.CosmicName.Equals("-----"))
                            tempRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#90EE90");//#ABCDEF


                        if ( m.VarCodon.Equals("No Coding"))
                        {
                            if (m.isCodingInControlArea())//checks if chromosome position is in control 10 base area. which means that the position the Nucleotide is in a no coding area but is 10 or less positions from any exon in the gene
                            {
                                tempRow.Cells[6].Value = "No Coding - Control Area 10 Base";
                                tempRow.Cells[7].Value = "No Coding - Control Area 10 Base";
                                tempRow.Cells[7].Style.BackColor = Color.Red;
                                tempRow.Cells[7].Style.ForeColor= Color.White;
                                tempRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CED1");
                            } 
                        }


                        if ((refSnp.AllelesPerc!=null)&&(!refSnp.AllelesPerc.Equals("N/A")))//checks percentage
                        {
                            Double d1 = Convert.ToDouble(refSnp.AllelesPerc.Substring(0, 4));//checks if percentage is below 1%

                            if (d1 == 0.99 || d1 == 0.01)
                            {
                                tempRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CED1");
                                tempRow.Cells[20].Style.BackColor = Color.Red;
                                tempRow.Cells[20].Style.ForeColor= Color.White;


                            } 
                        }
                        mutationDataGridView.Rows.Add(tempRow);
                        mutationDataGridView.PerformLayout();


                    }
                    catch (Exception)
                    {
                        String errorMsg = "Something Went Wrong, failed to analayze " + m.ChromNum + " " + m.Position;
                        GeneralMethods.showErrorMessageBox(errorMsg);
                    }

                    try
                    {
                        
                        if (!LocalDbDAL.isRefSnpExists(refSnp.ChromozomeNum, refSnp.ChromPosition,refSnp.VarientNucleotide, refSnp.ReferenceNucleotide ))
                        {
                                LocalDbDAL.addRefSnp(refSnp.ChromozomeNum, refSnp.ChromPosition, refSnp.ReferenceNucleotide, refSnp.VarientNucleotide, refSnp.RsId, refSnp.ClinicalSignificance, refSnp.PopulationDiversity, refSnp.Maf, refSnp.ChromSampleCount, refSnp.Alleles, refSnp.AllelesPerc);
                        }    

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                                            
                }
            }
        }

        //Clear all the data from the table
        public void clearAll()
        {
            _mainForm.progressBarCounter = 0;
            _mutationList = null;
            mutationDataGridView.Rows.Clear();
        }

        private void mutationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataGridView getDGV()
        {
            return mutationDataGridView;
        }
    }
}

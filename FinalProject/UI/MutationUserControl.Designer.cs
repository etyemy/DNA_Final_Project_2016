namespace FinalProject.UI
{
    partial class MutationUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mutationDataGridView = new System.Windows.Forms.DataGridView();
            this.chromosomeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geneNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strandCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refCodonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCodonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refAACol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varAACol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aaNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdsNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cosmicNamesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numOfShowsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.refSNP = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clinicalSig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chromSampleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alleles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allelesPercenage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mutationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mutationDataGridView
            // 
            this.mutationDataGridView.AllowUserToAddRows = false;
            this.mutationDataGridView.AllowUserToDeleteRows = false;
            this.mutationDataGridView.AllowUserToOrderColumns = true;
            this.mutationDataGridView.AllowUserToResizeRows = false;
            this.mutationDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mutationDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.mutationDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mutationDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mutationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mutationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chromosomeCol,
            this.positionCol,
            this.geneNameCol,
            this.refCol,
            this.varCol,
            this.strandCol,
            this.refCodonCol,
            this.varCodonCol,
            this.refAACol,
            this.varAACol,
            this.aaNameCol,
            this.cdsNameCol,
            this.cosmicNamesCol,
            this.numOfShowsCol,
            this.historyCol,
            this.refSNP,
            this.clinicalSig,
            this.maf,
            this.chromSampleCount,
            this.alleles,
            this.allelesPercenage});
            this.mutationDataGridView.Location = new System.Drawing.Point(3, 0);
            this.mutationDataGridView.Name = "mutationDataGridView";
            this.mutationDataGridView.ReadOnly = true;
            this.mutationDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mutationDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.mutationDataGridView.Size = new System.Drawing.Size(1245, 188);
            this.mutationDataGridView.TabIndex = 0;
            this.mutationDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mutationDataGridView_CellContentClick);
            // 
            // chromosomeCol
            // 
            this.chromosomeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chromosomeCol.HeaderText = "Chromosome";
            this.chromosomeCol.Name = "chromosomeCol";
            this.chromosomeCol.ReadOnly = true;
            this.chromosomeCol.Width = 70;
            // 
            // positionCol
            // 
            this.positionCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.positionCol.HeaderText = "Position";
            this.positionCol.Name = "positionCol";
            this.positionCol.ReadOnly = true;
            this.positionCol.Width = 59;
            // 
            // geneNameCol
            // 
            this.geneNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.geneNameCol.HeaderText = "Gene Name";
            this.geneNameCol.Name = "geneNameCol";
            this.geneNameCol.ReadOnly = true;
            this.geneNameCol.Width = 59;
            // 
            // refCol
            // 
            this.refCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.refCol.HeaderText = "Ref";
            this.refCol.Name = "refCol";
            this.refCol.ReadOnly = true;
            this.refCol.Width = 60;
            // 
            // varCol
            // 
            this.varCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.varCol.HeaderText = "Var";
            this.varCol.Name = "varCol";
            this.varCol.ReadOnly = true;
            this.varCol.Width = 59;
            // 
            // strandCol
            // 
            this.strandCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.strandCol.HeaderText = "Strand";
            this.strandCol.Name = "strandCol";
            this.strandCol.ReadOnly = true;
            this.strandCol.Width = 59;
            // 
            // refCodonCol
            // 
            this.refCodonCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.refCodonCol.HeaderText = "Ref Codon";
            this.refCodonCol.Name = "refCodonCol";
            this.refCodonCol.ReadOnly = true;
            this.refCodonCol.Width = 59;
            // 
            // varCodonCol
            // 
            this.varCodonCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.varCodonCol.HeaderText = "Var Codon";
            this.varCodonCol.Name = "varCodonCol";
            this.varCodonCol.ReadOnly = true;
            this.varCodonCol.Width = 170;
            // 
            // refAACol
            // 
            this.refAACol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.refAACol.HeaderText = "Ref AA";
            this.refAACol.Name = "refAACol";
            this.refAACol.ReadOnly = true;
            this.refAACol.Width = 59;
            // 
            // varAACol
            // 
            this.varAACol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.varAACol.HeaderText = "Var AA";
            this.varAACol.Name = "varAACol";
            this.varAACol.ReadOnly = true;
            this.varAACol.Width = 59;
            // 
            // aaNameCol
            // 
            this.aaNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.aaNameCol.HeaderText = "AA Name";
            this.aaNameCol.Name = "aaNameCol";
            this.aaNameCol.ReadOnly = true;
            this.aaNameCol.Width = 60;
            // 
            // cdsNameCol
            // 
            this.cdsNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cdsNameCol.HeaderText = "CDS Name";
            this.cdsNameCol.Name = "cdsNameCol";
            this.cdsNameCol.ReadOnly = true;
            this.cdsNameCol.Width = 59;
            // 
            // cosmicNamesCol
            // 
            this.cosmicNamesCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cosmicNamesCol.HeaderText = "Cosmic Names";
            this.cosmicNamesCol.Name = "cosmicNamesCol";
            this.cosmicNamesCol.ReadOnly = true;
            this.cosmicNamesCol.Width = 59;
            // 
            // numOfShowsCol
            // 
            this.numOfShowsCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.numOfShowsCol.HeaderText = "Shows";
            this.numOfShowsCol.MinimumWidth = 20;
            this.numOfShowsCol.Name = "numOfShowsCol";
            this.numOfShowsCol.ReadOnly = true;
            this.numOfShowsCol.Width = 59;
            // 
            // historyCol
            // 
            this.historyCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.historyCol.HeaderText = "History";
            this.historyCol.Name = "historyCol";
            this.historyCol.ReadOnly = true;
            this.historyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.historyCol.Width = 59;
            // 
            // refSNP
            // 
            this.refSNP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.refSNP.HeaderText = "refSNP";
            this.refSNP.Name = "refSNP";
            this.refSNP.ReadOnly = true;
            this.refSNP.Width = 70;
            // 
            // clinicalSig
            // 
            this.clinicalSig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clinicalSig.HeaderText = "Clinical Significance";
            this.clinicalSig.Name = "clinicalSig";
            this.clinicalSig.ReadOnly = true;
            this.clinicalSig.Width = 160;
            // 
            // maf
            // 
            this.maf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maf.HeaderText = "MAF";
            this.maf.Name = "maf";
            this.maf.ReadOnly = true;
            this.maf.Width = 60;
            // 
            // chromSampleCount
            // 
            this.chromSampleCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chromSampleCount.HeaderText = "Chrom Sample Count";
            this.chromSampleCount.Name = "chromSampleCount";
            this.chromSampleCount.ReadOnly = true;
            this.chromSampleCount.Width = 160;
            // 
            // alleles
            // 
            this.alleles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.alleles.HeaderText = "Alleles";
            this.alleles.Name = "alleles";
            this.alleles.ReadOnly = true;
            this.alleles.Width = 59;
            // 
            // allelesPercenage
            // 
            this.allelesPercenage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.allelesPercenage.HeaderText = "Allele Pop. %";
            this.allelesPercenage.Name = "allelesPercenage";
            this.allelesPercenage.ReadOnly = true;
            this.allelesPercenage.Width = 160;
            // 
            // MutationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.mutationDataGridView);
            this.Name = "MutationUserControl";
            this.Size = new System.Drawing.Size(1251, 192);
            ((System.ComponentModel.ISupportInitialize)(this.mutationDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mutationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn chromosomeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn geneNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn strandCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refCodonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCodonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refAACol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varAACol;
        private System.Windows.Forms.DataGridViewTextBoxColumn aaNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdsNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cosmicNamesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numOfShowsCol;
        private System.Windows.Forms.DataGridViewLinkColumn historyCol;
        private System.Windows.Forms.DataGridViewLinkColumn refSNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicalSig;
        private System.Windows.Forms.DataGridViewTextBoxColumn maf;
        private System.Windows.Forms.DataGridViewTextBoxColumn chromSampleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn alleles;
        private System.Windows.Forms.DataGridViewTextBoxColumn allelesPercenage;
    }
}

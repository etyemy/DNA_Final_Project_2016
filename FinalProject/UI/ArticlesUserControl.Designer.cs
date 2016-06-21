namespace FinalProject.UI
{
    partial class ArticlesUserControl
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
            this._cosmicStatusText = new System.Windows.Forms.Label();
            this.CosmicStatusLabel = new System.Windows.Forms.Label();
            this.filterButton = new System.Windows.Forms.Button();
            this._articleTabControl = new System.Windows.Forms.TabControl();
            this.getArticlesButton = new System.Windows.Forms.Button();
            this._articlesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _cosmicStatusText
            // 
            this._cosmicStatusText.AutoSize = true;
            this._cosmicStatusText.BackColor = System.Drawing.Color.White;
            this._cosmicStatusText.ForeColor = System.Drawing.Color.Red;
            this._cosmicStatusText.Location = new System.Drawing.Point(91, 83);
            this._cosmicStatusText.Name = "_cosmicStatusText";
            this._cosmicStatusText.Size = new System.Drawing.Size(73, 13);
            this._cosmicStatusText.TabIndex = 59;
            this._cosmicStatusText.Text = "Disconnected";
            this._cosmicStatusText.Click += new System.EventHandler(this._cosmicStatusText_Click);
            // 
            // CosmicStatusLabel
            // 
            this.CosmicStatusLabel.AutoSize = true;
            this.CosmicStatusLabel.BackColor = System.Drawing.Color.White;
            this.CosmicStatusLabel.Location = new System.Drawing.Point(12, 83);
            this.CosmicStatusLabel.Name = "CosmicStatusLabel";
            this.CosmicStatusLabel.Size = new System.Drawing.Size(87, 13);
            this.CosmicStatusLabel.TabIndex = 58;
            this.CosmicStatusLabel.Text = "COSMIC Status: ";
            // 
            // filterButton
            // 
            this.filterButton.BackColor = System.Drawing.Color.White;
            this.filterButton.Enabled = false;
            this.filterButton.Location = new System.Drawing.Point(89, 120);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 57;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = false;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // _articleTabControl
            // 
            this._articleTabControl.Location = new System.Drawing.Point(190, 1);
            this._articleTabControl.Margin = new System.Windows.Forms.Padding(1);
            this._articleTabControl.Name = "_articleTabControl";
            this._articleTabControl.SelectedIndex = 0;
            this._articleTabControl.Size = new System.Drawing.Size(1055, 160);
            this._articleTabControl.TabIndex = 56;
            // 
            // getArticlesButton
            // 
            this.getArticlesButton.BackColor = System.Drawing.Color.White;
            this.getArticlesButton.Enabled = false;
            this.getArticlesButton.Location = new System.Drawing.Point(15, 120);
            this.getArticlesButton.Name = "getArticlesButton";
            this.getArticlesButton.Size = new System.Drawing.Size(75, 23);
            this.getArticlesButton.TabIndex = 55;
            this.getArticlesButton.Text = "Get Articles";
            this.getArticlesButton.UseVisualStyleBackColor = false;
            this.getArticlesButton.Click += new System.EventHandler(this.getArticlesButton_Click);
            // 
            // _articlesBackgroundWorker
            // 
            this._articlesBackgroundWorker.WorkerReportsProgress = true;
            this._articlesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._articlesBackgroundWorker_DoWork);
            this._articlesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._articlesBackgroundWorker_ProgressChanged);
            this._articlesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._articlesBackgroundWorker_RunWorkerCompleted);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(18, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "Articles Menu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::FinalProject.Properties.Resources.cosmic;
            this.pictureBox1.Location = new System.Drawing.Point(25, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 146;
            this.pictureBox1.TabStop = false;
            // 
            // ArticlesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._cosmicStatusText);
            this.Controls.Add(this.CosmicStatusLabel);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this._articleTabControl);
            this.Controls.Add(this.getArticlesButton);
            this.Name = "ArticlesUserControl";
            this.Size = new System.Drawing.Size(1244, 156);
            this.Load += new System.EventHandler(this.ArticlesUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _cosmicStatusText;
        private System.Windows.Forms.Label CosmicStatusLabel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TabControl _articleTabControl;
        private System.Windows.Forms.Button getArticlesButton;
        private System.ComponentModel.BackgroundWorker _articlesBackgroundWorker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

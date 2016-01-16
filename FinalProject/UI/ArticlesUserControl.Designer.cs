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
            this.SuspendLayout();
            // 
            // _cosmicStatusText
            // 
            this._cosmicStatusText.AutoSize = true;
            this._cosmicStatusText.ForeColor = System.Drawing.Color.Red;
            this._cosmicStatusText.Location = new System.Drawing.Point(265, 11);
            this._cosmicStatusText.Name = "_cosmicStatusText";
            this._cosmicStatusText.Size = new System.Drawing.Size(73, 13);
            this._cosmicStatusText.TabIndex = 59;
            this._cosmicStatusText.Text = "Disconnected";
            // 
            // CosmicStatusLabel
            // 
            this.CosmicStatusLabel.AutoSize = true;
            this.CosmicStatusLabel.Location = new System.Drawing.Point(182, 11);
            this.CosmicStatusLabel.Name = "CosmicStatusLabel";
            this.CosmicStatusLabel.Size = new System.Drawing.Size(87, 13);
            this.CosmicStatusLabel.TabIndex = 58;
            this.CosmicStatusLabel.Text = "COSMIC Status: ";
            // 
            // filterButton
            // 
            this.filterButton.Enabled = false;
            this.filterButton.Location = new System.Drawing.Point(84, 6);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 57;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // _articleTabControl
            // 
            this._articleTabControl.Location = new System.Drawing.Point(3, 35);
            this._articleTabControl.Name = "_articleTabControl";
            this._articleTabControl.SelectedIndex = 0;
            this._articleTabControl.Size = new System.Drawing.Size(1252, 142);
            this._articleTabControl.TabIndex = 56;
            // 
            // getArticlesButton
            // 
            this.getArticlesButton.Enabled = false;
            this.getArticlesButton.Location = new System.Drawing.Point(3, 6);
            this.getArticlesButton.Name = "getArticlesButton";
            this.getArticlesButton.Size = new System.Drawing.Size(75, 23);
            this.getArticlesButton.TabIndex = 55;
            this.getArticlesButton.Text = "Get Articles";
            this.getArticlesButton.UseVisualStyleBackColor = true;
            this.getArticlesButton.Click += new System.EventHandler(this.getArticlesButton_Click);
            // 
            // _articlesBackgroundWorker
            // 
            this._articlesBackgroundWorker.WorkerReportsProgress = true;
            this._articlesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._articlesBackgroundWorker_DoWork);
            this._articlesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._articlesBackgroundWorker_ProgressChanged);
            this._articlesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._articlesBackgroundWorker_RunWorkerCompleted);
            // 
            // ArticlesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cosmicStatusText);
            this.Controls.Add(this.CosmicStatusLabel);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this._articleTabControl);
            this.Controls.Add(this.getArticlesButton);
            this.Name = "ArticlesUserControl";
            this.Size = new System.Drawing.Size(1270, 182);
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
    }
}

namespace FinalProject.UI
{
    partial class InfoAnalyzeUserControl
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
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.Xls2Button = new System.Windows.Forms.Button();
            this.Xls1Button = new System.Windows.Forms.Button();
            this.xls1TextBox = new System.Windows.Forms.TextBox();
            this.xls2TextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._analyzeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._articlesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.AutoSize = true;
            this.progressBarLabel.BackColor = System.Drawing.Color.LightCyan;
            this.progressBarLabel.Location = new System.Drawing.Point(278, 8);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(43, 13);
            this.progressBarLabel.TabIndex = 52;
            this.progressBarLabel.Text = "Status: ";
            this.progressBarLabel.Click += new System.EventHandler(this.progressBarLabel_Click);
            // 
            // analyzeButton
            // 
            this.analyzeButton.BackgroundImage = global::FinalProject.Properties.Resources.Analyze_button1;
            this.analyzeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analyzeButton.Location = new System.Drawing.Point(204, 27);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(61, 28);
            this.analyzeButton.TabIndex = 48;
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // Xls2Button
            // 
            this.Xls2Button.Location = new System.Drawing.Point(3, 32);
            this.Xls2Button.Name = "Xls2Button";
            this.Xls2Button.Size = new System.Drawing.Size(47, 23);
            this.Xls2Button.TabIndex = 47;
            this.Xls2Button.Text = "CSV 2";
            this.Xls2Button.UseVisualStyleBackColor = true;
            this.Xls2Button.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // Xls1Button
            // 
            this.Xls1Button.Location = new System.Drawing.Point(2, 3);
            this.Xls1Button.Name = "Xls1Button";
            this.Xls1Button.Size = new System.Drawing.Size(48, 23);
            this.Xls1Button.TabIndex = 46;
            this.Xls1Button.Text = "CSV 1";
            this.Xls1Button.UseVisualStyleBackColor = true;
            this.Xls1Button.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // xls1TextBox
            // 
            this.xls1TextBox.Enabled = false;
            this.xls1TextBox.Location = new System.Drawing.Point(56, 6);
            this.xls1TextBox.Name = "xls1TextBox";
            this.xls1TextBox.Size = new System.Drawing.Size(100, 20);
            this.xls1TextBox.TabIndex = 45;
            // 
            // xls2TextBox
            // 
            this.xls2TextBox.Enabled = false;
            this.xls2TextBox.Location = new System.Drawing.Point(56, 32);
            this.xls2TextBox.Name = "xls2TextBox";
            this.xls2TextBox.Size = new System.Drawing.Size(100, 20);
            this.xls2TextBox.TabIndex = 44;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(271, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.TabIndex = 43;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "ION PGM File|*.csv";
            // 
            // _analyzeBackgroundWorker
            // 
            this._analyzeBackgroundWorker.WorkerReportsProgress = true;
            this._analyzeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.analyzeBackgroundWorker_DoWork);
            this._analyzeBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.analyzeBackgroundWorker_ProgressChanged);
            this._analyzeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.analyzeBackgroundWorker_RunWorkerCompleted);
            // 
            // InfoAnalyzeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::FinalProject.Properties.Resources.banner;
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.Xls2Button);
            this.Controls.Add(this.Xls1Button);
            this.Controls.Add(this.xls1TextBox);
            this.Controls.Add(this.xls2TextBox);
            this.Controls.Add(this.progressBar1);
            this.Name = "InfoAnalyzeUserControl";
            this.Size = new System.Drawing.Size(1270, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progressBarLabel;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Button Xls2Button;
        private System.Windows.Forms.Button Xls1Button;
        private System.Windows.Forms.TextBox xls1TextBox;
        private System.Windows.Forms.TextBox xls2TextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.ComponentModel.BackgroundWorker _analyzeBackgroundWorker;
        private System.ComponentModel.BackgroundWorker _articlesBackgroundWorker;
    }
}

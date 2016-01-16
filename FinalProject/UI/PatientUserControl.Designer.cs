namespace FinalProject.UI
{
    partial class PatientUserControl
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
            this.idToLoadTextBox = new System.Windows.Forms.TextBox();
            this._savePatientButton = new System.Windows.Forms.Button();
            this._loadPatientButton = new System.Windows.Forms.Button();
            this._coclusionsLabel = new System.Windows.Forms.Label();
            this._conclusionsTextBox1 = new System.Windows.Forms.RichTextBox();
            this._currentTreatmentLabel = new System.Windows.Forms.Label();
            this._currentTreatmentTextBox = new System.Windows.Forms.RichTextBox();
            this._previousTreatmentLabel = new System.Windows.Forms.Label();
            this._previousTreatmentTextBox = new System.Windows.Forms.RichTextBox();
            this._backgroundLabel = new System.Windows.Forms.Label();
            this._backgroundTextBox = new System.Windows.Forms.RichTextBox();
            this._diseaseLevelLabel = new System.Windows.Forms.Label();
            this._diseaseLevelTextBox = new System.Windows.Forms.RichTextBox();
            this._tumourSiteLabel = new System.Windows.Forms.Label();
            this._tumourSiteTextBox = new System.Windows.Forms.TextBox();
            this._runNoLabel = new System.Windows.Forms.Label();
            this._runNoTextBox = new System.Windows.Forms.TextBox();
            this._pathologicalNoLabel = new System.Windows.Forms.Label();
            this._pathologicalNoTextBox = new System.Windows.Forms.TextBox();
            this._lastNameLabel = new System.Windows.Forms.Label();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._idLabel = new System.Windows.Forms.Label();
            this._idTextBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.testNameLabel = new System.Windows.Forms.Label();
            this._testNameTextBox = new System.Windows.Forms.TextBox();
            this.PatientButtonPanel = new System.Windows.Forms.Panel();
            this.newPatientButton = new System.Windows.Forms.Button();
            this.patientDetailPanel = new System.Windows.Forms.Panel();
            this.PatientButtonPanel.SuspendLayout();
            this.patientDetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idToLoadTextBox
            // 
            this.idToLoadTextBox.Location = new System.Drawing.Point(96, 50);
            this.idToLoadTextBox.Name = "idToLoadTextBox";
            this.idToLoadTextBox.Size = new System.Drawing.Size(87, 20);
            this.idToLoadTextBox.TabIndex = 94;
            this.idToLoadTextBox.TextChanged += new System.EventHandler(this.DigitTextBox_TextChanged);
            // 
            // _savePatientButton
            // 
            this._savePatientButton.Enabled = false;
            this._savePatientButton.Location = new System.Drawing.Point(96, 7);
            this._savePatientButton.Name = "_savePatientButton";
            this._savePatientButton.Size = new System.Drawing.Size(87, 23);
            this._savePatientButton.TabIndex = 93;
            this._savePatientButton.Text = "Save ";
            this._savePatientButton.UseVisualStyleBackColor = true;
            this._savePatientButton.Click += new System.EventHandler(this._savePatientButton_Click);
            // 
            // _loadPatientButton
            // 
            this._loadPatientButton.Location = new System.Drawing.Point(3, 47);
            this._loadPatientButton.Name = "_loadPatientButton";
            this._loadPatientButton.Size = new System.Drawing.Size(87, 23);
            this._loadPatientButton.TabIndex = 92;
            this._loadPatientButton.Text = "Search (By ID)";
            this._loadPatientButton.UseVisualStyleBackColor = true;
            this._loadPatientButton.Click += new System.EventHandler(this._searchPatientButton_Click);
            // 
            // _coclusionsLabel
            // 
            this._coclusionsLabel.AutoSize = true;
            this._coclusionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._coclusionsLabel.Location = new System.Drawing.Point(828, 0);
            this._coclusionsLabel.Name = "_coclusionsLabel";
            this._coclusionsLabel.Size = new System.Drawing.Size(75, 13);
            this._coclusionsLabel.TabIndex = 91;
            this._coclusionsLabel.Text = "Conclusions";
            // 
            // _conclusionsTextBox1
            // 
            this._conclusionsTextBox1.Location = new System.Drawing.Point(831, 16);
            this._conclusionsTextBox1.Name = "_conclusionsTextBox1";
            this._conclusionsTextBox1.Size = new System.Drawing.Size(213, 173);
            this._conclusionsTextBox1.TabIndex = 90;
            this._conclusionsTextBox1.Text = "";
            // 
            // _currentTreatmentLabel
            // 
            this._currentTreatmentLabel.AutoSize = true;
            this._currentTreatmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._currentTreatmentLabel.Location = new System.Drawing.Point(609, 0);
            this._currentTreatmentLabel.Name = "_currentTreatmentLabel";
            this._currentTreatmentLabel.Size = new System.Drawing.Size(109, 13);
            this._currentTreatmentLabel.TabIndex = 89;
            this._currentTreatmentLabel.Text = "Current Treatment";
            // 
            // _currentTreatmentTextBox
            // 
            this._currentTreatmentTextBox.Location = new System.Drawing.Point(612, 16);
            this._currentTreatmentTextBox.Name = "_currentTreatmentTextBox";
            this._currentTreatmentTextBox.Size = new System.Drawing.Size(213, 173);
            this._currentTreatmentTextBox.TabIndex = 88;
            this._currentTreatmentTextBox.Text = "";
            // 
            // _previousTreatmentLabel
            // 
            this._previousTreatmentLabel.AutoSize = true;
            this._previousTreatmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._previousTreatmentLabel.Location = new System.Drawing.Point(393, 0);
            this._previousTreatmentLabel.Name = "_previousTreatmentLabel";
            this._previousTreatmentLabel.Size = new System.Drawing.Size(117, 13);
            this._previousTreatmentLabel.TabIndex = 87;
            this._previousTreatmentLabel.Text = "Previous Treatment";
            // 
            // _previousTreatmentTextBox
            // 
            this._previousTreatmentTextBox.Location = new System.Drawing.Point(396, 16);
            this._previousTreatmentTextBox.Name = "_previousTreatmentTextBox";
            this._previousTreatmentTextBox.Size = new System.Drawing.Size(210, 173);
            this._previousTreatmentTextBox.TabIndex = 86;
            this._previousTreatmentTextBox.Text = "";
            // 
            // _backgroundLabel
            // 
            this._backgroundLabel.AutoSize = true;
            this._backgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._backgroundLabel.Location = new System.Drawing.Point(226, 78);
            this._backgroundLabel.Name = "_backgroundLabel";
            this._backgroundLabel.Size = new System.Drawing.Size(75, 13);
            this._backgroundLabel.TabIndex = 85;
            this._backgroundLabel.Text = "Background";
            // 
            // _backgroundTextBox
            // 
            this._backgroundTextBox.Location = new System.Drawing.Point(229, 94);
            this._backgroundTextBox.Name = "_backgroundTextBox";
            this._backgroundTextBox.Size = new System.Drawing.Size(161, 95);
            this._backgroundTextBox.TabIndex = 84;
            this._backgroundTextBox.Text = "";
            // 
            // _diseaseLevelLabel
            // 
            this._diseaseLevelLabel.AutoSize = true;
            this._diseaseLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._diseaseLevelLabel.Location = new System.Drawing.Point(226, 0);
            this._diseaseLevelLabel.Name = "_diseaseLevelLabel";
            this._diseaseLevelLabel.Size = new System.Drawing.Size(87, 13);
            this._diseaseLevelLabel.TabIndex = 83;
            this._diseaseLevelLabel.Text = "Disease Level";
            // 
            // _diseaseLevelTextBox
            // 
            this._diseaseLevelTextBox.Location = new System.Drawing.Point(229, 16);
            this._diseaseLevelTextBox.Name = "_diseaseLevelTextBox";
            this._diseaseLevelTextBox.Size = new System.Drawing.Size(161, 38);
            this._diseaseLevelTextBox.TabIndex = 82;
            this._diseaseLevelTextBox.Text = "";
            // 
            // _tumourSiteLabel
            // 
            this._tumourSiteLabel.AutoSize = true;
            this._tumourSiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._tumourSiteLabel.Location = new System.Drawing.Point(112, 80);
            this._tumourSiteLabel.Name = "_tumourSiteLabel";
            this._tumourSiteLabel.Size = new System.Drawing.Size(75, 13);
            this._tumourSiteLabel.TabIndex = 81;
            this._tumourSiteLabel.Text = "Tomour Site";
            // 
            // _tumourSiteTextBox
            // 
            this._tumourSiteTextBox.Location = new System.Drawing.Point(115, 96);
            this._tumourSiteTextBox.Name = "_tumourSiteTextBox";
            this._tumourSiteTextBox.Size = new System.Drawing.Size(100, 20);
            this._tumourSiteTextBox.TabIndex = 80;
            this._tumourSiteTextBox.TextChanged += new System.EventHandler(this.SmallDetailsTextBox_TextChanged);
            // 
            // _runNoLabel
            // 
            this._runNoLabel.AutoSize = true;
            this._runNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._runNoLabel.Location = new System.Drawing.Point(112, 41);
            this._runNoLabel.Name = "_runNoLabel";
            this._runNoLabel.Size = new System.Drawing.Size(50, 13);
            this._runNoLabel.TabIndex = 79;
            this._runNoLabel.Text = "Run No";
            // 
            // _runNoTextBox
            // 
            this._runNoTextBox.Location = new System.Drawing.Point(115, 57);
            this._runNoTextBox.Name = "_runNoTextBox";
            this._runNoTextBox.Size = new System.Drawing.Size(100, 20);
            this._runNoTextBox.TabIndex = 78;
            this._runNoTextBox.TextChanged += new System.EventHandler(this.SmallDetailsTextBox_TextChanged);
            // 
            // _pathologicalNoLabel
            // 
            this._pathologicalNoLabel.AutoSize = true;
            this._pathologicalNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._pathologicalNoLabel.Location = new System.Drawing.Point(112, 2);
            this._pathologicalNoLabel.Name = "_pathologicalNoLabel";
            this._pathologicalNoLabel.Size = new System.Drawing.Size(97, 13);
            this._pathologicalNoLabel.TabIndex = 77;
            this._pathologicalNoLabel.Text = "Pathological No";
            // 
            // _pathologicalNoTextBox
            // 
            this._pathologicalNoTextBox.Location = new System.Drawing.Point(115, 18);
            this._pathologicalNoTextBox.Name = "_pathologicalNoTextBox";
            this._pathologicalNoTextBox.Size = new System.Drawing.Size(100, 20);
            this._pathologicalNoTextBox.TabIndex = 76;
            this._pathologicalNoTextBox.TextChanged += new System.EventHandler(this.SmallDetailsTextBox_TextChanged);
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lastNameLabel.Location = new System.Drawing.Point(3, 117);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(67, 13);
            this._lastNameLabel.TabIndex = 75;
            this._lastNameLabel.Text = "Last Name";
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(6, 133);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._lastNameTextBox.TabIndex = 74;
            this._lastNameTextBox.TextChanged += new System.EventHandler(this.SmallDetailsTextBox_TextChanged);
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._firstNameLabel.Location = new System.Drawing.Point(3, 78);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(67, 13);
            this._firstNameLabel.TabIndex = 73;
            this._firstNameLabel.Text = "First Name";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(6, 94);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._firstNameTextBox.TabIndex = 72;
            this._firstNameTextBox.TextChanged += new System.EventHandler(this.SmallDetailsTextBox_TextChanged);
            // 
            // _idLabel
            // 
            this._idLabel.AutoSize = true;
            this._idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._idLabel.Location = new System.Drawing.Point(3, 39);
            this._idLabel.Name = "_idLabel";
            this._idLabel.Size = new System.Drawing.Size(20, 13);
            this._idLabel.TabIndex = 71;
            this._idLabel.Text = "ID";
            // 
            // _idTextBox
            // 
            this._idTextBox.Location = new System.Drawing.Point(6, 55);
            this._idTextBox.Name = "_idTextBox";
            this._idTextBox.Size = new System.Drawing.Size(100, 20);
            this._idTextBox.TabIndex = 70;
            this._idTextBox.TextChanged += new System.EventHandler(this.DigitTextBox_TextChanged);
            // 
            // testNameLabel
            // 
            this.testNameLabel.AutoSize = true;
            this.testNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.testNameLabel.Location = new System.Drawing.Point(3, 0);
            this.testNameLabel.Name = "testNameLabel";
            this.testNameLabel.Size = new System.Drawing.Size(68, 13);
            this.testNameLabel.TabIndex = 96;
            this.testNameLabel.Text = "Test Name";
            // 
            // _testNameTextBox
            // 
            this._testNameTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._testNameTextBox.Enabled = false;
            this._testNameTextBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this._testNameTextBox.Location = new System.Drawing.Point(6, 16);
            this._testNameTextBox.Name = "_testNameTextBox";
            this._testNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._testNameTextBox.TabIndex = 95;
            // 
            // PatientButtonPanel
            // 
            this.PatientButtonPanel.Controls.Add(this.newPatientButton);
            this.PatientButtonPanel.Controls.Add(this._loadPatientButton);
            this.PatientButtonPanel.Controls.Add(this.idToLoadTextBox);
            this.PatientButtonPanel.Controls.Add(this._savePatientButton);
            this.PatientButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.PatientButtonPanel.Name = "PatientButtonPanel";
            this.PatientButtonPanel.Size = new System.Drawing.Size(207, 80);
            this.PatientButtonPanel.TabIndex = 97;
            // 
            // newPatientButton
            // 
            this.newPatientButton.Location = new System.Drawing.Point(3, 7);
            this.newPatientButton.Name = "newPatientButton";
            this.newPatientButton.Size = new System.Drawing.Size(87, 23);
            this.newPatientButton.TabIndex = 95;
            this.newPatientButton.Text = "New";
            this.newPatientButton.UseVisualStyleBackColor = true;
            this.newPatientButton.Click += new System.EventHandler(this.newPatientButton_Click);
            // 
            // patientDetailPanel
            // 
            this.patientDetailPanel.Controls.Add(this._testNameTextBox);
            this.patientDetailPanel.Controls.Add(this._idTextBox);
            this.patientDetailPanel.Controls.Add(this.testNameLabel);
            this.patientDetailPanel.Controls.Add(this._idLabel);
            this.patientDetailPanel.Controls.Add(this._firstNameTextBox);
            this.patientDetailPanel.Controls.Add(this._coclusionsLabel);
            this.patientDetailPanel.Controls.Add(this._firstNameLabel);
            this.patientDetailPanel.Controls.Add(this._conclusionsTextBox1);
            this.patientDetailPanel.Controls.Add(this._lastNameTextBox);
            this.patientDetailPanel.Controls.Add(this._currentTreatmentLabel);
            this.patientDetailPanel.Controls.Add(this._lastNameLabel);
            this.patientDetailPanel.Controls.Add(this._currentTreatmentTextBox);
            this.patientDetailPanel.Controls.Add(this._pathologicalNoTextBox);
            this.patientDetailPanel.Controls.Add(this._previousTreatmentLabel);
            this.patientDetailPanel.Controls.Add(this._pathologicalNoLabel);
            this.patientDetailPanel.Controls.Add(this._previousTreatmentTextBox);
            this.patientDetailPanel.Controls.Add(this._runNoTextBox);
            this.patientDetailPanel.Controls.Add(this._backgroundLabel);
            this.patientDetailPanel.Controls.Add(this._runNoLabel);
            this.patientDetailPanel.Controls.Add(this._backgroundTextBox);
            this.patientDetailPanel.Controls.Add(this._tumourSiteTextBox);
            this.patientDetailPanel.Controls.Add(this._diseaseLevelLabel);
            this.patientDetailPanel.Controls.Add(this._tumourSiteLabel);
            this.patientDetailPanel.Controls.Add(this._diseaseLevelTextBox);
            this.patientDetailPanel.Location = new System.Drawing.Point(210, 0);
            this.patientDetailPanel.Name = "patientDetailPanel";
            this.patientDetailPanel.Size = new System.Drawing.Size(1051, 198);
            this.patientDetailPanel.TabIndex = 98;
            this.patientDetailPanel.Visible = false;
            // 
            // PatientUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinalProject.Properties.Resources.AutoAnalyze2_0_bot_banner;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.patientDetailPanel);
            this.Controls.Add(this.PatientButtonPanel);
            this.Name = "PatientUserControl";
            this.Size = new System.Drawing.Size(1270, 203);
            this.PatientButtonPanel.ResumeLayout(false);
            this.PatientButtonPanel.PerformLayout();
            this.patientDetailPanel.ResumeLayout(false);
            this.patientDetailPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox idToLoadTextBox;
        private System.Windows.Forms.Button _savePatientButton;
        private System.Windows.Forms.Button _loadPatientButton;
        private System.Windows.Forms.Label _coclusionsLabel;
        private System.Windows.Forms.RichTextBox _conclusionsTextBox1;
        private System.Windows.Forms.Label _currentTreatmentLabel;
        private System.Windows.Forms.RichTextBox _currentTreatmentTextBox;
        private System.Windows.Forms.Label _previousTreatmentLabel;
        private System.Windows.Forms.RichTextBox _previousTreatmentTextBox;
        private System.Windows.Forms.Label _backgroundLabel;
        private System.Windows.Forms.RichTextBox _backgroundTextBox;
        private System.Windows.Forms.Label _diseaseLevelLabel;
        private System.Windows.Forms.RichTextBox _diseaseLevelTextBox;
        private System.Windows.Forms.Label _tumourSiteLabel;
        private System.Windows.Forms.TextBox _tumourSiteTextBox;
        private System.Windows.Forms.Label _runNoLabel;
        private System.Windows.Forms.TextBox _runNoTextBox;
        private System.Windows.Forms.Label _pathologicalNoLabel;
        private System.Windows.Forms.TextBox _pathologicalNoTextBox;
        private System.Windows.Forms.Label _lastNameLabel;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.Label _firstNameLabel;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.Label _idLabel;
        private System.Windows.Forms.TextBox _idTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label testNameLabel;
        private System.Windows.Forms.TextBox _testNameTextBox;
        private System.Windows.Forms.Panel PatientButtonPanel;
        private System.Windows.Forms.Button newPatientButton;
        private System.Windows.Forms.Panel patientDetailPanel;

    }
}

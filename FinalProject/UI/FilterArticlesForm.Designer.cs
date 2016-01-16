namespace FinalProject.UI
{
    partial class FilterArticlesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterArticlesForm));
            this.journalCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.checkAllButton = new System.Windows.Forms.Button();
            this.checkNoneButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // journalCheckedListBox
            // 
            this.journalCheckedListBox.CheckOnClick = true;
            this.journalCheckedListBox.FormattingEnabled = true;
            this.journalCheckedListBox.Location = new System.Drawing.Point(13, 13);
            this.journalCheckedListBox.Name = "journalCheckedListBox";
            this.journalCheckedListBox.Size = new System.Drawing.Size(348, 274);
            this.journalCheckedListBox.Sorted = true;
            this.journalCheckedListBox.TabIndex = 0;
            this.journalCheckedListBox.ThreeDCheckBoxes = true;
            // 
            // checkAllButton
            // 
            this.checkAllButton.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.checkAllButton.Location = new System.Drawing.Point(13, 298);
            this.checkAllButton.Name = "checkAllButton";
            this.checkAllButton.Size = new System.Drawing.Size(75, 23);
            this.checkAllButton.TabIndex = 1;
            this.checkAllButton.Text = "Check All";
            this.checkAllButton.UseVisualStyleBackColor = true;
            this.checkAllButton.Click += new System.EventHandler(this.checkAllButton_Click);
            // 
            // checkNoneButton
            // 
            this.checkNoneButton.Location = new System.Drawing.Point(94, 298);
            this.checkNoneButton.Name = "checkNoneButton";
            this.checkNoneButton.Size = new System.Drawing.Size(75, 23);
            this.checkNoneButton.TabIndex = 2;
            this.checkNoneButton.Text = "Check None";
            this.checkNoneButton.UseVisualStyleBackColor = true;
            this.checkNoneButton.Click += new System.EventHandler(this.checkNoneButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(286, 298);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(205, 298);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FilterArticlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 333);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkNoneButton);
            this.Controls.Add(this.checkAllButton);
            this.Controls.Add(this.journalCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterArticlesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter By Journal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox journalCheckedListBox;
        private System.Windows.Forms.Button checkAllButton;
        private System.Windows.Forms.Button checkNoneButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}
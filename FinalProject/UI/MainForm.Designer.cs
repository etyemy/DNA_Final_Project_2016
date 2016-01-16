namespace FinalProject.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docxWithDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docxWithoutDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxMutationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLWithGermlineDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.BackColor = System.Drawing.SystemColors.HighlightText;
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1270, 24);
            this._menuStrip.TabIndex = 17;
            this._menuStrip.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllMenuItem,
            this.toolStripSeparator1,
            this.settingMenuItem,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearAllMenuItem
            // 
            this.clearAllMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllMenuItem.Text = "Clear All";
            this.clearAllMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // settingMenuItem
            // 
            this.settingMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingMenuItem.Name = "settingMenuItem";
            this.settingMenuItem.Size = new System.Drawing.Size(118, 22);
            this.settingMenuItem.Text = "Setting";
            this.settingMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docxWithDetailsMenuItem,
            this.docxWithoutDetailsMenuItem,
            this.xlsxMutationMenuItem,
            this.xMLWithGermlineDetailsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // docxWithDetailsMenuItem
            // 
            this.docxWithDetailsMenuItem.Name = "docxWithDetailsMenuItem";
            this.docxWithDetailsMenuItem.Size = new System.Drawing.Size(225, 22);
            this.docxWithDetailsMenuItem.Text = "DOCX - With Details";
            this.docxWithDetailsMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // docxWithoutDetailsMenuItem
            // 
            this.docxWithoutDetailsMenuItem.Name = "docxWithoutDetailsMenuItem";
            this.docxWithoutDetailsMenuItem.Size = new System.Drawing.Size(225, 22);
            this.docxWithoutDetailsMenuItem.Text = "DOCX - Without Details";
            this.docxWithoutDetailsMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // xlsxMutationMenuItem
            // 
            this.xlsxMutationMenuItem.Name = "xlsxMutationMenuItem";
            this.xlsxMutationMenuItem.Size = new System.Drawing.Size(225, 22);
            this.xlsxMutationMenuItem.Text = "XLSX - Mutation ";
            this.xlsxMutationMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // xMLWithGermlineDetailsToolStripMenuItem
            // 
            this.xMLWithGermlineDetailsToolStripMenuItem.Name = "xMLWithGermlineDetailsToolStripMenuItem";
            this.xMLWithGermlineDetailsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.xMLWithGermlineDetailsToolStripMenuItem.Text = "XLSX - With Germline Details";
            this.xMLWithGermlineDetailsToolStripMenuItem.Click += new System.EventHandler(this.xMLWithGermlineDetailsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1270, 662);
            this.Controls.Add(this._menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoAnalyze v2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docxWithDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docxWithoutDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxMutationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLWithGermlineDetailsToolStripMenuItem;

    }
}
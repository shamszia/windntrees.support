namespace ApplicationForms.ParentForms
{
    partial class FormBasic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBasic));
            this.panelFill = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarForm = new System.Windows.Forms.ToolStripProgressBar();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.statusBar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFill
            // 
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Name = "panelFill";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText,
            this.toolStripProgressBarForm});
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.Name = "statusBar";
            this.statusBar.SizingGrip = false;
            // 
            // statusBarText
            // 
            this.statusBarText.Name = "statusBarText";
            resources.ApplyResources(this.statusBarText, "statusBarText");
            // 
            // toolStripProgressBarForm
            // 
            this.toolStripProgressBarForm.Name = "toolStripProgressBarForm";
            resources.ApplyResources(this.toolStripProgressBarForm, "toolStripProgressBarForm");
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.labelFormTitle);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label1, "label1");
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Name = "label1";
            // 
            // labelFormTitle
            // 
            resources.ApplyResources(this.labelFormTitle, "labelFormTitle");
            this.labelFormTitle.Name = "labelFormTitle";
            // 
            // FormBasic
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusBar);
            this.Name = "FormBasic";
            this.Load += new System.EventHandler(this.FormStyle1_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label labelFormTitle;
        protected System.Windows.Forms.Panel panelFill;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        protected System.Windows.Forms.ToolStripProgressBar toolStripProgressBarForm;
    }
}
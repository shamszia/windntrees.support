namespace ApplicationForms.ParentForms
{
    partial class FormEntity
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntity));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFormActionsMiddle = new System.Windows.Forms.Panel();
            this.panelFormActions = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelEntityActions = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarForm = new System.Windows.Forms.ToolStripProgressBar();
            this.panelFill = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceEntity = new System.Windows.Forms.BindingSource(this.components);
            this.errorProviderEntity = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom.SuspendLayout();
            this.panelFormActions.SuspendLayout();
            this.panelEntityActions.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFormActionsMiddle);
            this.panelBottom.Controls.Add(this.panelFormActions);
            this.panelBottom.Controls.Add(this.panelEntityActions);
            this.panelBottom.Controls.Add(this.label2);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // panelFormActionsMiddle
            // 
            resources.ApplyResources(this.panelFormActionsMiddle, "panelFormActionsMiddle");
            this.panelFormActionsMiddle.Name = "panelFormActionsMiddle";
            // 
            // panelFormActions
            // 
            this.panelFormActions.Controls.Add(this.buttonCancel);
            this.panelFormActions.Controls.Add(this.buttonClose);
            resources.ApplyResources(this.panelFormActions, "panelFormActions");
            this.panelFormActions.Name = "panelFormActions";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelEntityActions
            // 
            this.panelEntityActions.Controls.Add(this.buttonSave);
            resources.ApplyResources(this.panelEntityActions, "panelEntityActions");
            this.panelEntityActions.Name = "panelEntityActions";
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Name = "label2";
            // 
            // statusBar
            // 
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText,
            this.toolStripProgressBarForm});
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
            // panelFill
            // 
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Name = "panelFill";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTitle);
            this.panelTop.Controls.Add(this.label1);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // panelTitle
            // 
            resources.ApplyResources(this.panelTitle, "panelTitle");
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.labelFormTitle);
            this.panelTitle.Name = "panelTitle";
            // 
            // labelFormTitle
            // 
            resources.ApplyResources(this.labelFormTitle, "labelFormTitle");
            this.labelFormTitle.Name = "labelFormTitle";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label1, "label1");
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Name = "label1";
            // 
            // errorProviderEntity
            // 
            this.errorProviderEntity.ContainerControl = this;
            // 
            // FormEntity
            // 
            this.AcceptButton = this.buttonSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusBar);
            this.KeyPreview = true;
            this.Name = "FormEntity";
            this.Load += new System.EventHandler(this.FrmAddStyle1_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelFormActions.ResumeLayout(false);
            this.panelEntityActions.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panelBottom;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        protected System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitle;
        protected System.Windows.Forms.Label labelFormTitle;
        protected System.Windows.Forms.Button buttonSave;
        protected System.Windows.Forms.Panel panelFormActions;
        protected System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelEntityActions;
        protected System.Windows.Forms.ToolStripProgressBar toolStripProgressBarForm;
        protected System.Windows.Forms.Button buttonCancel;
        protected System.Windows.Forms.BindingSource bindingSourceEntity;
        protected System.Windows.Forms.ErrorProvider errorProviderEntity;
        protected System.Windows.Forms.Panel panelFormActionsMiddle;
    }
}
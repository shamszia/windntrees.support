namespace ApplicationForms.Core.Product
{
    partial class FormProduct
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.bindingSourceEntity = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxManufacturer = new System.Windows.Forms.TextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.textBoxLegalCode = new System.Windows.Forms.TextBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.labelUnit = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelLegalCode = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderEntity = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom.SuspendLayout();
            this.panelFormActions.SuspendLayout();
            this.panelEntityActions.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFormActionsMiddle);
            this.panelBottom.Controls.Add(this.panelFormActions);
            this.panelBottom.Controls.Add(this.panelEntityActions);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 411);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(635, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // panelFormActionsMiddle
            // 
            this.panelFormActionsMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormActionsMiddle.Location = new System.Drawing.Point(200, 0);
            this.panelFormActionsMiddle.Name = "panelFormActionsMiddle";
            this.panelFormActionsMiddle.Size = new System.Drawing.Size(235, 40);
            this.panelFormActionsMiddle.TabIndex = 0;
            // 
            // panelFormActions
            // 
            this.panelFormActions.Controls.Add(this.buttonCancel);
            this.panelFormActions.Controls.Add(this.buttonClose);
            this.panelFormActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFormActions.Location = new System.Drawing.Point(435, 0);
            this.panelFormActions.Name = "panelFormActions";
            this.panelFormActions.Size = new System.Drawing.Size(200, 40);
            this.panelFormActions.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(32, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(113, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelEntityActions
            // 
            this.panelEntityActions.Controls.Add(this.buttonSave);
            this.panelEntityActions.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEntityActions.Location = new System.Drawing.Point(0, 0);
            this.panelEntityActions.Name = "panelEntityActions";
            this.panelEntityActions.Size = new System.Drawing.Size(200, 40);
            this.panelEntityActions.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText,
            this.toolStripProgressBarForm});
            this.statusBar.Location = new System.Drawing.Point(0, 451);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(635, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 3;
            // 
            // statusBarText
            // 
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBarForm
            // 
            this.toolStripProgressBarForm.Name = "toolStripProgressBarForm";
            this.toolStripProgressBarForm.Size = new System.Drawing.Size(100, 16);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tableLayoutPanel1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 60);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(635, 351);
            this.panelFill.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDescription, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCategory, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxManufacturer, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUnit, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColor, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCode, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLegalCode, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxVersion, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYear, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDescription, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCategory, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelManufacturer, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelUnit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelColor, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelCode, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelLegalCode, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelVersion, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelYear, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 351);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxName, 3);
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Name", true));
            this.textBoxName.Location = new System.Drawing.Point(154, 41);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(412, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // bindingSourceEntity
            // 
            this.bindingSourceEntity.DataSource = typeof(Application.Models.Standard.DataAccess.Product);
            // 
            // textBoxDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxDescription, 3);
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Description", true));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(154, 73);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.tableLayoutPanel1.SetRowSpan(this.textBoxDescription, 2);
            this.textBoxDescription.Size = new System.Drawing.Size(412, 64);
            this.textBoxDescription.TabIndex = 3;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Category", true));
            this.textBoxCategory.Location = new System.Drawing.Point(154, 146);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(159, 23);
            this.textBoxCategory.TabIndex = 5;
            // 
            // textBoxManufacturer
            // 
            this.textBoxManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxManufacturer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Manufacturer", true));
            this.textBoxManufacturer.Location = new System.Drawing.Point(407, 146);
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.Size = new System.Drawing.Size(159, 23);
            this.textBoxManufacturer.TabIndex = 7;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUnit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Unit", true));
            this.textBoxUnit.Location = new System.Drawing.Point(154, 181);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(159, 23);
            this.textBoxUnit.TabIndex = 9;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxColor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Color", true));
            this.textBoxColor.Location = new System.Drawing.Point(407, 181);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(159, 23);
            this.textBoxColor.TabIndex = 11;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Code", true));
            this.textBoxCode.Location = new System.Drawing.Point(154, 216);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(159, 23);
            this.textBoxCode.TabIndex = 13;
            // 
            // textBoxLegalCode
            // 
            this.textBoxLegalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLegalCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "LegalCode", true));
            this.textBoxLegalCode.Location = new System.Drawing.Point(407, 216);
            this.textBoxLegalCode.Name = "textBoxLegalCode";
            this.textBoxLegalCode.Size = new System.Drawing.Size(159, 23);
            this.textBoxLegalCode.TabIndex = 15;
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Version", true));
            this.textBoxVersion.Location = new System.Drawing.Point(154, 251);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(159, 23);
            this.textBoxVersion.TabIndex = 17;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "ProductYear", true));
            this.textBoxYear.Location = new System.Drawing.Point(407, 251);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(159, 23);
            this.textBoxYear.TabIndex = 19;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(66, 35);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(66, 70);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 15);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(66, 140);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(55, 15);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Category";
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.AutoSize = true;
            this.labelManufacturer.Location = new System.Drawing.Point(319, 140);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(79, 15);
            this.labelManufacturer.TabIndex = 6;
            this.labelManufacturer.Text = "Manufacturer";
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Location = new System.Drawing.Point(66, 175);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(29, 15);
            this.labelUnit.TabIndex = 8;
            this.labelUnit.Text = "Unit";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(319, 175);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(36, 15);
            this.labelColor.TabIndex = 10;
            this.labelColor.Text = "Color";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(66, 210);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(35, 15);
            this.labelCode.TabIndex = 12;
            this.labelCode.Text = "Code";
            // 
            // labelLegalCode
            // 
            this.labelLegalCode.AutoSize = true;
            this.labelLegalCode.Location = new System.Drawing.Point(319, 210);
            this.labelLegalCode.Name = "labelLegalCode";
            this.labelLegalCode.Size = new System.Drawing.Size(66, 15);
            this.labelLegalCode.TabIndex = 14;
            this.labelLegalCode.Text = "Legal Code";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(66, 245);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 15);
            this.labelVersion.TabIndex = 16;
            this.labelVersion.Text = "Version";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(319, 245);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(29, 15);
            this.labelYear.TabIndex = 18;
            this.labelYear.Text = "Year";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTitle);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(635, 60);
            this.panelTop.TabIndex = 2;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.labelFormTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(200, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFormTitle.Location = new System.Drawing.Point(12, 9);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(174, 45);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "Product Form";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(535, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 60);
            this.label1.TabIndex = 1;
            // 
            // errorProviderEntity
            // 
            this.errorProviderEntity.ContainerControl = this;
            // 
            // FormProduct
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(635, 473);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusBar);
            this.KeyPreview = true;
            this.Name = "FormProduct";
            this.Load += new System.EventHandler(this.FrmAddStyle1_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelFormActions.ResumeLayout(false);
            this.panelEntityActions.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxLegalCode;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelLegalCode;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelYear;
    }
}

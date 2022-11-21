namespace ApplicationForms.Core.Product
{
    partial class FormManageProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageProducts));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.panelFormActions = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelEntityActions = new System.Windows.Forms.Panel();
            this.labelTotalRecords = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarForm = new System.Windows.Forms.ToolStripProgressBar();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelSearchButton = new System.Windows.Forms.Panel();
            this.panelKeyword = new System.Windows.Forms.Panel();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.panelNew = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelPictureProcessing = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelBusinessName = new System.Windows.Forms.Label();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceGridView = new System.Windows.Forms.BindingSource(this.components);
            this.panelFill = new System.Windows.Forms.Panel();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.uIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            this.panelFormActions.SuspendLayout();
            this.panelEntityActions.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            this.panelSearchButton.SuspendLayout();
            this.panelKeyword.SuspendLayout();
            this.panelNew.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelPictureProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGridView)).BeginInit();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelNavigator);
            this.panelBottom.Controls.Add(this.panelFormActions);
            this.panelBottom.Controls.Add(this.panelEntityActions);
            this.panelBottom.Controls.Add(this.label2);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // panelNavigator
            // 
            this.panelNavigator.Controls.Add(this.textBoxPageNumber);
            this.panelNavigator.Controls.Add(this.buttonNext);
            this.panelNavigator.Controls.Add(this.buttonPrev);
            resources.ApplyResources(this.panelNavigator, "panelNavigator");
            this.panelNavigator.Name = "panelNavigator";
            // 
            // textBoxPageNumber
            // 
            resources.ApplyResources(this.textBoxPageNumber, "textBoxPageNumber");
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            // 
            // buttonNext
            // 
            resources.ApplyResources(this.buttonNext, "buttonNext");
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            resources.ApplyResources(this.buttonPrev, "buttonPrev");
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
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
            this.panelEntityActions.Controls.Add(this.labelTotalRecords);
            this.panelEntityActions.Controls.Add(this.buttonEdit);
            this.panelEntityActions.Controls.Add(this.buttonDelete);
            resources.ApplyResources(this.panelEntityActions, "panelEntityActions");
            this.panelEntityActions.Name = "panelEntityActions";
            // 
            // labelTotalRecords
            // 
            resources.ApplyResources(this.labelTotalRecords, "labelTotalRecords");
            this.labelTotalRecords.Name = "labelTotalRecords";
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Name = "label2";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            // panelFilter
            // 
            resources.ApplyResources(this.panelFilter, "panelFilter");
            this.panelFilter.Name = "panelFilter";
            // 
            // panelCriteria
            // 
            this.panelCriteria.Controls.Add(this.buttonSearch);
            resources.ApplyResources(this.panelCriteria, "panelCriteria");
            this.panelCriteria.Name = "panelCriteria";
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelSearchButton
            // 
            this.panelSearchButton.Controls.Add(this.panelKeyword);
            this.panelSearchButton.Controls.Add(this.panelNew);
            this.panelSearchButton.Controls.Add(this.panelCriteria);
            resources.ApplyResources(this.panelSearchButton, "panelSearchButton");
            this.panelSearchButton.Name = "panelSearchButton";
            // 
            // panelKeyword
            // 
            this.panelKeyword.Controls.Add(this.textBoxKeyword);
            resources.ApplyResources(this.panelKeyword, "panelKeyword");
            this.panelKeyword.Name = "panelKeyword";
            // 
            // textBoxKeyword
            // 
            resources.ApplyResources(this.textBoxKeyword, "textBoxKeyword");
            this.textBoxKeyword.Name = "textBoxKeyword";
            // 
            // panelNew
            // 
            this.panelNew.Controls.Add(this.buttonAdd);
            resources.ApplyResources(this.panelNew, "panelNew");
            this.panelNew.Name = "panelNew";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label3, "label3");
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Name = "label3";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelPictureProcessing);
            this.panelTop.Controls.Add(this.panelTitle);
            this.panelTop.Controls.Add(this.label1);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // panelPictureProcessing
            // 
            this.panelPictureProcessing.BackColor = System.Drawing.Color.Transparent;
            this.panelPictureProcessing.Controls.Add(this.pictureBoxLogo);
            resources.ApplyResources(this.panelPictureProcessing, "panelPictureProcessing");
            this.panelPictureProcessing.Name = "panelPictureProcessing";
            // 
            // pictureBoxLogo
            // 
            resources.ApplyResources(this.pictureBoxLogo, "pictureBoxLogo");
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTitle
            // 
            resources.ApplyResources(this.panelTitle, "panelTitle");
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.labelBusinessName);
            this.panelTitle.Controls.Add(this.labelFormTitle);
            this.panelTitle.Name = "panelTitle";
            // 
            // labelBusinessName
            // 
            resources.ApplyResources(this.labelBusinessName, "labelBusinessName");
            this.labelBusinessName.Name = "labelBusinessName";
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
            // panelFill
            // 
            this.panelFill.Controls.Add(this.dataGridViewProducts);
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Name = "panelFill";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoGenerateColumns = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.legalCodeDataGridViewTextBoxColumn,
            this.productYearDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn});
            this.dataGridViewProducts.DataSource = this.bindingSourceGridView;
            resources.ApplyResources(this.dataGridViewProducts, "dataGridViewProducts");
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            // 
            // uIDDataGridViewTextBoxColumn
            // 
            this.uIDDataGridViewTextBoxColumn.DataPropertyName = "UID";
            this.uIDDataGridViewTextBoxColumn.HeaderText = "UID";
            this.uIDDataGridViewTextBoxColumn.Name = "uIDDataGridViewTextBoxColumn";
            this.uIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // legalCodeDataGridViewTextBoxColumn
            // 
            this.legalCodeDataGridViewTextBoxColumn.DataPropertyName = "LegalCode";
            this.legalCodeDataGridViewTextBoxColumn.HeaderText = "LegalCode";
            this.legalCodeDataGridViewTextBoxColumn.Name = "legalCodeDataGridViewTextBoxColumn";
            this.legalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productYearDataGridViewTextBoxColumn
            // 
            this.productYearDataGridViewTextBoxColumn.DataPropertyName = "ProductYear";
            this.productYearDataGridViewTextBoxColumn.HeaderText = "ProductYear";
            this.productYearDataGridViewTextBoxColumn.Name = "productYearDataGridViewTextBoxColumn";
            this.productYearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormManageProducts
            // 
            this.AcceptButton = this.buttonSearch;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelSearchButton);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusBar);
            this.KeyPreview = true;
            this.Name = "FormManageProducts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManageProducts_FormClosing);
            this.Load += new System.EventHandler(this.FormManageProducts_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            this.panelNavigator.PerformLayout();
            this.panelFormActions.ResumeLayout(false);
            this.panelEntityActions.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panelCriteria.ResumeLayout(false);
            this.panelSearchButton.ResumeLayout(false);
            this.panelKeyword.ResumeLayout(false);
            this.panelKeyword.PerformLayout();
            this.panelNew.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelPictureProcessing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGridView)).EndInit();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panelBottom;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitle;
        protected System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Panel panelPictureProcessing;
        private System.Windows.Forms.Panel panelEntityActions;
        protected System.Windows.Forms.Button buttonAdd;
        protected System.Windows.Forms.Panel panelFormActions;
        protected System.Windows.Forms.Button buttonClose;
        protected System.Windows.Forms.Button buttonDelete;
        protected System.Windows.Forms.Panel panelFilter;
        protected System.Windows.Forms.Button buttonSearch;
        protected System.Windows.Forms.Panel panelCriteria;
        protected System.Windows.Forms.Panel panelSearchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        protected System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel panelKeyword;
        private System.Windows.Forms.Panel panelNew;
        public System.Windows.Forms.TextBox textBoxKeyword;
        protected System.Windows.Forms.ToolStripProgressBar toolStripProgressBarForm;
        protected System.Windows.Forms.BindingSource bindingSourceGridView;
        protected System.Windows.Forms.Button buttonCancel;
        protected System.Windows.Forms.Label labelBusinessName;
        private System.Windows.Forms.Label labelTotalRecords;
        protected System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn uIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn legalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.TextBox textBoxPageNumber;
    }
}

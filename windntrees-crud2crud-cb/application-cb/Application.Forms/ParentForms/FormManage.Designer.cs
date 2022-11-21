namespace ApplicationForms.ParentForms
{
    partial class FormManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManage));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.bindingNavigatorForm = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSourceNavigator = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxListSize = new System.Windows.Forms.ToolStripComboBox();
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
            this.panelFill = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelSearchButton = new System.Windows.Forms.Panel();
            this.panelKeyword = new System.Windows.Forms.Panel();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.panelNew = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceGridView = new System.Windows.Forms.BindingSource(this.components);
            this.panelBottom.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorForm)).BeginInit();
            this.bindingNavigatorForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNavigator)).BeginInit();
            this.panelFormActions.SuspendLayout();
            this.panelEntityActions.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            this.panelSearchButton.SuspendLayout();
            this.panelKeyword.SuspendLayout();
            this.panelNew.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGridView)).BeginInit();
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
            this.panelNavigator.Controls.Add(this.bindingNavigatorForm);
            resources.ApplyResources(this.panelNavigator, "panelNavigator");
            this.panelNavigator.Name = "panelNavigator";
            // 
            // bindingNavigatorForm
            // 
            this.bindingNavigatorForm.AddNewItem = null;
            this.bindingNavigatorForm.BindingSource = this.bindingSourceNavigator;
            this.bindingNavigatorForm.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorForm.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigatorForm, "bindingNavigatorForm");
            this.bindingNavigatorForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigatorForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripComboBoxListSize});
            this.bindingNavigatorForm.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorForm.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorForm.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorForm.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorForm.Name = "bindingNavigatorForm";
            this.bindingNavigatorForm.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingSourceNavigator
            // 
            this.bindingSourceNavigator.DataSource = typeof(ApplicationForms.ParentForms.NavigatorItem);
            this.bindingSourceNavigator.PositionChanged += new System.EventHandler(this.bindingSourceNavigator_PositionChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // toolStripComboBoxListSize
            // 
            this.toolStripComboBoxListSize.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxListSize.Items"),
            resources.GetString("toolStripComboBoxListSize.Items1"),
            resources.GetString("toolStripComboBoxListSize.Items2"),
            resources.GetString("toolStripComboBoxListSize.Items3"),
            resources.GetString("toolStripComboBoxListSize.Items4"),
            resources.GetString("toolStripComboBoxListSize.Items5")});
            this.toolStripComboBoxListSize.Name = "toolStripComboBoxListSize";
            resources.ApplyResources(this.toolStripComboBoxListSize, "toolStripComboBoxListSize");
            this.toolStripComboBoxListSize.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxListSize_SelectedIndexChanged);
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
            this.buttonEdit.Click += new System.EventHandler(this.buttonUpdate_Click);
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
            // panelFill
            // 
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Name = "panelFill";
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
            // FormManage
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
            this.Name = "FormManage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManager_FormClosing);
            this.Load += new System.EventHandler(this.FormManager_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            this.panelNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorForm)).EndInit();
            this.bindingNavigatorForm.ResumeLayout(false);
            this.bindingNavigatorForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNavigator)).EndInit();
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
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGridView)).EndInit();
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
        protected System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel panelKeyword;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panelNew;
        public System.Windows.Forms.TextBox textBoxKeyword;
        protected System.Windows.Forms.BindingNavigator bindingNavigatorForm;
        protected System.Windows.Forms.BindingSource bindingSourceNavigator;
        protected System.Windows.Forms.ToolStripProgressBar toolStripProgressBarForm;
        protected System.Windows.Forms.BindingSource bindingSourceGridView;
        protected System.Windows.Forms.ToolStripComboBox toolStripComboBoxListSize;
        protected System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTotalRecords;
    }
}
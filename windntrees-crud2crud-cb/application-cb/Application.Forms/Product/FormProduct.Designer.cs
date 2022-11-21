namespace ApplicationForms.Product
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.textBoxLegalCode = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.textBoxManufacturer = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelFormActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEntity)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 457);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Size = new System.Drawing.Size(622, 52);
            // 
            // panelTop
            // 
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Size = new System.Drawing.Size(622, 70);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tableLayoutPanel1);
            this.panelFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelFill.Size = new System.Drawing.Size(622, 387);
            // 
            // panelFormActions
            // 
            this.panelFormActions.Location = new System.Drawing.Point(451, 2);
            this.panelFormActions.Margin = new System.Windows.Forms.Padding(2);
            // 
            // bindingSourceEntity
            // 
            this.bindingSourceEntity.DataSource = typeof(Application.Models.Standard.DataAccess.Product);
            // 
            // panelFormActionsMiddle
            // 
            this.panelFormActionsMiddle.Size = new System.Drawing.Size(361, 50);
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
            this.tableLayoutPanel1.Controls.Add(this.textBoxYear, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxVersion, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLegalCode, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColor, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUnit, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxManufacturer, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCategory, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCode, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDescription, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label19, 3, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 387);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "ProductYear", true));
            this.textBoxYear.Location = new System.Drawing.Point(399, 207);
            this.textBoxYear.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxYear.MaxLength = 100;
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(157, 20);
            this.textBoxYear.TabIndex = 19;
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Version", true));
            this.textBoxVersion.Location = new System.Drawing.Point(151, 207);
            this.textBoxVersion.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxVersion.MaxLength = 100;
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(157, 20);
            this.textBoxVersion.TabIndex = 17;
            // 
            // textBoxLegalCode
            // 
            this.textBoxLegalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLegalCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "LegalCode", true));
            this.textBoxLegalCode.Location = new System.Drawing.Point(399, 178);
            this.textBoxLegalCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLegalCode.MaxLength = 100;
            this.textBoxLegalCode.Name = "textBoxLegalCode";
            this.textBoxLegalCode.Size = new System.Drawing.Size(157, 20);
            this.textBoxLegalCode.TabIndex = 15;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxColor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Color", true));
            this.textBoxColor.Location = new System.Drawing.Point(399, 149);
            this.textBoxColor.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxColor.MaxLength = 100;
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(157, 20);
            this.textBoxColor.TabIndex = 11;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUnit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Unit", true));
            this.textBoxUnit.Location = new System.Drawing.Point(151, 149);
            this.textBoxUnit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUnit.MaxLength = 100;
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(157, 20);
            this.textBoxUnit.TabIndex = 9;
            // 
            // textBoxManufacturer
            // 
            this.textBoxManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxManufacturer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Manufacturer", true));
            this.textBoxManufacturer.Location = new System.Drawing.Point(399, 120);
            this.textBoxManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManufacturer.MaxLength = 100;
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.Size = new System.Drawing.Size(157, 20);
            this.textBoxManufacturer.TabIndex = 7;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Category", true));
            this.textBoxCategory.Location = new System.Drawing.Point(151, 120);
            this.textBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCategory.MaxLength = 100;
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(157, 20);
            this.textBoxCategory.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxName, 3);
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Name", true));
            this.textBoxName.Location = new System.Drawing.Point(151, 33);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.MaxLength = 100;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(405, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 210);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Version";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(312, 210);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Year";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Code";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Code", true));
            this.textBoxCode.Location = new System.Drawing.Point(151, 178);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCode.MaxLength = 100;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(157, 20);
            this.textBoxCode.TabIndex = 13;
            this.textBoxCode.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCode_Validating);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Category";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Manufacturer";
            // 
            // textBoxDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxDescription, 3);
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceEntity, "Description", true));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(151, 60);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.MaxLength = 200;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.tableLayoutPanel1.SetRowSpan(this.textBoxDescription, 2);
            this.textBoxDescription.Size = new System.Drawing.Size(405, 54);
            this.textBoxDescription.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(64, 152);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 15);
            this.label18.TabIndex = 8;
            this.label18.Text = "Unit";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(312, 152);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Color";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(312, 181);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 15);
            this.label19.TabIndex = 14;
            this.label19.Text = "Legal Code";
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(622, 531);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormProduct";
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFormActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEntity)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxLegalCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.TextBox textBoxYear;
    }
}

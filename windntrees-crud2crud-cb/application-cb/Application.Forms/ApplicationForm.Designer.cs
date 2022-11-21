namespace ApplicationForms
{
    partial class ApplicationForm
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
            this.panelHeading = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonScoreCBForm = new System.Windows.Forms.Button();
            this.panelHeading.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.label3);
            this.panelHeading.Controls.Add(this.label2);
            this.panelHeading.Controls.Add(this.label1);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(800, 70);
            this.panelHeading.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(800, 1);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(767, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application form implements CRUD2CRUD (CRUDS) controller to controller communicat" +
    "ion pattern that simplifies invocation of action and optional target methods.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Form (CRUD2CRUD, CRUDS)";
            // 
            // buttonProducts
            // 
            this.buttonProducts.Location = new System.Drawing.Point(12, 111);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(122, 23);
            this.buttonProducts.TabIndex = 1;
            this.buttonProducts.Text = "Manage Products";
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Press button to open products manager form.";
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.label5);
            this.panelFooter.Controls.Add(this.buttonClose);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 380);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(800, 70);
            this.panelFooter.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Visit www.invincibletec.com website to learn CRUD2CRUD programming.";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(713, 35);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Press button to open score cb (callback) crud2crud form.";
            // 
            // buttonScoreCBForm
            // 
            this.buttonScoreCBForm.Location = new System.Drawing.Point(12, 140);
            this.buttonScoreCBForm.Name = "buttonScoreCBForm";
            this.buttonScoreCBForm.Size = new System.Drawing.Size(122, 23);
            this.buttonScoreCBForm.TabIndex = 4;
            this.buttonScoreCBForm.Text = "Score CB";
            this.buttonScoreCBForm.UseVisualStyleBackColor = true;
            this.buttonScoreCBForm.Click += new System.EventHandler(this.buttonScoreCBForm_Click);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonScoreCBForm);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.panelHeading);
            this.Name = "ApplicationForm";
            this.Text = "Application Form (CRUD2CRUD, CRUDS)";
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonScoreCBForm;
    }
}



namespace ApplicationForms.Core.Score
{
    partial class FormScoreCRUD2CRUDCB
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitleCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanelScores = new System.Windows.Forms.TableLayoutPanel();
            this.panelScore1 = new System.Windows.Forms.Panel();
            this.panelScore2 = new System.Windows.Forms.Panel();
            this.panelScore3 = new System.Windows.Forms.Panel();
            this.panelScore4 = new System.Windows.Forms.Panel();
            this.labelScore1 = new System.Windows.Forms.Label();
            this.labelCaption1 = new System.Windows.Forms.Label();
            this.labelCaption2 = new System.Windows.Forms.Label();
            this.labelScore2 = new System.Windows.Forms.Label();
            this.labelCaption3 = new System.Windows.Forms.Label();
            this.labelScore3 = new System.Windows.Forms.Label();
            this.labelCaption4 = new System.Windows.Forms.Label();
            this.labelScore4 = new System.Windows.Forms.Label();
            this.buttonSubscribe1 = new System.Windows.Forms.Button();
            this.buttonUnsubscribe1 = new System.Windows.Forms.Button();
            this.buttonUnsubscribe2 = new System.Windows.Forms.Button();
            this.buttonSubscribe2 = new System.Windows.Forms.Button();
            this.buttonUnsubscribe3 = new System.Windows.Forms.Button();
            this.buttonSubscribe3 = new System.Windows.Forms.Button();
            this.buttonUnsubscribe4 = new System.Windows.Forms.Button();
            this.buttonSubscribe4 = new System.Windows.Forms.Button();
            this.buttonUnSubscribeAll = new System.Windows.Forms.Button();
            this.buttonSubscribeAll = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tableLayoutPanelScores.SuspendLayout();
            this.panelScore1.SuspendLayout();
            this.panelScore2.SuspendLayout();
            this.panelScore3.SuspendLayout();
            this.panelScore4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelTitleCaption);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.buttonCancel);
            this.panelFooter.Controls.Add(this.buttonClose);
            this.panelFooter.Controls.Add(this.buttonUnSubscribeAll);
            this.panelFooter.Controls.Add(this.buttonSubscribeAll);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 410);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(800, 40);
            this.panelFooter.TabIndex = 1;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tableLayoutPanelScores);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 70);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(800, 340);
            this.panelFill.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(13, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(501, 27);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "CRUD2CRUD CB (Callback) Repository Form";
            // 
            // labelTitleCaption
            // 
            this.labelTitleCaption.AutoSize = true;
            this.labelTitleCaption.Location = new System.Drawing.Point(18, 40);
            this.labelTitleCaption.Name = "labelTitleCaption";
            this.labelTitleCaption.Size = new System.Drawing.Size(876, 14);
            this.labelTitleCaption.TabIndex = 1;
            this.labelTitleCaption.Text = "CRUD2CRUD Callback (CB) repository forms callback channel  crud2crud interface be" +
    "tween server and client. Client side repository methods scale using CRUDM.";
            // 
            // tableLayoutPanelScores
            // 
            this.tableLayoutPanelScores.ColumnCount = 2;
            this.tableLayoutPanelScores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScores.Controls.Add(this.panelScore1, 0, 0);
            this.tableLayoutPanelScores.Controls.Add(this.panelScore2, 1, 0);
            this.tableLayoutPanelScores.Controls.Add(this.panelScore3, 0, 1);
            this.tableLayoutPanelScores.Controls.Add(this.panelScore4, 1, 1);
            this.tableLayoutPanelScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScores.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelScores.Name = "tableLayoutPanelScores";
            this.tableLayoutPanelScores.RowCount = 2;
            this.tableLayoutPanelScores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScores.Size = new System.Drawing.Size(800, 340);
            this.tableLayoutPanelScores.TabIndex = 0;
            // 
            // panelScore1
            // 
            this.panelScore1.Controls.Add(this.buttonUnsubscribe1);
            this.panelScore1.Controls.Add(this.buttonSubscribe1);
            this.panelScore1.Controls.Add(this.labelCaption1);
            this.panelScore1.Controls.Add(this.labelScore1);
            this.panelScore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore1.Location = new System.Drawing.Point(3, 3);
            this.panelScore1.Name = "panelScore1";
            this.panelScore1.Size = new System.Drawing.Size(394, 164);
            this.panelScore1.TabIndex = 0;
            // 
            // panelScore2
            // 
            this.panelScore2.Controls.Add(this.buttonUnsubscribe2);
            this.panelScore2.Controls.Add(this.buttonSubscribe2);
            this.panelScore2.Controls.Add(this.labelCaption2);
            this.panelScore2.Controls.Add(this.labelScore2);
            this.panelScore2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore2.Location = new System.Drawing.Point(403, 3);
            this.panelScore2.Name = "panelScore2";
            this.panelScore2.Size = new System.Drawing.Size(394, 164);
            this.panelScore2.TabIndex = 1;
            // 
            // panelScore3
            // 
            this.panelScore3.Controls.Add(this.buttonUnsubscribe3);
            this.panelScore3.Controls.Add(this.buttonSubscribe3);
            this.panelScore3.Controls.Add(this.labelCaption3);
            this.panelScore3.Controls.Add(this.labelScore3);
            this.panelScore3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore3.Location = new System.Drawing.Point(3, 173);
            this.panelScore3.Name = "panelScore3";
            this.panelScore3.Size = new System.Drawing.Size(394, 164);
            this.panelScore3.TabIndex = 2;
            // 
            // panelScore4
            // 
            this.panelScore4.Controls.Add(this.buttonUnsubscribe4);
            this.panelScore4.Controls.Add(this.buttonSubscribe4);
            this.panelScore4.Controls.Add(this.labelCaption4);
            this.panelScore4.Controls.Add(this.labelScore4);
            this.panelScore4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore4.Location = new System.Drawing.Point(403, 173);
            this.panelScore4.Name = "panelScore4";
            this.panelScore4.Size = new System.Drawing.Size(394, 164);
            this.panelScore4.TabIndex = 3;
            // 
            // labelScore1
            // 
            this.labelScore1.AutoSize = true;
            this.labelScore1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore1.Location = new System.Drawing.Point(15, 4);
            this.labelScore1.Name = "labelScore1";
            this.labelScore1.Size = new System.Drawing.Size(37, 39);
            this.labelScore1.TabIndex = 0;
            this.labelScore1.Text = "0";
            // 
            // labelCaption1
            // 
            this.labelCaption1.AutoSize = true;
            this.labelCaption1.Location = new System.Drawing.Point(23, 47);
            this.labelCaption1.Name = "labelCaption1";
            this.labelCaption1.Size = new System.Drawing.Size(85, 14);
            this.labelCaption1.TabIndex = 1;
            this.labelCaption1.Text = "Disconnected.";
            // 
            // labelCaption2
            // 
            this.labelCaption2.AutoSize = true;
            this.labelCaption2.Location = new System.Drawing.Point(23, 47);
            this.labelCaption2.Name = "labelCaption2";
            this.labelCaption2.Size = new System.Drawing.Size(85, 14);
            this.labelCaption2.TabIndex = 3;
            this.labelCaption2.Text = "Disconnected.";
            // 
            // labelScore2
            // 
            this.labelScore2.AutoSize = true;
            this.labelScore2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore2.Location = new System.Drawing.Point(15, 4);
            this.labelScore2.Name = "labelScore2";
            this.labelScore2.Size = new System.Drawing.Size(37, 39);
            this.labelScore2.TabIndex = 2;
            this.labelScore2.Text = "0";
            // 
            // labelCaption3
            // 
            this.labelCaption3.AutoSize = true;
            this.labelCaption3.Location = new System.Drawing.Point(23, 53);
            this.labelCaption3.Name = "labelCaption3";
            this.labelCaption3.Size = new System.Drawing.Size(85, 14);
            this.labelCaption3.TabIndex = 5;
            this.labelCaption3.Text = "Disconnected.";
            // 
            // labelScore3
            // 
            this.labelScore3.AutoSize = true;
            this.labelScore3.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore3.Location = new System.Drawing.Point(15, 10);
            this.labelScore3.Name = "labelScore3";
            this.labelScore3.Size = new System.Drawing.Size(37, 39);
            this.labelScore3.TabIndex = 4;
            this.labelScore3.Text = "0";
            // 
            // labelCaption4
            // 
            this.labelCaption4.AutoSize = true;
            this.labelCaption4.Location = new System.Drawing.Point(23, 53);
            this.labelCaption4.Name = "labelCaption4";
            this.labelCaption4.Size = new System.Drawing.Size(85, 14);
            this.labelCaption4.TabIndex = 5;
            this.labelCaption4.Text = "Disconnected.";
            // 
            // labelScore4
            // 
            this.labelScore4.AutoSize = true;
            this.labelScore4.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore4.Location = new System.Drawing.Point(15, 10);
            this.labelScore4.Name = "labelScore4";
            this.labelScore4.Size = new System.Drawing.Size(37, 39);
            this.labelScore4.TabIndex = 4;
            this.labelScore4.Text = "0";
            // 
            // buttonSubscribe1
            // 
            this.buttonSubscribe1.Location = new System.Drawing.Point(23, 137);
            this.buttonSubscribe1.Name = "buttonSubscribe1";
            this.buttonSubscribe1.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe1.TabIndex = 2;
            this.buttonSubscribe1.Text = "Subscribe";
            this.buttonSubscribe1.UseVisualStyleBackColor = true;
            this.buttonSubscribe1.Click += new System.EventHandler(this.buttonSubscribe1_Click);
            // 
            // buttonUnsubscribe1
            // 
            this.buttonUnsubscribe1.Location = new System.Drawing.Point(104, 137);
            this.buttonUnsubscribe1.Name = "buttonUnsubscribe1";
            this.buttonUnsubscribe1.Size = new System.Drawing.Size(84, 23);
            this.buttonUnsubscribe1.TabIndex = 3;
            this.buttonUnsubscribe1.Text = "UnSubscribe";
            this.buttonUnsubscribe1.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe1.Click += new System.EventHandler(this.buttonUnsubscribe1_Click);
            // 
            // buttonUnsubscribe2
            // 
            this.buttonUnsubscribe2.Location = new System.Drawing.Point(104, 137);
            this.buttonUnsubscribe2.Name = "buttonUnsubscribe2";
            this.buttonUnsubscribe2.Size = new System.Drawing.Size(84, 23);
            this.buttonUnsubscribe2.TabIndex = 5;
            this.buttonUnsubscribe2.Text = "UnSubscribe";
            this.buttonUnsubscribe2.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe2.Click += new System.EventHandler(this.buttonUnsubscribe2_Click);
            // 
            // buttonSubscribe2
            // 
            this.buttonSubscribe2.Location = new System.Drawing.Point(23, 137);
            this.buttonSubscribe2.Name = "buttonSubscribe2";
            this.buttonSubscribe2.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe2.TabIndex = 4;
            this.buttonSubscribe2.Text = "Subscribe";
            this.buttonSubscribe2.UseVisualStyleBackColor = true;
            this.buttonSubscribe2.Click += new System.EventHandler(this.buttonSubscribe2_Click);
            // 
            // buttonUnsubscribe3
            // 
            this.buttonUnsubscribe3.Location = new System.Drawing.Point(104, 138);
            this.buttonUnsubscribe3.Name = "buttonUnsubscribe3";
            this.buttonUnsubscribe3.Size = new System.Drawing.Size(84, 23);
            this.buttonUnsubscribe3.TabIndex = 7;
            this.buttonUnsubscribe3.Text = "UnSubscribe";
            this.buttonUnsubscribe3.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe3.Click += new System.EventHandler(this.buttonUnsubscribe3_Click);
            // 
            // buttonSubscribe3
            // 
            this.buttonSubscribe3.Location = new System.Drawing.Point(23, 138);
            this.buttonSubscribe3.Name = "buttonSubscribe3";
            this.buttonSubscribe3.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe3.TabIndex = 6;
            this.buttonSubscribe3.Text = "Subscribe";
            this.buttonSubscribe3.UseVisualStyleBackColor = true;
            this.buttonSubscribe3.Click += new System.EventHandler(this.buttonSubscribe3_Click);
            // 
            // buttonUnsubscribe4
            // 
            this.buttonUnsubscribe4.Location = new System.Drawing.Point(104, 138);
            this.buttonUnsubscribe4.Name = "buttonUnsubscribe4";
            this.buttonUnsubscribe4.Size = new System.Drawing.Size(84, 23);
            this.buttonUnsubscribe4.TabIndex = 7;
            this.buttonUnsubscribe4.Text = "UnSubscribe";
            this.buttonUnsubscribe4.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe4.Click += new System.EventHandler(this.buttonUnsubscribe4_Click);
            // 
            // buttonSubscribe4
            // 
            this.buttonSubscribe4.Location = new System.Drawing.Point(23, 138);
            this.buttonSubscribe4.Name = "buttonSubscribe4";
            this.buttonSubscribe4.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe4.TabIndex = 6;
            this.buttonSubscribe4.Text = "Subscribe";
            this.buttonSubscribe4.UseVisualStyleBackColor = true;
            this.buttonSubscribe4.Click += new System.EventHandler(this.buttonSubscribe4_Click);
            // 
            // buttonUnSubscribeAll
            // 
            this.buttonUnSubscribeAll.Location = new System.Drawing.Point(107, 10);
            this.buttonUnSubscribeAll.Name = "buttonUnSubscribeAll";
            this.buttonUnSubscribeAll.Size = new System.Drawing.Size(84, 23);
            this.buttonUnSubscribeAll.TabIndex = 5;
            this.buttonUnSubscribeAll.Text = "UnSubscribe";
            this.buttonUnSubscribeAll.UseVisualStyleBackColor = true;
            this.buttonUnSubscribeAll.Click += new System.EventHandler(this.buttonUnSubscribeAll_Click);
            // 
            // buttonSubscribeAll
            // 
            this.buttonSubscribeAll.Location = new System.Drawing.Point(26, 10);
            this.buttonSubscribeAll.Name = "buttonSubscribeAll";
            this.buttonSubscribeAll.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribeAll.TabIndex = 4;
            this.buttonSubscribeAll.Text = "Subscribe";
            this.buttonSubscribeAll.UseVisualStyleBackColor = true;
            this.buttonSubscribeAll.Click += new System.EventHandler(this.buttonSubscribeAll_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(713, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(632, 9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormScoreCRUD2CRUDCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormScoreCRUD2CRUDCB";
            this.Text = "FormScoreCRUD2CRUDCB";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.tableLayoutPanelScores.ResumeLayout(false);
            this.panelScore1.ResumeLayout(false);
            this.panelScore1.PerformLayout();
            this.panelScore2.ResumeLayout(false);
            this.panelScore2.PerformLayout();
            this.panelScore3.ResumeLayout(false);
            this.panelScore3.PerformLayout();
            this.panelScore4.ResumeLayout(false);
            this.panelScore4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTitleCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScores;
        private System.Windows.Forms.Panel panelScore1;
        private System.Windows.Forms.Panel panelScore2;
        private System.Windows.Forms.Panel panelScore3;
        private System.Windows.Forms.Panel panelScore4;
        private System.Windows.Forms.Label labelScore1;
        private System.Windows.Forms.Label labelCaption1;
        private System.Windows.Forms.Label labelCaption2;
        private System.Windows.Forms.Label labelScore2;
        private System.Windows.Forms.Label labelCaption3;
        private System.Windows.Forms.Label labelScore3;
        private System.Windows.Forms.Label labelCaption4;
        private System.Windows.Forms.Label labelScore4;
        private System.Windows.Forms.Button buttonUnsubscribe1;
        private System.Windows.Forms.Button buttonSubscribe1;
        private System.Windows.Forms.Button buttonUnsubscribe2;
        private System.Windows.Forms.Button buttonSubscribe2;
        private System.Windows.Forms.Button buttonUnsubscribe3;
        private System.Windows.Forms.Button buttonSubscribe3;
        private System.Windows.Forms.Button buttonUnsubscribe4;
        private System.Windows.Forms.Button buttonSubscribe4;
        private System.Windows.Forms.Button buttonUnSubscribeAll;
        private System.Windows.Forms.Button buttonSubscribeAll;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
    }
}
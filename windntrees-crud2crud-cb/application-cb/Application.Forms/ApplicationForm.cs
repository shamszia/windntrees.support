using ApplicationForms.Product;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationForms
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayProductsForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(DisplayProductsForm));
            }
            else
            {
                FormManageProducts formManageProducts = new FormManageProducts();
                formManageProducts.Show();
            }
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            DisplayProductsForm();
        }

        private void DisplayScoreCBForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(DisplayScoreCBForm));
            }
            else
            {
                ApplicationForms.Score.FormScoreCRUD2CRUDCB formScore = new ApplicationForms.Score.FormScoreCRUD2CRUDCB();
                formScore.Show();
            }
        }

        private void buttonScoreCBForm_Click(object sender, EventArgs e)
        {
            DisplayScoreCBForm();
        }
    }
}

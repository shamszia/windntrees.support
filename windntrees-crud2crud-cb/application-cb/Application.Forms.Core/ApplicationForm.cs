using ApplicationForms.Core.Product;
using System;
using System.Windows.Forms;

namespace ApplicationForms.Core
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

        private void DisplayScoreForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(DisplayScoreForm));
            }
            else
            {
                Score.FormScoreCRUD2CRUDCB formScore = new Score.FormScoreCRUD2CRUDCB();
                formScore.Show();
            }
        }

        private void buttonScoreCB_Click(object sender, EventArgs e)
        {
            DisplayScoreForm();
        }
    }
}

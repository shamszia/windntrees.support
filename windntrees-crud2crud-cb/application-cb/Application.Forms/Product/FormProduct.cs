using ApplicationForms.ParentForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using WindnTrees.ICRUDS;

namespace ApplicationForms.Product
{
    public partial class FormProduct : ApplicationForms.ParentForms.FormEntity
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        public FormProduct(string title, EntityPersistanceState entityPersistanceState = EntityPersistanceState.Create)
            : base(title, entityPersistanceState)
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(ResetForm));
            }
            else
            {
                textBoxName.Text = "";
                
                textBoxDescription.Text = "";
                textBoxCode.Text = "";
                
                textBoxName.Focus();
            }
        }

        private bool ValidateForm()
        {
            textBoxName.Focus();
            textBoxCode.Focus();
            buttonSave.Focus();

            if (string.IsNullOrEmpty(errorProviderEntity.GetError(textBoxName)))
            {
                return true;
            }

            return false;
        }

        protected override void Save()
        {
            if (ValidateForm())
            {
                base.Save();
            }
            else
            {
                MessageBox.Show("Enter (select) correct input data to proceed.", StandardMessages.DefaultMsgBoxCaption, MessageBoxButtons.OK);
            }
        }

        public override void Reset()
        {
            ResetForm();
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                errorProviderEntity.SetError(textBoxName, "Enter name here.");
            }
            else
            {
                errorProviderEntity.SetError(textBoxName, "");
            }
        }

        private void textBoxCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCode.Text))
            {
                errorProviderEntity.SetError(textBoxCode, "Enter code here.");
            }
            else
            {
                errorProviderEntity.SetError(textBoxCode, "");
            }
        }

        private void linkLabelSelectPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
using ApplicationForms.ParentForms;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using WindnTrees.ICRUDS;

namespace ApplicationForms.Product
{
    public partial class FormManageProducts : ApplicationForms.ParentForms.FormManage
    {
        private FormProduct form = null;

        public FormManageProducts()
        {
            InitializeComponent();
        }

        public FormManageProducts(string keyword = null)
        {
            InitializeComponent();

            textBoxKeyword.Text = keyword;
        }

        #region GetServiceAddress
        /// <summary>
        /// Gets service address.
        /// </summary>
        /// <returns></returns>
        public string GetServiceAddress(string relatedAddress)
        {
            return string.Format("net.tcp://{0}:{1}/{2}", ConfigurationManager.AppSettings["IPAddress"], ConfigurationManager.AppSettings["TCPPort"], relatedAddress);
        }
        #endregion

        #region ProductServiceClient
        private WCFServiceClient<Application.Models.Standard.DataAccess.Product> m_ProductServiceClient = null;
        /// <summary>
        /// Product service client.
        /// </summary>
        private WCFServiceClient<Application.Models.Standard.DataAccess.Product> ProductServiceClient
        {
            get
            {
                if (m_ProductServiceClient == null)
                {
                    m_ProductServiceClient = new WCFServiceClient<Application.Models.Standard.DataAccess.Product>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Product>.GetTcpWCFChannelFactory(GetServiceAddress("product")));
                    m_ProductServiceClient.OnMessage += M_ProductServiceClient_OnMessage;
                    m_ProductServiceClient.OnObject += M_ProductServiceClient_OnObject;
                    m_ProductServiceClient.OnContentObject += M_ProductServiceClient_OnContentObject;
                    m_ProductServiceClient.OnContentObjectList += M_ProductServiceClient_OnContentObjectList;
                }
                return m_ProductServiceClient;
            }
        }

        private void M_ProductServiceClient_OnMessage(object message)
        {
            DisplayStatus(message);

            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    form.DisplayStatus(message);
                }
            }
        }

        private void M_ProductServiceClient_OnObject(object contentObject, MethodEventArgs eventArgs)
        {
            if (eventArgs.Exception)
            {
                DisplayStatus(new ActionMessage { Message = string.Format("Error occured while saving or processing data. {0}", eventArgs.ExceptionMessage), MethodType = eventArgs.MethodType });
            }
            else
            {
                if (eventArgs.MethodType == MethodType.MethodSearchObjectAsync)
                {
                    if (eventArgs.MethodInput.Target.Equals("ListTotal"))
                    {
                        GenerateLists(contentObject);
                    }
                }
            }
        }

        private void M_ProductServiceClient_OnContentObjectList(List<Application.Models.Standard.DataAccess.Product> contentObjectList, MethodEventArgs eventArgs)
        {
            HideProcessing();
            UpdateList(contentObjectList.ToList<object>());
            DisplayStatus(new ActionMessage { Message = "Listed successfully.", MethodType = eventArgs.MethodType });
        }

        private void M_ProductServiceClient_OnContentObject(Application.Models.Standard.DataAccess.Product contentObject, MethodEventArgs eventArgs)
        {
            HideProcessing();
            if (eventArgs.Exception)
            {
                form.DisplayStatus(new ActionMessage { Message = string.Format("Failed: {0}", eventArgs.ExceptionMessage), MethodType = eventArgs.MethodType });
                DisplayStatus(new ActionMessage { Message = string.Format("Error occured while saving or processing data. {0}", eventArgs.ExceptionMessage), MethodType = eventArgs.MethodType });
            }
            else
            {
                if (eventArgs.MethodType == MethodType.CreateAsync)
                {
                    form.Reset();
                    DisplayStatus(new ActionMessage { Message = "Created successfully.", MethodType = eventArgs.MethodType });
                }
                else if (eventArgs.MethodType == MethodType.UpdateAsync)
                {
                    DisplayStatus(new ActionMessage { Message = "Updated successfully.", MethodType = eventArgs.MethodType });
                }
                else if (eventArgs.MethodType == MethodType.DeleteAsync)
                {   
                    DisplayStatus(new ActionMessage { Message = "Deleted successfully.", MethodType = eventArgs.MethodType });
                }

                UpdateGridView(eventArgs);
            }
        }

        protected override void OnFormClosing()
        {
            ProductServiceClient.FactoryService.Close();
        }
        #endregion

        #region CRUD2CRUD
        /// <summary>
        /// Implements create method of CRUD2CRUD ServiceClient API in product addition form.
        /// </summary>
        protected override void Add()
        {
            form = new FormProduct("Add Product");

            form.BindingSource.DataSource = new Application.Models.Standard.DataAccess.Product();
            form.OnSave += Form_OnSave;
            form.FormClosing += Form_FormClosing;
            form.Show();
        }

        /// <summary>
        /// Implements update method of CRUD2CRUD ServiceClient API in product editing form.
        /// </summary>
        protected override void Edit()
        {
            if (dataGridViewProducts.CurrentRow.Index >= 0)
            {
                Application.Models.Standard.DataAccess.Product product = (Application.Models.Standard.DataAccess.Product)dataGridViewProducts.CurrentRow.DataBoundItem;
                form = new FormProduct("Edit Product", EntityPersistanceState.Edit);
                form.BindingSource.DataSource = product;
                form.OnSave += Form_OnSave;
                form.FormClosing += Form_FormClosing;
                form.Show();
            }
        }

        /// <summary>
        /// Implements delete method of CRUD2CRUD ServiceClient API.
        /// </summary>
        protected override void Delete()
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                if (dataGridViewProducts.CurrentRow.Index >= 0)
                {
                    ShowProcessing();
                    DisplayStatus(new ActionMessage { Message = "Deleting ...", MethodType = MethodType.DeleteAsync });
                    ProductServiceClient.DeleteAsync((Application.Models.Standard.DataAccess.Product)dataGridViewProducts.CurrentRow.DataBoundItem);
                }
            }
        }

        /// <summary>
        /// Implements list method of CRUD2CRUD ServiceClient API.
        /// </summary>
        protected override void List()
        {
            ShowProcessing();
            DisplayStatus(new ActionMessage { Message = "Listing ...", MethodType = MethodType.ListAsync });
            ProductServiceClient.MethodSearchObjectAsync(new SearchInput { keyword = textBoxKeyword.Text, page = ListNumber, size = ListSize }, "ListTotal");
        }
        #endregion

        private void UpdateGridView(object methodEventArgs)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = methodEventArgs;
                BeginInvoke(new ObjectParamDelegate(UpdateGridView), arguments);
            }
            else
            {
                if (((MethodEventArgs)methodEventArgs).MethodType == MethodType.DeleteAsync)
                {
                    dataGridViewProducts.Rows.RemoveAt(dataGridViewProducts.CurrentRow.Index);
                }
            }
        }

        private void Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ((FormProduct)sender).OnSave -= Form_OnSave;
            ((Form)sender).FormClosing -= Form_FormClosing;
        }

        private void Form_OnSave(object entity, EntityPersistanceEventArgument eventArgument)
        {
            if (eventArgument.EntityPersistanceState == EntityPersistanceState.Create)
            {
                ShowProcessing();
                DisplayStatus(new ActionMessage { Message = "Creating ...", MethodType = MethodType.CreateAsync });
                ProductServiceClient.CreateAsync((Application.Models.Standard.DataAccess.Product)entity);
            }
            else if (eventArgument.EntityPersistanceState == EntityPersistanceState.Edit)
            {
                ShowProcessing();
                DisplayStatus(new ActionMessage { Message = "Updating ...", MethodType = MethodType.UpdateAsync });
                ProductServiceClient.UpdateAsync((Application.Models.Standard.DataAccess.Product)entity);
            }
        }

        protected override void FormManager_OnListChange(object listNumber)
        {
            ShowProcessing();
            DisplayStatus(new ActionMessage { Message = "Listing ...", MethodType = MethodType.ListAsync });
            ProductServiceClient.ListAsync(new SearchInput { keyword = textBoxKeyword.Text, page = (int)listNumber, size = ListSize });
        }

        protected override void FormManager_OnSizeChange(object listSize)
        {
            ShowProcessing();
            DisplayStatus(new ActionMessage { Message = "Calculating lists ...", MethodType = MethodType.MethodSearchObjectAsync });
            ProductServiceClient.MethodSearchObjectAsync(new SearchInput { keyword = textBoxKeyword.Text, page = ListNumber, size = ListSize }, "ListTotal");
        }

        private void FormManageProducts_Load(object sender, System.EventArgs e)
        {
            List();
        }

        private void DataGridViewProducts_RowHeaderMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NotifySelection(dataGridViewProducts.Rows[e.RowIndex].DataBoundItem);
            }
        }
    }
}
using Application.Models.Standard;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindnTrees.ICRUDS.Standard;

namespace ApplicationForms.Core.Product
{
    public partial class FormManageProducts : Form
    {
        private FormProduct entityForm = null;

        #region Data_Members
        /// <summary>
        /// Form's language code.
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// List number.
        /// </summary>
        public int ListNumber { get; set; }
        /// <summary>
        /// List size.
        /// </summary>
        public int ListSize { get; set; }

        protected event ObjectParamDelegate OnSizeChange = null;
        /// <summary>
        /// Notifies list size change event.
        /// </summary>
        /// <param name="size"></param>
        protected void NotifySizeChangeEvent(int size)
        {
            if (OnSizeChange != null)
            {
                OnSizeChange(size);
            }
        }

        protected event ObjectParamDelegate OnListChange = null;
        /// <summary>
        /// Notifies list change event.
        /// </summary>
        /// <param name="listNumber"></param>
        protected void NotifyListChangeEvent(int listNumber)
        {
            if (OnListChange != null)
            {
                OnListChange(listNumber);
            }
        }

        protected event NoParamDelegate OnDataLoad = null;
        /// <summary>
        /// Notifies data load event.
        /// </summary>
        protected void NotifyDataLoadEvent()
        {
            if (OnDataLoad != null)
            {
                OnDataLoad();
            }
        }

        public event ObjectParamDelegate OnSelect = null;
        /// <summary>
        /// Notifies selected record.
        /// </summary>
        /// <param name="selectedRecord"></param>
        protected void NotifySelection(object selectedRecord)
        {
            if (OnSelect != null)
            {
                OnSelect(selectedRecord);
            }
        }
        #endregion

        #region Constructors
        public FormManageProducts(string lang)
        {
            ListSize = 20;
            ListNumber = 1;
            LanguageCode = lang;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            InitializeComponent();
        }

        public FormManageProducts()
        {
            ListSize = 20;
            ListNumber = 1;

            InitializeComponent();
        }
        #endregion

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
                    m_ProductServiceClient = new WCFServiceClient<Application.Models.Standard.DataAccess.Product>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Product>.GetTcpWCFChannelAsyncFactory(GetServiceAddress("product")));
                }
                return m_ProductServiceClient;
            }
        }
        #endregion

        #region StatusReporter-Timer
        protected System.Timers.Timer m_TmrStatusReporter = null;
        protected void StartServerTimer()
        {
            try
            {
                if (m_TmrStatusReporter == null)
                    m_TmrStatusReporter = new System.Timers.Timer(1000);

                m_TmrStatusReporter.Elapsed += new System.Timers.ElapsedEventHandler(m_TmrStatusReporter_Elapsed);
                m_TmrStatusReporter.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", "Unable to start status reporter.", ex.Message), StandardMessages.DefaultMsgBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void m_TmrStatusReporter_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            if (m_RefreshStatus)
            {
                TimeSpan tSpan = DateTime.Now - m_StatusTime;
                if (((tSpan.Hours * 60 * 60) + (tSpan.Minutes * 60) + tSpan.Seconds) > m_RefreshingPeriodInSecs)
                {
                    SetStatus("Ready.");
                }
            }
        }
        protected void StopServerTimer()
        {
            try
            {
                if (m_TmrStatusReporter != null)
                {
                    m_TmrStatusReporter.Elapsed -= new System.Timers.ElapsedEventHandler(m_TmrStatusReporter_Elapsed);
                    m_TmrStatusReporter.Stop();
                    m_TmrStatusReporter = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", "Unable to stop status reporter.", ex.Message), StandardMessages.DefaultMsgBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected DateTime m_StatusTime = DateTime.Now;
        protected bool m_RefreshStatus = false;
        protected const int m_RefreshingPeriodInSecs = 5;
        protected void SetStatus(object status)
        {
            if (InvokeRequired)
            {
                object[] obj = new object[1];
                obj[0] = status;

                BeginInvoke(new ObjectParamDelegate(SetStatus), obj);
            }
            else
            {

                statusBarText.Text = (string)status;

                if (((string)status).ToUpper().Equals("READY."))
                {
                    m_RefreshStatus = false;
                }
                else
                {
                    m_RefreshStatus = true;
                    m_StatusTime = DateTime.Now;
                }
            }
        }
        #endregion

        #region Processing
        protected virtual void ShowProcessing()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(ShowProcessing));
            }
            else
            {
                toolStripProgressBarForm.Value = 30;
                toolStripProgressBarForm.Visible = true;
            }
        }

        protected virtual void HideProcessing()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(HideProcessing));
            }
            else
            {
                toolStripProgressBarForm.Value = 0;
                toolStripProgressBarForm.Visible = false;
            }
        }
        #endregion

        #region GridBindingSource
        /// <summary>
        /// Reference to GridBindingSource integrated in inherited form control.
        /// </summary>
        protected virtual BindingSource GridBindingSource
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region CRUD_Operations
        /// <summary>
        /// Implements create method of CRUD2CRUD ServiceClient API in product addition form.
        /// </summary>
        protected void Add()
        {
            entityForm = new FormProduct("Add Product");
            entityForm.BindingSource.DataSource = new Application.Models.Standard.DataAccess.Product();
            entityForm.OnSave += FormProduct_OnSave;
            entityForm.FormClosing += FormProduct_FormClosing;
            entityForm.Show();
        }
        /// <summary>
        /// Implements update method of CRUD2CRUD ServiceClient API in product editing form.
        /// </summary>
        protected void Edit()
        {
            if (dataGridViewProducts.CurrentRow.Index >= 0)
            {
                Application.Models.Standard.DataAccess.Product product = (Application.Models.Standard.DataAccess.Product)dataGridViewProducts.CurrentRow.DataBoundItem;
                entityForm = new FormProduct("Edit Product", EntityPersistanceState.Edit);
                entityForm.BindingSource.DataSource = product;
                entityForm.OnSave += FormProduct_OnSave;
                entityForm.FormClosing += FormProduct_FormClosing;
                entityForm.Show();
            }
        }
        /// <summary>
        /// Implements delete method of CRUD2CRUD ServiceClient API.
        /// </summary>
        protected void Delete()
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                if (dataGridViewProducts.CurrentRow.Index >= 0)
                {
                    ShowProcessing();
                    DisplayStatus(new ActionMessage { Message = "Deleting ...", MethodType = MethodType.BeginDelete });
                    ProductServiceClient.BeginDelete((Application.Models.Standard.DataAccess.Product)dataGridViewProducts.CurrentRow.DataBoundItem, new AsyncCallback(DeleteCallback), null);
                }
            }
        }

        private void DeleteCallback(IAsyncResult asyncResult)
        {
            var deletedRecord = ProductServiceClient.EndDelete(asyncResult);

            DisplayStatus(new ActionMessage { Message = "Deleted successfully.", MethodType = MethodType.EndDelete });
            HideProcessing();
            List();
        }

        /// <summary>
        /// Implements list method of CRUD2CRUD ServiceClient API.
        /// </summary>
        protected void List()
        {
            ShowProcessing();
            DisplayStatus(new ActionMessage { Message = "Searching total number of records ...", MethodType = MethodType.List });
            //To support listing you must find total number of records and then load your list of records.
            //You may need to calculate number of lists with following list to load.
            //Note: Total number of lists or pages calculation is omitted.
            ProductServiceClient.BeginMethodSearchObject(new SearchInput { keyword = textBoxKeyword.Text, page = ListNumber, size = ListSize }, "ListTotal", new AsyncCallback(MethodSearchObjectCallback), null);
        }
        private void MethodSearchObjectCallback(IAsyncResult asyncResult)
        {
            int totalRecords = (int) ProductServiceClient.EndMethodSearchObject(asyncResult);
            DisplayTotal(totalRecords);

            DisplayStatus(new ActionMessage { Message = "Listing ...", MethodType = MethodType.List });
            ProductServiceClient.BeginList(new SearchInput { keyword = textBoxKeyword.Text, page = ListNumber, size = ListSize }, new AsyncCallback(ListCallback), null);
        }
        private void ListCallback(IAsyncResult asyncResult)
        {
            var records = ProductServiceClient.EndList(asyncResult);

            UpdateGridList(records.ToList<object>());
            DisplayStatus(new ActionMessage { Message = "Listed successfully.", MethodType = MethodType.EndList });
            HideProcessing();
        }
        #endregion

        #region DisplayStatus
        protected void DisplayStatus(object statusMessage)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = statusMessage;
                BeginInvoke(new ObjectParamDelegate(DisplayStatus), arguments);
            }
            else
            {
                statusBarText.Text = ((ActionMessage)statusMessage).Message;
            }
        }
        #endregion

        #region UpdateGridList
        protected virtual void UpdateGridList(List<object> contentObjectList)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = contentObjectList;
                BeginInvoke(new ListParamDelegate(UpdateGridList), arguments);
            }
            else
            {
                if (contentObjectList != null)
                {
                    bindingSourceGridView.DataSource = null;
                    bindingSourceGridView.DataSource = contentObjectList;
                    dataGridViewProducts.DataSource = bindingSourceGridView;
                }
            }
        }
        #endregion

        #region ResetForm
        protected virtual void ResetForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NoParamDelegate(ResetForm));
            }
            else
            {
                if (entityForm != null)
                {
                    entityForm.Reset();
                }
            }
        }
        #endregion

        #region DisplayTotal
        protected void DisplayTotal(object count)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = count;

                BeginInvoke(new ObjectParamDelegate(DisplayTotal), arguments);
            }
            else
            {
                labelTotalRecords.Text = ((int)count).ToString();
            }
        }
        #endregion

        private void FormManageProducts_Load(object sender, EventArgs e)
        {
            labelBusinessName.Text = ConfigurationManager.AppSettings["BusinessName"];

            BeginInvoke(new NoParamDelegate(StartServerTimer));
            BeginInvoke(new NoParamDelegate(ResetForm));
            List();
        }

        private void FormManageProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProductServiceClient.FactoryServiceAsync.Close();
        }

        private void FormProduct_OnSave(object entity, EntityPersistanceEventArgument eventArgument)
        {
            if (eventArgument.EntityPersistanceState == EntityPersistanceState.Create)
            {
                ShowProcessing();
                DisplayStatus(new ActionMessage { Message = "Creating ...", MethodType = MethodType.Create });
                ProductServiceClient.BeginCreate((Application.Models.Standard.DataAccess.Product)entity, new AsyncCallback(CreateCallback), null);
            }
            else if (eventArgument.EntityPersistanceState == EntityPersistanceState.Edit)
            {
                ShowProcessing();
                DisplayStatus(new ActionMessage { Message = "Updating ...", MethodType = MethodType.Update });
                ProductServiceClient.BeginUpdate((Application.Models.Standard.DataAccess.Product)entity, new AsyncCallback(UpdateCallback), null);
            }
        }

        private void CreateCallback(IAsyncResult asyncResult)
        {
            ProductServiceClient.EndCreate(asyncResult);

            DisplayStatus(new ActionMessage { Message = "Created successfully.", MethodType = MethodType.Create });
            HideProcessing();
            ResetForm();
            List();
        }

        private void UpdateCallback(IAsyncResult asyncResult)
        {
            ProductServiceClient.EndUpdate(asyncResult);

            DisplayStatus(new ActionMessage { Message = "Updated successfully.", MethodType = MethodType.Create });
            HideProcessing();
            ResetForm();
            List();
        }

        private void FormProduct_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ((FormProduct)sender).OnSave -= FormProduct_OnSave;
            ((Form)sender).FormClosing -= FormProduct_FormClosing;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (bindingSourceGridView.DataSource != null)
            {
                bindingSourceGridView.Clear();
            }

            List();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Add));
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Edit));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Delete));
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            try
            {
                var pageNumber = int.Parse(textBoxPageNumber.Text);
                ListNumber = pageNumber - 1;
                textBoxPageNumber.Text = ListNumber.ToString();

                List();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                var pageNumber = int.Parse(textBoxPageNumber.Text);
                ListNumber = pageNumber + 1;
                textBoxPageNumber.Text = ListNumber.ToString();

                List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Windows.Forms;
using System.Globalization;
using WindnTrees.ICRUDS;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace ApplicationForms.ParentForms
{
    /// <summary>
    /// Form management.
    /// </summary>
    public partial class FormManage : Form
    {
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
        public FormManage(string lang)
        {
            ListSize = 20;
            ListNumber = 1;
            LanguageCode = lang;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            InitializeComponent();
            this.OnListChange += FormManager_OnListChange;
            this.OnSizeChange += FormManager_OnSizeChange;
        }

        public FormManage()
        {
            ListSize = 20;
            ListNumber = 1;

            InitializeComponent();
            this.OnListChange += FormManager_OnListChange;
            this.OnSizeChange += FormManager_OnSizeChange;
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
        protected virtual void List()
        { }
        protected virtual void Add()
        { }
        protected virtual void Edit()
        { }
        protected virtual void Delete()
        { }
        #endregion

        #region CoordinateObject
        public virtual void CoordinateObject(object coordinatedObject)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = coordinatedObject;
                BeginInvoke(new ObjectParamDelegate(CoordinateObject), arguments);
            }
            else
            {
                ResetCoordinatedObject(coordinatedObject);
            }
        }

        public virtual void ResetCoordinatedObject(object coordinatedObject)
        {

        }
        #endregion

        #region OnFormClosing
        protected virtual void OnFormClosing()
        {

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

        #region UpdateList
        protected virtual void UpdateList(List<object> contentObjectList)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = contentObjectList;
                BeginInvoke(new ListParamDelegate(UpdateList), arguments);
            }
            else
            {
                if (contentObjectList != null)
                {
                    bindingSourceGridView.DataSource = null;
                    bindingSourceGridView.DataSource = contentObjectList;
                }
            }
        }
        #endregion

        #region GenerateLists
        protected void GenerateLists(object totalRecords)
        {
            int listSize = 0;
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = totalRecords;

                BeginInvoke(new ObjectParamDelegate(GenerateLists), arguments);
            }
            else
            {
                labelTotalRecords.Text = ((int)totalRecords).ToString();

                bindingSourceNavigator.DataSource = null;
                if (toolStripComboBoxListSize.SelectedIndex >= 0)
                {
                    listSize = int.Parse(toolStripComboBoxListSize.SelectedItem.ToString());
                }
                else
                {
                    listSize = 10;
                }

                int lists = (((int)totalRecords) / listSize) + ((((int)totalRecords) % listSize) > 0 ? 1 : 0);
                if (lists > 0)
                {
                    List<NavigatorItem> listSource = new List<NavigatorItem>();
                    for (int i = 0; i < lists; i++)
                    {
                        listSource.Add(new NavigatorItem { ListNumber = i + 1 });
                    }
                    bindingSourceNavigator.DataSource = listSource;
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
                toolStripComboBoxListSize.SelectedIndex = 0;
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

        #region CRUD2CRUD
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (bindingSourceGridView.DataSource != null)
            {
                bindingSourceGridView.Clear();
            }

            BeginInvoke(new NoParamDelegate(List));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Add));
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Edit));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Delete));
        } 
        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStyle6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                if (buttonAdd.Enabled)
                {
                    buttonAdd.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.D && e.Control)
            {
                if (buttonDelete.Enabled)
                {
                    buttonDelete.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                buttonSearch.PerformClick();
            }
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(StartServerTimer));
            BeginInvoke(new NoParamDelegate(ResetForm));
        }

        private void FormManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosing();
        }

        private void bindingSourceNavigator_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceNavigator != null)
            {
                NavigatorItem navigatorItem = (NavigatorItem)((BindingSource)sender).Current;
                if (navigatorItem != null)
                {
                    ListNumber = navigatorItem.ListNumber;
                    NotifyListChangeEvent(navigatorItem.ListNumber);
                }
            }
        }

        private void toolStripComboBoxListSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxListSize.SelectedIndex >= 0)
            {
                ListSize = int.Parse(toolStripComboBoxListSize.SelectedItem.ToString());
                NotifySizeChangeEvent(ListSize);
            }
            else
            {
                ListSize = 10;
            }
        }

        protected virtual void FormManager_OnListChange(object listNumber)
        {
            ListNumber = (int)listNumber;
        }

        protected virtual void FormManager_OnSizeChange(object listSize)
        {
            ListSize = (int)listSize;
        }
    }
}
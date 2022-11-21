using WindnTrees.ICRUDS;
using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ApplicationForms.ParentForms
{
    public delegate void DelegateSaveEntity(Object entity, EntityPersistanceEventArgument entityPersistanceEventArgument);

    /// <summary>
    /// Form entity.
    /// </summary>
    public partial class FormEntity : Form
    {
        private EntityPersistanceState EntityPersistanceState { get; set; }

        protected string m_LanguageCode = null;
        

        public FormEntity(string title, EntityPersistanceState entityPersistanceState = EntityPersistanceState.Create, string language = null)
        {
            if (language != null)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                m_LanguageCode = language;
            }

            InitializeComponent();
            this.Text = string.Format("{0} Form", title); 
            this.labelFormTitle.Text = title;

            EntityPersistanceState = entityPersistanceState;
        }

        public FormEntity()
        {
            InitializeComponent();
        }

        #region OnSave
        public event DelegateSaveEntity OnSave = null;
        public void FireSaveEvent(Object entity)
        {
            if (OnSave != null)
            {
                OnSave(entity, new EntityPersistanceEventArgument { EntityPersistanceState = this.EntityPersistanceState });
            }
        } 
        #endregion

        #region BindingSource
        public BindingSource BindingSource
        {
            get
            {
                return bindingSourceEntity;
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
                MessageBox.Show(string.Format("{0} {1}", "Unable to stop status reporter.", ex.Message) , StandardMessages.DefaultMsgBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region DisplayStatus
        public void DisplayStatus(object statusMessage)
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

        protected virtual void Save()
        {
            FireSaveEvent(bindingSourceEntity.DataSource);
        }

        public virtual void Reset()
        {

        }

        protected virtual void CloseForm()
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(Save));
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void FrmAddStyle1_Load(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(StartServerTimer));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
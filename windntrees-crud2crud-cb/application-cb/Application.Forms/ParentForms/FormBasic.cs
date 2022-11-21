using System;
using System.Windows.Forms;
using System.Globalization;
using WindnTrees.ICRUDS;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace ApplicationForms.ParentForms
{
    /// <summary>
    /// Form basic.
    /// </summary>
    public partial class FormBasic : Form
    {
        protected string m_LanguageCode = null;
        public FormBasic(string lang)
        {
            try
            {
                if (lang != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                    m_LanguageCode = lang;
                }
            }
            catch { }
            InitializeComponent();
        }

        public FormBasic()
        {
            InitializeComponent();
        }

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

        private void FormStyle1_Load(object sender, EventArgs e)
        {
            BeginInvoke(new NoParamDelegate(StartServerTimer));
        }
    }
}
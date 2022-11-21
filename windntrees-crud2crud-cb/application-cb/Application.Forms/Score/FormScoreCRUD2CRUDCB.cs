using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindnTrees.ICRUDS;

namespace ApplicationForms.Score
{
    public partial class FormScoreCRUD2CRUDCB : Form
    {
        private bool m_secured = false;

        public FormScoreCRUD2CRUDCB()
        {
            InitializeComponent();
        }

        #region GetServiceAddress
        /// <summary>
        /// Gets service address.
        /// </summary>
        /// <returns></returns>
        public string GetServiceAddress(string relatedAddress)
        {
            return string.Format("net.tcp://{0}:{1}{2}/{3}", ConfigurationManager.AppSettings["IPAddress"], ConfigurationManager.AppSettings["TCPPort"], m_secured ? "/secure" : "", relatedAddress);
        }
        #endregion

        #region ScoreServiceClient100_90
        string ScoreServiceClient100_90_id = null;
        ApplicationForms.CBModelRepository.PercentageClientCBRepository percentage90Repository = null;

        private ServiceClient<Application.Models.Standard.DataAccess.Score> m_ScoreServiceClient100_90 = null;
        /// <summary>
        /// Percentage 100-90 service client.
        /// </summary>
        private ServiceClient<Application.Models.Standard.DataAccess.Score> ScoreServiceClient100_90
        {
            get
            {
                if (m_ScoreServiceClient100_90 == null)
                {
                    percentage90Repository = new ApplicationForms.CBModelRepository.PercentageClientCBRepository(90);
                    percentage90Repository.OnCBCommunicationResult += Percentage90Repository_OnCBCommunicationResult;
                    percentage90Repository.OnCBCommunicationResultList += Percentage90Repository_OnCBCommunicationResultList;

                    m_ScoreServiceClient100_90 = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage90Repository, m_secured));
                }
                return m_ScoreServiceClient100_90;
            }
        }

        private void Percentage90Repository_OnCBCommunicationResultList(CBModelRepository.CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null)
        {
            throw new NotImplementedException();
        }

        private void Percentage90Repository_OnCBCommunicationResult(CBModelRepository.CBCommunicationType communicationType, string content, float result, string target = null)
        {
            if (!string.IsNullOrEmpty(target))
            {
                if (target.Equals("avg", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage90Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "AvgScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("max", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage90Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MaxScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("min", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage90Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MinScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("fail", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage90Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "FailScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
            }
            else if (communicationType == CBModelRepository.CBCommunicationType.Read)
            {
                //On callback channel calling proxy method creates deadlock condition.
                //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                //method scaling with one interface. 
                var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"), 
                    percentage90Repository, m_secured));

                IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "TotalScore", null, null);
                while (!asyncResult.IsCompleted)
                {
                    System.Threading.Thread.Sleep(10);
                }
                scoreClient.EndMethodObject(asyncResult);
            }
            else
            {
                DisplayScore100_90(result);
            }
        }

        private void DisplayScore100_90(object score)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = score;
                BeginInvoke(new ObjectParamDelegate(DisplayScore100_90), arguments);
            }
            else
            {
                float floatScore = (float)score;
                labelScore1.Text = floatScore.ToString("0.00");
                labelCaption1.Text = string.Format("{0} %age total score.", percentage90Repository.PercentageRatio);
            }
        }

        #endregion

        #region ScoreServiceClient90_80
        string ScoreServiceClient90_80_id = null;
        ApplicationForms.CBModelRepository.PercentageClientCBRepository percentage80Repository = null;

        private ServiceClient<Application.Models.Standard.DataAccess.Score> m_ScoreServiceClient90_80 = null;
        /// <summary>
        /// Percentage 90-80 service client.
        /// </summary>
        private ServiceClient<Application.Models.Standard.DataAccess.Score> ScoreServiceClient90_80
        {
            get
            {
                if (m_ScoreServiceClient90_80 == null)
                {
                    percentage80Repository = new ApplicationForms.CBModelRepository.PercentageClientCBRepository(80);
                    percentage80Repository.OnCBCommunicationResult += Percentage80Repository_OnCBCommunicationResult;
                    percentage80Repository.OnCBCommunicationResultList += Percentage80Repository_OnCBCommunicationResultList;

                    m_ScoreServiceClient90_80 = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage80Repository, m_secured));
                }
                return m_ScoreServiceClient90_80;
            }
        }

        private void Percentage80Repository_OnCBCommunicationResultList(CBModelRepository.CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null)
        {
            throw new NotImplementedException();
        }

        private void Percentage80Repository_OnCBCommunicationResult(CBModelRepository.CBCommunicationType communicationType, string content, float result, string target = null)
        {
            if (!string.IsNullOrEmpty(target))
            {
                if (target.Equals("avg", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage80Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "AvgScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("max", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage80Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MaxScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("min", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage80Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MinScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("fail", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage80Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "FailScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
            }
            else if (communicationType == CBModelRepository.CBCommunicationType.Read)
            {
                //On callback channel calling proxy method creates deadlock condition.
                //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                //method scaling with one interface. 
                var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage80Repository, m_secured));

                IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "TotalScore", null, null);
                while (!asyncResult.IsCompleted)
                {
                    System.Threading.Thread.Sleep(10);
                }
                scoreClient.EndMethodObject(asyncResult);
            }
            else
            {
                DisplayScore90_80(result);
            }
        }

        private void DisplayScore90_80(object score)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = score;
                BeginInvoke(new ObjectParamDelegate(DisplayScore90_80), arguments);
            }
            else
            {
                float floatScore = (float)score;
                labelScore2.Text = floatScore.ToString("0.00");
                labelCaption2.Text = string.Format("{0} %age total score.", percentage80Repository.PercentageRatio);
            }
        }
        #endregion

        #region ScoreServiceClient80_70
        string ScoreServiceClient80_70_id = null;
        ApplicationForms.CBModelRepository.PercentageClientCBRepository percentage70Repository = null;

        private ServiceClient<Application.Models.Standard.DataAccess.Score> m_ScoreServiceClient80_70 = null;
        /// <summary>
        /// Percentage 80-70 service client.
        /// </summary>
        private ServiceClient<Application.Models.Standard.DataAccess.Score> ScoreServiceClient80_70
        {
            get
            {
                if (m_ScoreServiceClient80_70 == null)
                {
                    percentage70Repository = new ApplicationForms.CBModelRepository.PercentageClientCBRepository(70);
                    percentage70Repository.OnCBCommunicationResult += Percentage70Repository_OnCBCommunicationResult;
                    percentage70Repository.OnCBCommunicationResultList += Percentage70Repository_OnCBCommunicationResultList;

                    m_ScoreServiceClient80_70 = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage70Repository, m_secured));
                }
                return m_ScoreServiceClient80_70;
            }
        }

        private void Percentage70Repository_OnCBCommunicationResultList(CBModelRepository.CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null)
        {
            throw new NotImplementedException();
        }

        private void Percentage70Repository_OnCBCommunicationResult(CBModelRepository.CBCommunicationType communicationType, string content, float result, string target = null)
        {
            if (!string.IsNullOrEmpty(target))
            {
                if (target.Equals("avg", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface.
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage70Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "AvgScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("max", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface.
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage70Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MaxScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("min", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface.
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage70Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MinScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("fail", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface.
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage70Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "FailScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
            }
            else if (communicationType == CBModelRepository.CBCommunicationType.Read)
            {
                //On callback channel calling proxy method creates deadlock condition.
                //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                //method scaling with one interface.
                var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage70Repository, m_secured));

                IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "TotalScore", null, null);
                while (!asyncResult.IsCompleted)
                {
                    System.Threading.Thread.Sleep(10);
                }
                scoreClient.EndMethodObject(asyncResult);
            }
            else
            {
                DisplayScore80_70(result);
            }
        }

        private void DisplayScore80_70(object score)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = score;
                BeginInvoke(new ObjectParamDelegate(DisplayScore80_70), arguments);
            }
            else
            {
                float floatScore = (float)score;
                labelScore3.Text = floatScore.ToString("0.00");
                labelCaption3.Text = string.Format("{0} %age total score.", percentage70Repository.PercentageRatio);
            }
        }
        #endregion

        #region ScoreServiceClient70_60
        string ScoreServiceClient70_60_id = null;
        ApplicationForms.CBModelRepository.PercentageClientCBRepository percentage60Repository = null;

        private ServiceClient<Application.Models.Standard.DataAccess.Score> m_ScoreServiceClient70_60 = null;
        /// <summary>
        /// Percentage 70-60 service client.
        /// </summary>
        private ServiceClient<Application.Models.Standard.DataAccess.Score> ScoreServiceClient70_60
        {
            get
            {
                if (m_ScoreServiceClient70_60 == null)
                {
                    percentage60Repository = new ApplicationForms.CBModelRepository.PercentageClientCBRepository(60);
                    percentage60Repository.OnCBCommunicationResult += Percentage60Repository_OnCBCommunicationResult;
                    percentage60Repository.OnCBCommunicationResultList += Percentage60Repository_OnCBCommunicationResultList;

                    m_ScoreServiceClient70_60 = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                        percentage60Repository, m_secured));
                }
                return m_ScoreServiceClient70_60;
            }
        }

        private void Percentage60Repository_OnCBCommunicationResultList(CBModelRepository.CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null)
        {
            throw new NotImplementedException();
        }

        private void Percentage60Repository_OnCBCommunicationResult(CBModelRepository.CBCommunicationType communicationType, string content, float result, string target = null)
        {
            if (!string.IsNullOrEmpty(target))
            {
                if (target.Equals("avg", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage60Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "AvgScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("max", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage60Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MaxScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("min", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage60Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "MinScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
                else if (target.Equals("fail", StringComparison.OrdinalIgnoreCase))
                {
                    //On callback channel calling proxy method creates deadlock condition.
                    //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                    //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                    //method scaling with one interface. 
                    var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage60Repository, m_secured));

                    IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "FailScore", null, null);
                    while (!asyncResult.IsCompleted)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    scoreClient.EndMethodObject(asyncResult);
                }
            }
            else if (communicationType == CBModelRepository.CBCommunicationType.Read)
            {
                //On callback channel calling proxy method creates deadlock condition.
                //Initialize a new CRUD2CRUD ServiceClient and invoke CRUDM scaling TotalScore method.
                //CRUD2CRUD with Callback CRUD2CRUD repositories form a server side and client side 
                //method scaling with one interface. 

                var scoreClient = new ServiceClient<Application.Models.Standard.DataAccess.Score>(ChannelsAndBindings<Application.Models.Standard.DataAccess.Score>.GetDuplexTcpChannelAsyncFactory(GetServiceAddress("score"),
                    percentage60Repository, m_secured));
                IAsyncResult asyncResult = scoreClient.BeginMethodObject(result, "TotalScore", null, null);
                while (!asyncResult.IsCompleted)
                {
                    System.Threading.Thread.Sleep(10);
                }
                scoreClient.EndMethodObject(asyncResult);
            }
            else
            {
                DisplayScore70_60(result);
            }
        }

        private void DisplayScore70_60(object score)
        {
            if (InvokeRequired)
            {
                object[] arguments = new object[1];
                arguments[0] = score;
                BeginInvoke(new ObjectParamDelegate(DisplayScore70_60), arguments);
            }
            else
            {
                float floatScore = (float)score;
                labelScore4.Text = floatScore.ToString("0.00");
                labelCaption4.Text = string.Format("{0} %age total score.", percentage60Repository.PercentageRatio);
            }
        }
        #endregion

        #region Subscribe100_90
        private void Subscribe100_90()
        {
            ScoreServiceClient100_90_id = Guid.NewGuid().ToString();
            labelCaption1.Text = "Subscribing ...";
            IAsyncResult asyncResult = ScoreServiceClient100_90.BeginSubscribeService(ScoreServiceClient100_90_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient100_90.EndSubscribeService(asyncResult);
            labelCaption1.Text = "Subscribed.";
        }
        #endregion

        #region UnSubscribe100_90
        private void UnSubscribe100_90()
        {
            labelCaption1.Text = "UnSubscribing ...";
            IAsyncResult asyncResult = ScoreServiceClient100_90.BeginUnSubscribeService(ScoreServiceClient100_90_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient100_90.EndUnSubscribeService(asyncResult);
            ScoreServiceClient100_90_id = null;
            ScoreServiceClient100_90.Disconnect();
            m_ScoreServiceClient100_90 = null;

            labelCaption1.Text = "UnSubscribed.";
        } 
        #endregion

        private void buttonSubscribe1_Click(object sender, EventArgs e)
        {
            Subscribe100_90();
        }

        private void buttonUnSubscribe1_Click(object sender, EventArgs e)
        {
            UnSubscribe100_90();
        }

        #region Subscribe90_80
        private void Subscribe90_80()
        {
            labelCaption2.Text = "Subscribing ...";
            ScoreServiceClient90_80_id = Guid.NewGuid().ToString();
            IAsyncResult asyncResult = ScoreServiceClient90_80.BeginSubscribeService(ScoreServiceClient90_80_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient90_80.EndSubscribeService(asyncResult);
            labelCaption2.Text = "Subscribed.";
        }
        #endregion

        #region UnSubscribe90_80
        private void UnSubscribe90_80()
        {
            labelCaption2.Text = "UnSubscribing ...";
            IAsyncResult asyncResult = ScoreServiceClient90_80.BeginUnSubscribeService(ScoreServiceClient90_80_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient90_80.EndUnSubscribeService(asyncResult);
            ScoreServiceClient90_80_id = null;
            ScoreServiceClient90_80.Disconnect();
            m_ScoreServiceClient90_80 = null;
            labelCaption2.Text = "UnSubscribed.";
        } 
        #endregion

        private void buttonSubscribe2_Click(object sender, EventArgs e)
        {
            Subscribe90_80();
        }

        private void buttonUnSubscribe2_Click(object sender, EventArgs e)
        {
            UnSubscribe90_80();
        }

        #region Subscribe80_70
        private void Subscribe80_70()
        {
            labelCaption3.Text = "Subscribing ...";
            ScoreServiceClient80_70_id = Guid.NewGuid().ToString();
            IAsyncResult asyncResult = ScoreServiceClient80_70.BeginSubscribeService(ScoreServiceClient80_70_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient80_70.EndSubscribeService(asyncResult);
            labelCaption3.Text = "Subscribed.";
        }
        #endregion

        #region UnSubscribe80_70
        private void UnSubscribe80_70()
        {
            labelCaption3.Text = "UnSubscribing ...";
            IAsyncResult asyncResult = ScoreServiceClient80_70.BeginUnSubscribeService(ScoreServiceClient80_70_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient80_70.EndUnSubscribeService(asyncResult);
            ScoreServiceClient80_70_id = null;
            ScoreServiceClient80_70.Disconnect();
            m_ScoreServiceClient80_70 = null;
            labelCaption3.Text = "UnSubscribed.";
        } 
        #endregion

        private void buttonSubscribe3_Click(object sender, EventArgs e)
        {
            Subscribe80_70();
        }

        private void buttonUnSubscribe3_Click(object sender, EventArgs e)
        {
            UnSubscribe80_70();
        }

        #region Subscribe70_60
        private void Subscribe70_60()
        {
            labelCaption4.Text = "Subscribing ...";
            ScoreServiceClient70_60_id = Guid.NewGuid().ToString();
            IAsyncResult asyncResult = ScoreServiceClient70_60.BeginSubscribeService(ScoreServiceClient70_60_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient70_60.EndSubscribeService(asyncResult);
            labelCaption4.Text = "Subscribed.";
        } 
        #endregion

        #region UnSubscribe70_60
        private void UnSubscribe70_60()
        {
            labelCaption4.Text = "UnSubscribing ...";
            IAsyncResult asyncResult = ScoreServiceClient70_60.BeginUnSubscribeService(ScoreServiceClient70_60_id);
            while (!asyncResult.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ScoreServiceClient70_60.EndUnSubscribeService(asyncResult);
            ScoreServiceClient70_60_id = null;
            ScoreServiceClient70_60.Disconnect();
            m_ScoreServiceClient70_60 = null;
            labelCaption4.Text = "UnSubscribed.";
        } 
        #endregion

        private void buttonSubscribe4_Click(object sender, EventArgs e)
        {
            Subscribe70_60();
        }

        private void buttonUnSubscribe4_Click(object sender, EventArgs e)
        {
            UnSubscribe70_60();
        }

        private void buttonSubscribeAll_Click(object sender, EventArgs e)
        {
            Subscribe100_90();
            Subscribe90_80();
            Subscribe80_70();
            Subscribe70_60();
        }

        private void buttonUnSubscribeAll_Click(object sender, EventArgs e)
        {
            UnSubscribe100_90();
            UnSubscribe90_80();
            UnSubscribe80_70();
            UnSubscribe70_60();
        }
    }
}

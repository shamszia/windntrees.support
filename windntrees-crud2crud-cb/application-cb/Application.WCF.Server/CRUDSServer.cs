using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Application.WCF.Server
{   
    public class CRUDSServer : WindnTrees.CRUDS.Indigo.Server
    {
        private static List<CBRepositorySubscriptionObject> CBRepositories = new List<CBRepositorySubscriptionObject>();
        private static object m_CBRepositoriesLock = new object();
        private static float m_TotalScore = 0;
        private static float m_AverageTotalScore = 0;
        private static float m_MinimumScore = 0;
        private static float m_MaximumScore = 0;
        private static float m_FailScore = 0;

        private static float m_TotalScoreStandard = 0;
        private static float m_AverageTotalScoreStandard = 0;
        private static float m_MinimumScoreStandard = 0;
        private static float m_MaximumScoreStandard = 0;
        private static float m_FailScoreStandard = 0;

        #region DefineCustomEndPoints
        protected override ServiceHost DefineCustomEndPoints(string bindingType, string ipAddress, string port, string relativeAddress, Type serviceInterface, Type serviceType, bool enableSecurity, int timeOutInMinutes, int maxBufferSize, int maxMessageSize, int maxRecords, int arrayLength, int nodeDepth)
        {
            string protocolBinding = "http";
            if (bindingType.StartsWith("custom.dual.session.net.tcp"))
            {
                protocolBinding = "net.tcp";
            }
            else if (bindingType.StartsWith("custom.dual.session.http"))
            {
                protocolBinding = enableSecurity ? "https" : "http";
            }

            var host = new ServiceHost(serviceType, new Uri(GetAddress(protocolBinding, ipAddress, port, enableSecurity)));

            if (enableSecurity)
            {
                SetHttpsAuthorizationPolicy(host);
                //host.Credentials.ServiceCertificate.SetCertificate(ConfigurationManager.AppSettings["ssl-certificate-subject"], System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My);
                //host.Credentials.ClientCertificate.SetCertificate(ConfigurationManager.AppSettings["ssl-certificate-subject"], System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My);

                if (bindingType.StartsWith("custom.dual.session.http"))
                {
                    WSDualHttpBinding wsDualHttpBinding = new WSDualHttpBinding(WSDualHttpSecurityMode.Message);
                    wsDualHttpBinding.MessageEncoding = WSMessageEncoding.Text;
                    wsDualHttpBinding.TextEncoding = System.Text.Encoding.UTF8;
                    wsDualHttpBinding.MaxReceivedMessageSize = maxMessageSize;
                    wsDualHttpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, wsDualHttpBinding, relativeAddress);
                }
                else if (bindingType.StartsWith("custom.basic.http"))
                {
                    BasicHttpsBinding basicHttpsBinding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                    basicHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    //basicHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    //basicHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                    //basicHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
                    basicHttpsBinding.MessageEncoding = WSMessageEncoding.Text;
                    basicHttpsBinding.TextEncoding = System.Text.Encoding.UTF8;
                    basicHttpsBinding.TransferMode = TransferMode.Streamed;
                    basicHttpsBinding.MaxReceivedMessageSize = maxMessageSize;
                    basicHttpsBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, basicHttpsBinding, relativeAddress);
                }
                else if (bindingType.StartsWith("custom.dual.session.net.tcp"))
                {
                    NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.Transport);
                    tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                    tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

                    tcpBinding.TransferMode = TransferMode.Buffered;
                    tcpBinding.MaxBufferSize = maxBufferSize;
                    tcpBinding.MaxBufferPoolSize = maxBufferSize;
                    tcpBinding.MaxReceivedMessageSize = maxMessageSize;
                    tcpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);

                    host.AddServiceEndpoint(serviceInterface, tcpBinding, relativeAddress);
                }
                else
                {
                    NetHttpsBinding netHttpsBinding = new NetHttpsBinding(BasicHttpsSecurityMode.Transport);
                    netHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    //netHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    //netHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                    //netHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
                    netHttpsBinding.TransferMode = TransferMode.Streamed;
                    netHttpsBinding.MaxReceivedMessageSize = maxMessageSize;
                    netHttpsBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, netHttpsBinding, relativeAddress);
                }
            }
            else
            {
                if (bindingType.StartsWith("custom.dual.session.http"))
                {
                    WSDualHttpBinding wsDualHttpBinding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                    wsDualHttpBinding.MessageEncoding = WSMessageEncoding.Text;
                    wsDualHttpBinding.TextEncoding = System.Text.Encoding.UTF8;
                    wsDualHttpBinding.MaxReceivedMessageSize = maxMessageSize;
                    wsDualHttpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, wsDualHttpBinding, relativeAddress);
                }
                else if (bindingType.StartsWith("custom.basic.http"))
                {
                    BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                    basicHttpBinding.MessageEncoding = WSMessageEncoding.Text;
                    basicHttpBinding.TextEncoding = System.Text.Encoding.UTF8;
                    basicHttpBinding.TransferMode = TransferMode.Streamed;
                    basicHttpBinding.MaxReceivedMessageSize = maxMessageSize;
                    basicHttpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, basicHttpBinding, relativeAddress);
                }
                else if (bindingType.StartsWith("custom.dual.session.net.tcp"))
                {
                    NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);

                    tcpBinding.TransferMode = TransferMode.Buffered;
                    tcpBinding.MaxBufferSize = maxBufferSize;
                    tcpBinding.MaxBufferPoolSize = maxBufferSize;
                    tcpBinding.MaxReceivedMessageSize = maxMessageSize;
                    tcpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);

                    host.AddServiceEndpoint(serviceInterface, tcpBinding, relativeAddress);
                }
                else
                {
                    NetHttpBinding netHttpBinding = new NetHttpBinding(BasicHttpSecurityMode.None);
                    netHttpBinding.MessageEncoding = NetHttpMessageEncoding.Text;
                    netHttpBinding.TextEncoding = System.Text.Encoding.UTF8;
                    netHttpBinding.TransferMode = TransferMode.Streamed;
                    netHttpBinding.MaxReceivedMessageSize = maxMessageSize;
                    netHttpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, netHttpBinding, relativeAddress);
                }
            }

            return host;
        } 
        #endregion

        #region StartServices
        public override void StartServices()
        {
            //.NET
            //////////////////////////////////////////

            //Handles callback subscription request.
            Application.WCF.Server.Repositories.ScoreRepository.OnServiceCallback += ScoreRepository_OnServiceCallback;
            Application.WCF.Server.Repositories.Standard.ScoreRepository.OnServiceCallback += ScoreRepositoryStandard_OnServiceCallback;

            //CRUD2CRUD Example Application Score Result Events
            Application.WCF.Server.Repositories.ScoreRepository.OnScoreResult += ScoreRepository_OnScoreResult;
            Application.WCF.Server.Repositories.Standard.ScoreRepository.OnScoreResult += ScoreRepositoryStandard_OnScoreResult;

            //HTTP Services
            StartService("HTTP.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "http.basic", "127.0.0.1", "9090", "/product", 1, false);
            StartService("HTTP.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "http.basic", "127.0.0.1", "9091", "/secure/product", 1, true);
            //IServiceCB can be replaced with IWCFServiceCB, client side proxies must be updated with similar interface channels.
            StartService("HTTP.Score.IServiceCB", typeof(WindnTrees.ICRUDS.IServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.ScoreRepository), null, "custom.dual.session.http", "127.0.0.1", "9090", "/score", 1, false);

            //https duplex channel is not supported
            //StartService("HTTP.Score.IServiceCB.Secure", typeof(WindnTrees.ICRUDS.IWCFServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.ScoreRepository), null, "custom.dual.session.http", "127.0.0.1", "9091", "/secure/score", 1, true);

            //TCP Services
            StartService("TCP.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "net.tcp", "127.0.0.1", "9092", "/product", 1, false);
            StartService("TCP.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "net.tcp", "127.0.0.1", "9093", "/secure/product", 1, true);

            //IServiceCB can be replaced with IWCFServiceCB, client side proxies must be updated with similar interface channels.
            StartService("TCP.Score.IServiceCB", typeof(WindnTrees.ICRUDS.IServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.ScoreRepository), null, "custom.dual.session.net.tcp", "127.0.0.1", "9092", "/score", 1, false);
            StartService("TCP.Score.IServiceCB.Secure", typeof(WindnTrees.ICRUDS.IServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.ScoreRepository), null, "custom.dual.session.net.tcp", "127.0.0.1", "9093", "/secure/score", 1, true);

            //.NET Core
            //////////////////////////////////////////

            //HTTP Services
            StartService("HTTP.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "http.basic", "127.0.0.1", "9094", "/product", 1, false);
            StartService("HTTP.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "http.basic", "127.0.0.1", "9095", "/secure/product", 1, true);
            
            //http duplex channel is not supported in .net core
            //StartService("HTTP.Score.IServiceCB.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.Standard.ScoreRepository), null, "custom.dual.session.http", "127.0.0.1", "9094", "/score", 1, false);
            //StartService("HTTP.Score.IServiceCB.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.Standard.ScoreRepository), null, "custom.dual.session.http", "127.0.0.1", "9095", "/secure/score", 1, true);

            //TCP Services
            StartService("TCP.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "net.tcp", "127.0.0.1", "9096", "/product", 1, false);
            StartService("TCP.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "net.tcp", "127.0.0.1", "9097", "/secure/product", 1, true);

            //IServiceCB can be replaced with IWCFServiceCB, client side proxies must be updated with similar interface channels.
            StartService("TCP.Score.IServiceCB.Standard", typeof(WindnTrees.ICRUDS.Standard.IServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.Standard.ScoreRepository), null, "custom.dual.session.net.tcp", "127.0.0.1", "9096", "/score", 1, false);
            StartService("TCP.Score.IServiceCB.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IServiceCB<Application.Models.Standard.DataAccess.Score>), typeof(Application.WCF.Server.Repositories.Standard.ScoreRepository), null, "custom.dual.session.net.tcp", "127.0.0.1", "9097", "/secure/score", 1, true);
        }
        #endregion

        #region StopServices
        public override void StopServices()
        {
            //.NET
            StopService("HTTP.Product.IWCFService");
            StopService("HTTP.Product.IWCFService.Secure");
            StopService("HTTP.Score.IServiceCB");
            //StopService("HTTP.Score.IServiceCB.Secure");
            StopService("TCP.Product.IWCFService");
            StopService("TCP.Product.IWCFService.Secure");
            StopService("TCP.Score.IServiceCB");
            StopService("TCP.Score.IServiceCB.Secure");

            //.NET Core
            StopService("HTTP.Product.IWCFService.Standard");
            StopService("HTTP.Product.IWCFService.Standard.Secure");
            //StopService("HTTP.Score.IServiceCB.Standard");
            //StopService("HTTP.Score.IServiceCB.Standard.Secure");
            StopService("TCP.Product.IWCFService.Standard");
            StopService("TCP.Product.IWCFService.Standard.Secure");
            StopService("TCP.Score.IServiceCB.Standard");
            StopService("TCP.Score.IServiceCB.Standard.Secure");
        } 
        #endregion

        #region CallbackChannel_ServiceRepositories_Events
        /// <summary>
        /// Handles and save callback channel for later invocations.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iCRUDLMCBRepository"></param>
        private void ScoreRepository_OnServiceCallback(string id, WindnTrees.ICRUDS.ICRUDLMCBRepository<string> iCRUDLMCBRepository)
        {
            ManageRepository(id, iCRUDLMCBRepository);
        }

        /// <summary>
        /// Handles and save callback channel for later invocations.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iCRUDLMCBRepository"></param>
        private void ScoreRepositoryStandard_OnServiceCallback(string id, WindnTrees.ICRUDS.Standard.ICRUDLMCBRepository<string> iCRUDLMCBRepository)
        {
            ManageRepository(id, iCRUDLMCBRepository);
        }
        #endregion

        #region CRUD2CRUD_Example_Application_Score_Events
        private void ScoreRepository_OnScoreResult(string method, object score)
        {
            if (method.Equals("TotalScore", StringComparison.OrdinalIgnoreCase))
            {
                m_TotalScore += (float)score;

                System.Console.WriteLine(string.Format("Total of %Age Score Count: {0}", m_TotalScore));
            }
            else if (method.Equals("AvgScore", StringComparison.OrdinalIgnoreCase))
            {
                m_AverageTotalScore = (float)score;

                System.Console.WriteLine(string.Format("Average of %Age Score Count: {0}", m_AverageTotalScore));
            }
            else if (method.Equals("MaxScore", StringComparison.OrdinalIgnoreCase))
            {
                m_MaximumScore = (float)score;

                System.Console.WriteLine(string.Format("Maximum Input Score: {0}", m_MaximumScore));
            }
            else if (method.Equals("MinScore", StringComparison.OrdinalIgnoreCase))
            {
                m_MinimumScore = (float)score;

                System.Console.WriteLine(string.Format("Minimum Input Score: {0}", m_MinimumScore));
            }
            else if (method.Equals("FailScore", StringComparison.OrdinalIgnoreCase))
            {
                m_FailScore = (float)score;

                System.Console.WriteLine(string.Format("Total of %Age of Fail Score Count: {0}", m_FailScore));
            }
        }

        private void ScoreRepositoryStandard_OnScoreResult(string method, object score)
        {
            if (method.Equals("TotalScore", StringComparison.OrdinalIgnoreCase))
            {
                m_TotalScoreStandard += (float)score;

                System.Console.WriteLine(string.Format("[Standard] Total of %Age Score Count: {0}", m_TotalScoreStandard));
            }
            else if (method.Equals("AvgScore", StringComparison.OrdinalIgnoreCase))
            {
                m_AverageTotalScoreStandard = (float)score;

                System.Console.WriteLine(string.Format("[Standard] Average of %Age Score Count: {0}", m_AverageTotalScoreStandard));
            }
            else if (method.Equals("MaxScore", StringComparison.OrdinalIgnoreCase))
            {
                m_MaximumScoreStandard = (float)score;

                System.Console.WriteLine(string.Format("[Standard] Maximum Input Score: {0}", m_MaximumScoreStandard));
            }
            else if (method.Equals("MinScore", StringComparison.OrdinalIgnoreCase))
            {
                m_MinimumScoreStandard = (float)score;

                System.Console.WriteLine(string.Format("[Standard] Minimum Input Score: {0}", m_MinimumScoreStandard));
            }
            else if (method.Equals("FailScore", StringComparison.OrdinalIgnoreCase))
            {
                m_FailScoreStandard = (float)score;

                System.Console.WriteLine(string.Format("[Standard] Total of %Age of Fail Score Count: {0}", m_FailScoreStandard));
            }
        }
        #endregion

        #region ManageRepository
        private void ManageRepository(string id, object iCRUDLMCBRepository)
        {
            if (iCRUDLMCBRepository != null)
            {
                lock (m_CBRepositoriesLock)
                {
                    CBRepositories.Add(new CBRepositorySubscriptionObject { ID = id, Repository = iCRUDLMCBRepository });
                }
            }
            else
            {
                CBRepositorySubscriptionObject cbRepositorySubscriptionObject = null;

                lock (m_CBRepositoriesLock)
                {
                    foreach (var repositoryObject in CBRepositories)
                    {
                        if (repositoryObject.ID == id)
                        {
                            cbRepositorySubscriptionObject = repositoryObject;
                            break;
                        }
                    }

                    CBRepositories.Remove(cbRepositorySubscriptionObject);
                }
            }
        }
        #endregion

        #region ExecuteCommand
        public static void ExecuteCommand(string command)
        {
            WindnTrees.ICRUDS.ICRUDLMCBRepository<string> iCRUDSNetRepository = null;
            WindnTrees.ICRUDS.Standard.ICRUDLMCBRepository<string> iCRUDSStandardRepository = null;

            lock (m_CBRepositoriesLock)
            {
                foreach (var cbRepositoryObject in CBRepositories)
                {
                    //From each repository object identify and initialize correct repository .NET Native or .NET Standard
                    //and invoke score command

                    iCRUDSNetRepository = null;
                    iCRUDSStandardRepository = null;

                    if (cbRepositoryObject.Repository.GetType() == typeof(WindnTrees.ICRUDS.ICRUDLMCBRepository<string>))
                    {
                        iCRUDSNetRepository = (WindnTrees.ICRUDS.ICRUDLMCBRepository<string>)cbRepositoryObject.Repository;
                    }
                    else if (cbRepositoryObject.Repository.GetType() == typeof(WindnTrees.ICRUDS.Standard.ICRUDLMCBRepository<string>))
                    {
                        iCRUDSStandardRepository = (WindnTrees.ICRUDS.Standard.ICRUDLMCBRepository<string>)cbRepositoryObject.Repository;
                    }

                    if (!string.IsNullOrEmpty(command))
                    {
                        string[] commandArguments = command.Split(new char[] { ' ' });

                        if (commandArguments.Length == 1)
                        {
                            //CRUDM SCALE
                            //CRUDMethod (CRUDM) scales avg, max, min and failscore functions.
                            //
                            //CRUDM SCALE (avg, max, min, failscore)

                            if (commandArguments[0].Equals("read", StringComparison.OrdinalIgnoreCase))
                            {   
                                if (iCRUDSNetRepository != null)
                                {
                                    m_TotalScore = 0;
                                    iCRUDSNetRepository.Read(null);
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    m_TotalScoreStandard = 0;
                                    iCRUDSStandardRepository.Read(null);
                                }
                            }
                            else if (commandArguments[0].Equals("list", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    iCRUDSNetRepository.List(new WindnTrees.ICRUDS.SearchInput { });
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    iCRUDSStandardRepository.List(new WindnTrees.ICRUDS.Standard.SearchInput { });
                                }
                            }
                            else if (commandArguments[0].Equals("avg", StringComparison.OrdinalIgnoreCase))
                            {   
                                if (iCRUDSNetRepository != null)
                                {
                                    m_AverageTotalScore = 0;
                                    iCRUDSNetRepository.Method("avg");
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    m_AverageTotalScoreStandard = 0;
                                    iCRUDSStandardRepository.Method("avg");
                                }
                            }
                            else if (commandArguments[0].Equals("max", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    m_MaximumScore = 0;
                                    iCRUDSNetRepository.Method("max");
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    m_MaximumScoreStandard = 0;
                                    iCRUDSStandardRepository.Method("max");
                                }
                            }
                            else if (commandArguments[0].Equals("min", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    m_MinimumScore = 0;
                                    iCRUDSNetRepository.Method("min");
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    m_MinimumScoreStandard = 0;
                                    iCRUDSStandardRepository.Method("min");
                                }
                            }
                            else if (commandArguments[0].Equals("failscore", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    m_FailScore = 0;
                                    iCRUDSNetRepository.Method("fail");
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    m_FailScoreStandard = 0;
                                    iCRUDSStandardRepository.Method("fail");
                                }
                            }
                        }
                        else if (commandArguments.Length == 2)
                        {
                            float score = 0;
                            try
                            {
                                score = float.Parse(commandArguments[1]);
                            }
                            catch { }

                            if (commandArguments[0].Equals("create", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    iCRUDSNetRepository.Create(score.ToString("0.00"));
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    iCRUDSStandardRepository.Create(score.ToString("0.00"));
                                }
                            }
                            else if (commandArguments[0].Equals("read", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    iCRUDSNetRepository.Read(commandArguments[1]);
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    iCRUDSStandardRepository.Read(commandArguments[1]);
                                }
                            }
                            else if (commandArguments[0].Equals("update", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    iCRUDSNetRepository.Update(score.ToString("0.00"));
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    iCRUDSStandardRepository.Update(score.ToString("0.00"));
                                }
                            }
                            else if (commandArguments[0].Equals("delete", StringComparison.OrdinalIgnoreCase))
                            {
                                if (iCRUDSNetRepository != null)
                                {
                                    iCRUDSNetRepository.Delete(score.ToString("0.00"));
                                }
                                else if (iCRUDSStandardRepository != null)
                                {
                                    iCRUDSStandardRepository.Delete(score.ToString("0.00")); ;
                                }
                            }
                        }
                    }
                }
            }
        } 
        #endregion
    }
}
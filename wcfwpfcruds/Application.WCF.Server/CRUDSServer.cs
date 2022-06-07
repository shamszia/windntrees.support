using System;
using System.ServiceModel;

namespace Application.WCF.Server
{   
    public class CRUDSServer : WindnTrees.CRUDS.Indigo.Server
    {
        protected override ServiceHost DefineCustomEndPoints(string bindingType, string ipAddress, string port, string relativeAddress, Type serviceInterface, Type serviceType, bool enableSecurity, int timeOutInMinutes, int maxBufferSize, int maxMessageSize, int maxRecords, int arrayLength, int nodeDepth)
        {
            var host = new ServiceHost(serviceType, new Uri(GetAddress(bindingType, ipAddress, port, enableSecurity)));

            if (enableSecurity)
            {
                SetHttpsAuthorizationPolicy(host);
                //host.Credentials.ServiceCertificate.SetCertificate(ConfigurationManager.AppSettings["ssl-certificate-subject"], System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My);
                //host.Credentials.ClientCertificate.SetCertificate(ConfigurationManager.AppSettings["ssl-certificate-subject"], System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My);

                if (bindingType.StartsWith("custom.basic.http"))
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
                else
                {
                    NetHttpsBinding netHttpsBinding = new NetHttpsBinding(BasicHttpsSecurityMode.Transport);
                    netHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    //netHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    //netHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                    //netHttpsBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
                    netHttpsBinding.MessageEncoding = NetHttpMessageEncoding.Text;
                    netHttpsBinding.TextEncoding = System.Text.Encoding.UTF8;
                    netHttpsBinding.TransferMode = TransferMode.Streamed;
                    netHttpsBinding.MaxReceivedMessageSize = maxMessageSize;
                    netHttpsBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, netHttpsBinding, relativeAddress);
                }
            }
            else
            {
                if (bindingType.StartsWith("custom.basic.http"))
                {
                    BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                    basicHttpBinding.MessageEncoding = WSMessageEncoding.Text;
                    basicHttpBinding.TextEncoding = System.Text.Encoding.UTF8;
                    basicHttpBinding.TransferMode = TransferMode.Streamed;
                    basicHttpBinding.MaxReceivedMessageSize = maxMessageSize;
                    basicHttpBinding.ReceiveTimeout = new TimeSpan(0, timeOutInMinutes, 0);
                    host.AddServiceEndpoint(serviceInterface, basicHttpBinding, relativeAddress);
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

        public override void StartServices()
        {
            //.NET
            //////////////////////////////////////////

            //HTTP Services
            StartService("HTTP.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "custom.basic.http", "127.0.0.1", "9090", "/product", 1, false);
            StartService("HTTP.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "custom.basic.http", "127.0.0.1", "9091", "/secure/product", 1, true);
            StartService("HTTP.Adapter.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterRepository), null, "custom.basic.http", "127.0.0.1", "9090", "/adapter/product", 1, false);
            StartService("HTTP.Adapter.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterRepository), null, "custom.basic.http", "127.0.0.1", "9091", "/secure/adapter/product", 1, true);

            StartService("HTTP.Product.Empty.IWCFService", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9090", "/product/empty", 1, false);
            StartService("HTTP.Product.Empty.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9091", "/secure/product/empty", 1, true);
            StartService("HTTP.Adapter.Product.Empty.IWCFService", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9090", "/adapter/product/empty", 1, false);
            StartService("HTTP.Adapter.Product.Empty.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9091", "/secure/adapter/product/empty", 1, true);

            //TCP Services
            StartService("TCP.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "net.tcp", "127.0.0.1", "9092", "/product", 1, false);
            StartService("TCP.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductRepository), null, "net.tcp", "127.0.0.1", "9093", "/secure/product", 1, true);
            StartService("TCP.Adapter.Product.IWCFService", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterRepository), null, "net.tcp", "127.0.0.1", "9092", "/adapter/product", 1, false);
            StartService("TCP.Adapter.Product.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterRepository), null, "net.tcp", "127.0.0.1", "9093", "/secure/adapter/product", 1, true);

            StartService("TCP.Product.Empty.IWCFService", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductEmptyRepository), null, "net.tcp", "127.0.0.1", "9092", "/product/empty", 1, false);
            StartService("TCP.Product.Empty.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.ProductEmptyRepository), null, "net.tcp", "127.0.0.1", "9093", "/secure/product/empty", 1, true);
            StartService("TCP.Adapter.Product.Empty.IWCFService", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterEmptyRepository), null, "net.tcp", "127.0.0.1", "9092", "/adapter/product/empty", 1, false);
            StartService("TCP.Adapter.Product.Empty.IWCFService.Secure", typeof(WindnTrees.ICRUDS.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.ProductAdapterEmptyRepository), null, "net.tcp", "127.0.0.1", "9093", "/secure/adapter/product/empty", 1, true);

            //.NET Core
            //////////////////////////////////////////

            //HTTP Services
            StartService("HTTP.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "custom.basic.http", "127.0.0.1", "9094", "/product", 1, false);
            StartService("HTTP.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "custom.basic.http", "127.0.0.1", "9095", "/secure/product", 1, true);
            StartService("HTTP.Adapter.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterRepository), null, "custom.basic.http", "127.0.0.1", "9094", "/adapter/product", 1, false);
            StartService("HTTP.Adapter.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterRepository), null, "custom.basic.http", "127.0.0.1", "9095", "/secure/adapter/product", 1, true);

            StartService("HTTP.Product.Empty.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9094", "/product/empty", 1, false);
            StartService("HTTP.Product.Empty.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9095", "/secure/product/empty", 1, true);
            StartService("HTTP.Adapter.Product.Empty.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9094", "/adapter/product/empty", 1, false);
            StartService("HTTP.Adapter.Product.Empty.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterEmptyRepository), null, "custom.basic.http", "127.0.0.1", "9095", "/secure/adapter/product/empty", 1, true);

            //TCP Services
            StartService("TCP.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "net.tcp", "127.0.0.1", "9096", "/product", 1, false);
            StartService("TCP.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductRepository), null, "net.tcp", "127.0.0.1", "9097", "/secure/product", 1, true);
            StartService("TCP.Adapter.Product.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterRepository), null, "net.tcp", "127.0.0.1", "9096", "/adapter/product", 1, false);
            StartService("TCP.Adapter.Product.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterRepository), null, "net.tcp", "127.0.0.1", "9097", "/secure/adapter/product", 1, true);

            StartService("TCP.Product.Empty.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductEmptyRepository), null, "net.tcp", "127.0.0.1", "9096", "/product/empty", 1, false);
            StartService("TCP.Product.Empty.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Product>), typeof(Application.WCF.Server.Repositories.Standard.ProductEmptyRepository), null, "net.tcp", "127.0.0.1", "9097", "/secure/product/empty", 1, true);
            StartService("TCP.Adapter.Product.Empty.IWCFService.Standard", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterEmptyRepository), null, "net.tcp", "127.0.0.1", "9096", "/adapter/product/empty", 1, false);
            StartService("TCP.Adapter.Product.Empty.IWCFService.Standard.Secure", typeof(WindnTrees.ICRUDS.Standard.IWCFEmptyService<Application.Models.Standard.DataAccess.Adapter.Product>), typeof(Application.WCF.Server.Adapter.Repositories.Standard.ProductAdapterEmptyRepository), null, "net.tcp", "127.0.0.1", "9097", "/secure/adapter/product/empty", 1, true);
        }

        public override void StopServices()
        {
            //.NET
            StopService("HTTP.Product.IWCFService");
            StopService("HTTP.Product.IWCFService.Secure");
            StopService("HTTP.Adapter.Product.IWCFService");
            StopService("HTTP.Adapter.Product.IWCFService.Secure");

            StopService("HTTP.Product.Empty.IWCFService");
            StopService("HTTP.Product.Empty.IWCFService.Secure");
            StopService("HTTP.Adapter.Product.Empty.IWCFService");
            StopService("HTTP.Adapter.Product.Empty.IWCFService.Secure");

            StopService("TCP.Product.IWCFService");
            StopService("TCP.Product.IWCFService.Secure");
            StopService("TCP.Adapter.Product.IWCFService");
            StopService("TCP.Adapter.Product.IWCFService.Secure");

            StopService("TCP.Product.Empty.IWCFService");
            StopService("TCP.Product.Empty.IWCFService.Secure");
            StopService("TCP.Adapter.Product.Empty.IWCFService");
            StopService("TCP.Adapter.Product.Empty.IWCFService.Secure");

            //.NET Core
            StopService("HTTP.Product.IWCFService.Standard");
            StopService("HTTP.Product.IWCFService.Standard.Secure");
            StopService("HTTP.Adapter.Product.IWCFService.Standard");
            StopService("HTTP.Adapter.Product.IWCFService.Standard.Secure");

            StopService("HTTP.Product.Empty.IWCFService.Standard");
            StopService("HTTP.Product.Empty.IWCFService.Standard.Secure");
            StopService("HTTP.Adapter.Product.Empty.IWCFService.Standard");
            StopService("HTTP.Adapter.Product.Empty.IWCFService.Standard.Secure");

            StopService("TCP.Product.IWCFService.Standard");
            StopService("TCP.Product.IWCFService.Standard.Secure");
            StopService("TCP.Adapter.Product.IWCFService.Standard");
            StopService("TCP.Adapter.Product.IWCFService.Standard.Secure");

            StopService("TCP.Product.Empty.IWCFService.Standard");
            StopService("TCP.Product.Empty.IWCFService.Standard.Secure");
            StopService("TCP.Adapter.Product.Empty.IWCFService.Standard");
            StopService("TCP.Adapter.Product.Empty.IWCFService.Standard.Secure");
        }
    }
}
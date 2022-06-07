using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using WindnTrees.ICRUDS.Standard;

namespace ApplicationWPFCore
{
    /// <summary>
    /// Utility class for channels and bindings.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChannelsAndBindings<T> where T : class
    {
        #region GetServiceAddress
        /// <summary>
        /// Gets service address.
        /// </summary>
        /// <returns></returns>
        public static string GetServiceAddress(string protocol, string ip, string port, string serviceName)
        {
            return string.Format("{0}://{1}:{2}/{3}", protocol, ip, port, serviceName);
        }
        #endregion

        #region GetTCPBinding
        /// <summary>
        /// Gets TCP binding.
        /// </summary>
        /// <returns></returns>
        public static object GetTCPBinding(bool secured)
        {
            if (secured)
            {
                var binding = new NetTcpBinding(SecurityMode.Transport);
                binding.Namespace = "http://www.invincibletec.com/cruds/";
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize = int.MaxValue;
                return binding;
            }
            else
            {
                var binding = new NetTcpBinding(SecurityMode.None);
                binding.Namespace = "http://www.invincibletec.com/cruds/";
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize = int.MaxValue;
                return binding;
            }
        }
        #endregion

        #region GetHttpBinding
        /// <summary>
        /// Gets basic http binding.
        /// </summary>
        /// <returns></returns>
        public static object GetHttpBinding(bool secured)
        {
            if (secured)
            {
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Namespace = "http://www.invincibletec.com/cruds/";
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize = int.MaxValue;
                return binding;
            }
            else
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                binding.Namespace = "http://www.invincibletec.com/cruds/";
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize = int.MaxValue;
                return binding;
            }
        }
        #endregion

        #region TCP

        #region GetTcpChannelFactory
        /// <summary>
        /// Gets asynchronous Tcp channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IService<T>> GetTcpChannelFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IService<T>> factory = new ChannelFactory<IService<T>>((NetTcpBinding)GetTCPBinding(secured), endPoint);

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetTcpChannelAsyncFactory
        /// <summary>
        /// Gets asynchronous Tcp channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IServiceAsync<T>> GetTcpChannelAsyncFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IServiceAsync<T>> factory = new ChannelFactory<IServiceAsync<T>>((NetTcpBinding)GetTCPBinding(secured), endPoint);

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetTcpWCFChannelFactory
        /// <summary>
        /// Gets asynchronous Tcp channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IWCFService<T>> GetTcpWCFChannelFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IWCFService<T>> factory = new ChannelFactory<IWCFService<T>>((NetTcpBinding)GetTCPBinding(secured), endPoint);

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetTcpWCFChannelAsyncFactory
        /// <summary>
        /// Gets asynchronous Tcp channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IWCFServiceAsync<T>> GetTcpWCFChannelAsyncFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IWCFServiceAsync<T>> factory = new ChannelFactory<IWCFServiceAsync<T>>((NetTcpBinding)GetTCPBinding(secured), endPoint);

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #endregion

        #region HTTP

        #region GetBasicHttpChannelFactory
        /// <summary>
        /// Gets synchronous channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IService<T>> GetBasicHttpChannelFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IService<T>> factory = null;

            if (secured)
            {
                factory = new ChannelFactory<IService<T>>((BasicHttpsBinding)GetHttpBinding(secured), endPoint);
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.None;
            }
            else
            {
                factory = new ChannelFactory<IService<T>>((BasicHttpBinding)GetHttpBinding(secured), endPoint);
            }

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetBasicHttpChannelAsyncFactory
        /// <summary>
        /// Gets asynchronous channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IServiceAsync<T>> GetBasicHttpChannelAsyncFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IServiceAsync<T>> factory = null;

            if (secured)
            {
                factory = new ChannelFactory<IServiceAsync<T>>((BasicHttpsBinding)GetHttpBinding(secured), endPoint);
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.None;
            }
            else
            {
                factory = new ChannelFactory<IServiceAsync<T>>((BasicHttpBinding)GetHttpBinding(secured), endPoint);
            }

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetBasicHttpWCFChannelFactory
        /// <summary>
        /// Gets synchronous channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IWCFService<T>> GetBasicHttpWCFChannelFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IWCFService<T>> factory = null;

            if (secured)
            {
                factory = new ChannelFactory<IWCFService<T>>((BasicHttpsBinding)GetHttpBinding(secured), endPoint);
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.None;
            }
            else
            {
                factory = new ChannelFactory<IWCFService<T>>((BasicHttpBinding)GetHttpBinding(secured), endPoint);
            }

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #region GetBasicHttpWCFChannelAsyncFactory
        /// <summary>
        /// Gets asynchronous channel factory.
        /// </summary>
        /// <returns></returns>
        public static ChannelFactory<IWCFServiceAsync<T>> GetBasicHttpWCFChannelAsyncFactory(string address, bool secured = false)
        {
            EndpointAddress endPoint = new EndpointAddress(address);
            ChannelFactory<IWCFServiceAsync<T>> factory = null;

            if (secured)
            {
                factory = new ChannelFactory<IWCFServiceAsync<T>>((BasicHttpsBinding)GetHttpBinding(secured), endPoint);
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
                factory.Credentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.None;
            }
            else
            {
                factory = new ChannelFactory<IWCFServiceAsync<T>>((BasicHttpBinding)GetHttpBinding(secured), endPoint);
            }

            foreach (OperationDescription operationDescription in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationDescriptionBehaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationDescriptionBehaviour != null)
                {
                    operationDescriptionBehaviour.MaxItemsInObjectGraph = Int32.MaxValue;
                }
            }
            return factory;
        }
        #endregion

        #endregion
    }
}

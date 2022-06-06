using System;
using System.Configuration;
using WindnTrees.ICRUDS.Standard;

namespace WcfConsoleApp
{
    public class Program
    {
        #region GetServiceAddress
        /// <summary>
        /// Gets service address.
        /// </summary>
        /// <returns></returns>
        public string GetServiceAddress(string relatedAddress)
        {
            return string.Format("http://{0}:{1}/{2}", "localhost", "9088", relatedAddress);
        }
        #endregion

        #region StudentServiceClient
        private WCFServiceClient<SharedLibrary.Student> m_StudentServiceClient = null;
        /// <summary>
        /// Product service client.
        /// </summary>
        private WCFServiceClient<SharedLibrary.Student> StudentServiceClient
        {
            get
            {
                if (m_StudentServiceClient == null)
                {
                    m_StudentServiceClient = new WCFServiceClient<SharedLibrary.Student>(ChannelsAndBindings<SharedLibrary.Student>.GetBasicHttpWCFChannelFactory(GetServiceAddress("dataservice/basichttp")));
                }
                return m_StudentServiceClient;
            }
        }
        #endregion

        #region StudentServiceClient
        private WCFServiceClient<SharedLibrary.Student> m_StudentEmptyServiceClient = null;
        /// <summary>
        /// Product service client.
        /// </summary>
        private WCFServiceClient<SharedLibrary.Student> StudentEmptyServiceClient
        {
            get
            {
                if (m_StudentEmptyServiceClient == null)
                {
                    m_StudentEmptyServiceClient = new WCFServiceClient<SharedLibrary.Student>(ChannelsAndBindings<SharedLibrary.Student>.GetEmptyBasicHttpWCFChannelFactory(GetServiceAddress("emptydataservice/basichttp")));
                }
                return m_StudentEmptyServiceClient;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();

            var program = new Program();

            var resultCreate = program.StudentServiceClient.Create(new SharedLibrary.Student { });
            Console.WriteLine(string.Format("rollno: {0}, name: {1}", resultCreate.RollNo, resultCreate.Name));

            var resultRead = program.StudentServiceClient.Read(1);
            Console.WriteLine(string.Format("rollno: {0}, name: {1}", resultRead.RollNo, resultRead.Name));

            var resultList = program.StudentServiceClient.List(new SearchInput { key = "1" });

            var nameResult = program.StudentServiceClient.MethodObject("name", "GetName");
            Console.WriteLine(string.Format("Name Result: {0}", nameResult));

            Console.WriteLine("EmptyServiceRepository");
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();

            var resultEmptyCreate = program.StudentEmptyServiceClient.Create();
            Console.WriteLine(string.Format("rollno: {0}, name: {1}", resultCreate.RollNo, resultCreate.Name));

            var resultEmptyRead = program.StudentEmptyServiceClient.Read();
            Console.WriteLine(string.Format("rollno: {0}, name: {1}", resultRead.RollNo, resultRead.Name));

            var resultEmptyList = program.StudentEmptyServiceClient.List();

            var nameEmptyResult = program.StudentEmptyServiceClient.EmptyMethod("GetName");
            Console.WriteLine(string.Format("Name Result: {0}", nameResult));

            Console.WriteLine("Hit enter to exit");
            Console.ReadLine();
        }
    }
}

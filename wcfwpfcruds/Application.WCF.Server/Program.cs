using System;

namespace Application.WCF.Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            CRUDSServer applicationServer = new CRUDSServer();
            applicationServer.OnMessageReporting += ApplicationServer_OnMessageReporting;

            Console.Out.WriteLine("CRUDS APPLICATION SERVER");
            Console.Out.WriteLine("STARTING SERVER");

            try
            {
                Console.Out.WriteLine("STARTING INDIGO SERVICES");
                applicationServer.StartServices();
                Console.Out.WriteLine("STARTING INDIGO SERVICES - OK");
                Console.Out.WriteLine("CRUDS APPLICATION SERVER IS UP");
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("STARTING INDIGO SERVICES - FAILED");
                Console.Out.WriteLine(ex.Message);
            }

            try
            {
                string inputCommand = "";

                do
                {
                    Console.Out.Write("\nCRUDS>");
                    inputCommand = System.Console.ReadLine();
                }
                while (!inputCommand.Equals("shutdown", StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }

            Console.Out.WriteLine("SHUTTING DOWN CRUDS APPLICATION SERVER");

            try
            {
                Console.Out.WriteLine("STOPPING INDIGO SERVICES");
                applicationServer.StopServices();
                Console.Out.WriteLine("STOPPING INDIGO SERVICES - OK");
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("STOPPING INDIGO SERVICES - FAILED");
                Console.Out.WriteLine(ex.Message);
            }

            System.Console.Out.WriteLine("CRUDS APPLICATION SERVER IS DOWN");
        }

        private static void ApplicationServer_OnMessageReporting(string message)
        {
            string formattedMessage = string.Format("{0} {1}", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"), message);
            System.Console.WriteLine(formattedMessage);
        }
    }
}

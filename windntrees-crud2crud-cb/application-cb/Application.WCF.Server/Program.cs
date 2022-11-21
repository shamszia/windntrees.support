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

            Console.Out.WriteLine("");
            Console.Out.WriteLine("CRUD2CRUD CB (Callback) Repository Example");
            Console.Out.WriteLine("==========================================");
            Console.Out.WriteLine("This program computes %age of server side input score value on all subscribed client side data channels (90%, 80%, 70%, and 60%).");
            Console.Out.WriteLine("================================================================");
            Console.Out.WriteLine("Example elaborates CRUD2CRUD interface CRUDM method scaling");
            Console.Out.WriteLine("in server and client side repositories.");
            Console.Out.WriteLine("With server and client side CRUD2CRUD interfacing (CB) repositories");
            Console.Out.WriteLine("channels establish al-round communication.");
            Console.Out.WriteLine("In addition to CRUDL operations (Create, Read, Update, Delete and List)");
            Console.Out.WriteLine("This example implements following CRUDM Scale (Read, Avg, Max, Min and FailScore)");
            Console.Out.WriteLine("in CB (Callback) Repositories.");
            Console.Out.WriteLine("================================================================");
            Console.Out.WriteLine("Use Following Console Commands To Operate This Program:");
            Console.Out.WriteLine("[make sure clients subscribe channels before executing commands]");
            Console.Out.WriteLine("================================================================");
            Console.Out.WriteLine("1. Create Score_Value (Create 100), initializes clients %age score to immediate input value.");
            Console.Out.WriteLine("2. Update Score_Value (Update 100), add clients %age score to existing immediate input value. Repeat this step for adding score.");
            Console.Out.WriteLine("   Repeat update command for adding score.");
            Console.Out.WriteLine("3. Max (Max), lists maximum input score values of all subscribed channels.");
            Console.Out.WriteLine("4. Min (Min), lists minimum input score values of all subscribed channels.");
            Console.Out.WriteLine("5. Avg (Avg), lists avg of %age score values of all subscribed channels.");
            Console.Out.WriteLine("6. FailScore (FailScore), lists total of %age fail score values of all subscribed channels.");
            Console.Out.WriteLine("================================================================");            
            Console.Out.WriteLine("CRUD2CRUD solves data communication problem, CRUDM scales method invocations without re-defining communication interface.");

            try
            {
                string inputCommand = "";

                do
                {
                    Console.Out.Write("\nCRUDS>");

                    inputCommand = System.Console.ReadLine();

                    if (!string.IsNullOrEmpty(inputCommand))
                    {
                        CRUDSServer.ExecuteCommand(inputCommand);
                    }
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

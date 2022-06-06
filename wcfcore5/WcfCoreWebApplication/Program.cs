using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreWCF.Configuration;

namespace WcfCoreWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options => {
                options.ListenLocalhost(9088);
                options.AllowSynchronousIO = true;
//                options.ListenLocalhost(8443, listenOptions =>
//                {
//                    listenOptions.UseHttps(httpsOptions =>
//                    {
//#if NET472
//                        httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
//#endif // NET472
//                    });
//                    if (Debugger.IsAttached)
//                    {
//                        listenOptions.UseConnectionLogging();
//                    }
//                });
            })
            .UseNetTcp(9089)
            .UseStartup<Startup>();
    }
}

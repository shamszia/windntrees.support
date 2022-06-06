using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindnTrees.ICRUDS.Standard;
using SharedLibrary;

namespace WcfCoreWebApplication
{
    public class Startup
    {
        private static readonly TimeSpan s_debugTimeout = TimeSpan.FromMinutes(20);

        private static CoreWCF.Channels.Binding ApplyDebugTimeouts(CoreWCF.Channels.Binding binding)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                binding.OpenTimeout =
                    binding.CloseTimeout =
                    binding.SendTimeout =
                    binding.ReceiveTimeout = s_debugTimeout;
            }
            return binding;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices()
                    .AddServiceModelMetadata();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseServiceModel(builder =>
            {
                void ConfigureSoapService<TService, TContract>(string serviceprefix) where TService : class
                {
                    Settings settings = new Settings().SetDefaults("localhost", serviceprefix);
                    builder.AddService<TService>()
                        .AddServiceEndpoint<TService, TContract>(
                            new WSHttpBinding(SecurityMode.None), settings.wsHttpAddressValidateUserPassword.LocalPath)
                        .AddServiceEndpoint<TService, TContract>(new BasicHttpBinding(),
                            settings.basicHttpAddress.LocalPath)
                        //.AddServiceEndpoint<TService, TContract>(new WSHttpBinding(SecurityMode.None),
                        //    settings.wsHttpAddress.LocalPath)
                        //.AddServiceEndpoint<TService, TContract>(new WSHttpBinding(SecurityMode.Transport),
                        //    settings.wsHttpsAddress.LocalPath)
                        .AddServiceEndpoint<TService, TContract>(new NetTcpBinding(),
                            settings.netTcpAddress.LocalPath);
                }

                ConfigureSoapService<DataService, IWCFService<Student>>(nameof(DataService));
                ConfigureSoapService<EmptyDataService, IEmptyService<Student>>(nameof(EmptyDataService));

                var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
                serviceMetadataBehavior.HttpGetEnabled = true;
                //serviceMetadataBehavior.HttpsGetEnabled = true;
            });
        }
    }
}

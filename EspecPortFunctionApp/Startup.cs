using EspecPortFunctionApp;
using EspecPortFunctionApp.Controllers.ProcessAnalyzes;
using EspecPortFunctionApp.Services.ProcessAnalyzes;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace EspecPortFunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder.Services.AddScoped<IProcessAnalyzesController, ProcessAnalyzesController>();
            builder.Services.AddScoped<IProcessAnalyzesService, ProcessAnalyzesService>();

            builder.Services.AddHttpContextAccessor();

        }
    }
}

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzFuncLocalDirectory.Startup))]

namespace AzFuncLocalDirectory
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var services = builder.Services;
            var context = builder.GetContext();
            services.AddSingleton<AzureFunctionsServiceConfig>(new AzureFunctionsServiceConfig(context));
        }
    }
    public class AzureFunctionsServiceConfig
    {
        public AzureFunctionsServiceConfig(FunctionsHostBuilderContext context)
        {
            RootDirectory = context.ApplicationRootPath;
        }

        public string RootDirectory { get; }
    }

}
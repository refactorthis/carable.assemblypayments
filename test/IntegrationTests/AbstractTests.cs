using System;
using Carable.AssemblyPayments.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public abstract class AbstractTests
    {
        private static IServiceProvider CreateDi()
        {
            var services = new ServiceCollection();
            services.AddAssemblyPayments(new AssemblyPaymentsSettings
            {
                ApiUrl = "https://test.api.promisepay.com",
                Login = "idsidorov@gmail.com",
                Password = "mJrUGo2Vxuo9zqMVAvkw"
            });
            services.AddOptions();
            services.AddLogging();
            return services.BuildServiceProvider();
        }


        protected TRepo Get<TRepo>() => CreateDi().GetRequiredService<TRepo>();
    }
}

using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Exceptions;
using Carable.AssemblyPayments.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class IOCTests
    {
        [Fact]
        public void Should_be_able_to_initialize_from_configuration()
        {
            var b = new ConfigurationBuilder();
            b.AddInMemoryCollection(new[] {
                new KeyValuePair<string, string>("ASM:ApiUrl", "https://someurl.com" ),
                new KeyValuePair<string, string>("ASM:Login", "somelogin" ),
                new KeyValuePair<string, string>("ASM:Password", "somepassword" )
            });
            var Configuration = b.Build();
            var services = new ServiceCollection();

            services.AddOptions();
            services.Configure<AssemblyPaymentsSettings>(Configuration.GetSection("ASM"));
            services.AddAssemblyPayments();
            services.AddLogging();

            var prov = services.BuildServiceProvider();
            var userRepo = prov.GetRequiredService<IUserRepository>();
        }

        [Fact]
        public void Should_fail_when_there_is_a_missing_url()
        {
            var b = new ConfigurationBuilder();
            b.AddInMemoryCollection(new[] {
                new KeyValuePair<string, string>("ASM:ApiUrl", "" ),
                new KeyValuePair<string, string>("ASM:Login", "somelogin" ),
                new KeyValuePair<string, string>("ASM:Password", "somepassword" )
            });
            var Configuration = b.Build();
            var services = new ServiceCollection();

            services.AddOptions();
            services.Configure<AssemblyPaymentsSettings>(Configuration.GetSection("ASM"));
            services.AddAssemblyPayments();
            services.AddLogging();

            var prov = services.BuildServiceProvider();
            Assert.Throws<MisconfigurationException>(() =>
            {
                var userRepo = prov.GetRequiredService<IUserRepository>();
            });
        }
    }
}

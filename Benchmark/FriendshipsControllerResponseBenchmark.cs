using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using App.TheDate;
using System;

namespace Benchmarks
{
    [InProcess]
    [MemoryDiagnoser]
    public class FriendshipsControllerResponseBenchmark
    {

        private HttpClient client;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(configuration =>
                {
                    configuration.ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                    });
                });

            client = factory.CreateClient();
        }

        [Benchmark]
        public Task GetResponseTime()
        {
            return client.GetAsync("/");
        }
    }
}

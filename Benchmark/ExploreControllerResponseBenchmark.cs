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
    public class ExploreControllerResponseBenchmark
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
        public Task GetIndex()
        {
            return client.GetAsync("/Explore/Index");
        }

        [Benchmark]
        public Task GetUsers()
        {
            return client.GetAsync("/Explore/Users");
        }

        [Benchmark]
        public Task GetUsersWithFiltrSortSearchParameters()
        {
            return client.GetAsync("/Explore/Users?searchString=Jennifer&" +
                "sortOrder=desc&" +
                "pageSize=10&" +
                "sortItem=date&" +
                "filtrFemale=false&" +
                "filtrMale=true");
        }
    }
}

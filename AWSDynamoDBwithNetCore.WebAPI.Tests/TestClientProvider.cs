using System;
using System.Collections.Generic;
using System.Text;
using AWSDynamoDBwithNetCore.WebAPI;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace AWSDynamoDBwithNetCore.WebAPI.Tests
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}

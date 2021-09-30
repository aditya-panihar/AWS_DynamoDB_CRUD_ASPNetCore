using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;

namespace AWSDynamoDBwithNetCore.WebAPI.Tests
{
    public class ProductAPITest
    {
        [Fact]
        public async Task GetAllProductTestAsync()
        {
            // Arrange
            var client = new TestClientProvider().Client;

            // Act
            var response = await client.GetAsync("/api/Product");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}

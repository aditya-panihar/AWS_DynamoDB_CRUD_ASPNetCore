using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace AWSDynamoDBwithNetCore.Domain.Models
{
    [DynamoDBTable("Product")]
    public class Product
    {
        [DynamoDBProperty("id")]
        [DynamoDBHashKey]
        public int Id { get; set; }

        [DynamoDBProperty("name")]
        public string Name { get; set; }

        [DynamoDBProperty("description")]
        public string Description { get; set; }

        [DynamoDBProperty("inStock")]
        public bool InStock { get; set; }

        [DynamoDBProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [DynamoDBProperty("createdOn")]
        public string CreatedOn { get; set; }
    }
}

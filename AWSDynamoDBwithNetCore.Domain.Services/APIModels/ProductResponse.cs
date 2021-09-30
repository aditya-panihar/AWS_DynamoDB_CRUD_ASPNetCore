using System;
using System.Collections.Generic;
using System.Text;

namespace AWSDynamoDBwithNetCore.Domain.Services.APIModels
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InStock { get; set; }
        public string Availability { get; set; }
    }
}

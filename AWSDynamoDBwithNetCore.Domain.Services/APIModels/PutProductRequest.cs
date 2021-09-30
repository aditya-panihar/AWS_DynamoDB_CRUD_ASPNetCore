using System;
using System.Collections.Generic;
using System.Text;

namespace AWSDynamoDBwithNetCore.Domain.Services.APIModels
{
    public class PutProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public bool IsAvailable { get; set; }
    }
}

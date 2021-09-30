using AWSDynamoDBwithNetCore.Domain.Services.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Services
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(AddProductRequest productRequest);
        Task<IEnumerable<ProductResponse>> GetAllProductAsync();
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(PutProductRequest productRequest);
        Task<bool> DeleteProductAsync(int id);
    }
}

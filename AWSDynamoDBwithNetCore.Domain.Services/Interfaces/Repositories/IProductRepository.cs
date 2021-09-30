using System;
using System.Collections.Generic;
using System.Text;
using AWSDynamoDBwithNetCore.Domain.Models;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}

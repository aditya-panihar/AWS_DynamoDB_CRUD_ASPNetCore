using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AWSDynamoDBwithNetCore.Domain.Models;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAmazonDynamoDB _client;
        private readonly DynamoDBContext _context;

        public ProductRepository(IAmazonDynamoDB client)
        {
            _client = client;
            _context = new DynamoDBContext(_client);
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            bool result = false;
            try
            {
                await _context.SaveAsync<Product>(product);

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                var result = await _context.ScanAsync<Product>(conditions).GetRemainingAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var result = await _context.LoadAsync<Product>(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            bool result = false;

            try
            {
                await _context.SaveAsync<Product>(product);

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            bool result = false;

            try
            {
                await _context.DeleteAsync<Product>(id);

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

using AWSDynamoDBwithNetCore.Domain.Models;
using AWSDynamoDBwithNetCore.Domain.Services.APIModels;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Repositories;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.Domain.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(AddProductRequest productRequest)
        {
            bool result = false;

            try
            {
                var objProduct = new Product
                {
                    Id = productRequest.Id,
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    InStock = productRequest.InStock,
                    IsAvailable = productRequest.IsAvailable,
                    CreatedOn = DateTime.Now.ToString()
                };

                result = await _productRepository.AddProductAsync(objProduct);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
            List<ProductResponse> lstProductResponse = null;

            try
            {
                var lstProduct = await _productRepository.GetAllProductAsync();

                if(lstProduct != null)
                {
                    lstProductResponse = new List<ProductResponse>();
                    foreach (var product in lstProduct)
                    {
                        var productReponse = new ProductResponse
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            InStock = product.InStock ? "Yes" : "No",
                            Availability = product.IsAvailable ? "Available" : "Not Available"
                        };

                        lstProductResponse.Add(productReponse);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lstProductResponse;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            ProductResponse productResponse = null;

            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);

                if (product != null)
                {
                    productResponse = new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        InStock = product.InStock ? "Yes" : "No",
                        Availability = product.IsAvailable ? "Available" : "Not Available"
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }

            return productResponse;
        }

        public async Task<bool> UpdateProductAsync(PutProductRequest productRequest)
        {
            try
            {
                var objProduct = new Product
                {
                    Id = productRequest.Id,
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    InStock = productRequest.InStock,
                    IsAvailable = productRequest.IsAvailable,
                    CreatedOn = DateTime.Now.ToString()
                };

                return await _productRepository.UpdateProductAsync(objProduct);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                return await _productRepository.DeleteProductAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

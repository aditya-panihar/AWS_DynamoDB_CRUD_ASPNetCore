using AWSDynamoDBwithNetCore.Domain.Services.APIModels;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Services;
using AWSDynamoDBwithNetCore.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.WebAPI.Controllers
{
    [TypeFilter(typeof(ResponseTimeActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductRequest productRequest)
        {
            try
            {
                var response = await _productService.AddProductAsync(productRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                var response = await _productService.GetAllProductAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(PutProductRequest productRequest)
        {
            try
            {
                var response = await _productService.UpdateProductAsync(productRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

    }
}

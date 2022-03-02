using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductInfoDto>> CreateAsync([FromBody] ProductInfoDto productInfoDto)
        {
            Ensure.Any.IsNotNull(productInfoDto, nameof(productInfoDto));
            var asset = await _productService.AddAsync(productInfoDto);
            return Created(Endpoints.Product, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductInfoDto productInfoDto)
        {
            Ensure.Any.IsNotNull(productInfoDto, nameof(productInfoDto));
            await _productService.UpdateAsync(productInfoDto);

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            Ensure.Any.IsNotNull(updateProductDto, nameof(UpdateProductDto));
            await _productService.UpdateByIdAsync(id, updateProductDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productInfoDto = await _productService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productInfoDto, nameof(productInfoDto));
            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductInfoDto> GetByIdAsync(Guid id)
            => await _productService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductInfoDto>> GetAsync()
            => await _productService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _productService.PagedQueryAsync(name, page, limit);
    }
}

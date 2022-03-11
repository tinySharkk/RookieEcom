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
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService cityService)
        {
            _productImageService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductImageInfoDto>> CreateAsync([FromBody] ProductImageInfoDto productImageInfoDto)
        {
            Ensure.Any.IsNotNull(productImageInfoDto, nameof(productImageInfoDto));
            var asset = await _productImageService.AddAsync(productImageInfoDto);
            return Created(Endpoints.ProductImage, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductImageInfoDto productImageInfoDto)
        {
            Ensure.Any.IsNotNull(productImageInfoDto, nameof(productImageInfoDto));
            await _productImageService.UpdateAsync(productImageInfoDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id, [FromBody] UpdateProductImageDto updateProductImageDto)
        {
            Ensure.Any.IsNotNull(updateProductImageDto, nameof(ProductImageInfoDto));
            await _productImageService.UpdateByIdAsync(id, updateProductImageDto);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productImageInfoDto = await _productImageService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productImageInfoDto, nameof(productImageInfoDto));
            await _productImageService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductImageInfoDto> GetByIdAsync(Guid id)
            => await _productImageService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductImageInfoDto>> GetAsync()
            => await _productImageService.GetAllAsync();

       [HttpGet("find")]
        public async Task<PagedResponseModel<ProductImageInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _productImageService.PagedQueryAsync(name, page, limit);
    }
}

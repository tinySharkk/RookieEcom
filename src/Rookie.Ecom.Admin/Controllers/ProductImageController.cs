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
        private readonly IProductImageService _ProductImageService;
        public ProductImageController(IProductImageService cityService)
        {
            _ProductImageService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductImageInfoDto>> CreateAsync([FromBody] ProductImageInfoDto ProductImageInfoDto)
        {
            Ensure.Any.IsNotNull(ProductImageInfoDto, nameof(ProductImageInfoDto));
            var asset = await _ProductImageService.AddAsync(ProductImageInfoDto);
            return Created(Endpoints.ProductImage, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductImageInfoDto ProductImageInfoDto)
        {
            Ensure.Any.IsNotNull(ProductImageInfoDto, nameof(ProductImageInfoDto));
            await _ProductImageService.UpdateAsync(ProductImageInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ProductImageInfoDto = await _ProductImageService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ProductImageInfoDto, nameof(ProductImageInfoDto));
            await _ProductImageService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductImageInfoDto> GetByIdAsync(Guid id)
            => await _ProductImageService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductImageInfoDto>> GetAsync()
            => await _ProductImageService.GetAllAsync();

      /*  [HttpGet("find")]
        public async Task<PagedResponseModel<ProductImageInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _ProductImageService.PagedQueryAsync(name, page, limit);*/
    }
}

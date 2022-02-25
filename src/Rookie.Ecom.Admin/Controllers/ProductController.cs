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
        private readonly IProductService _ProductService;
        public ProductController(IProductService cityService)
        {
            _ProductService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductInfoDto>> CreateAsync([FromBody] ProductInfoDto ProductInfoDto)
        {
            Ensure.Any.IsNotNull(ProductInfoDto, nameof(ProductInfoDto));
            var asset = await _ProductService.AddAsync(ProductInfoDto);
            return Created(Endpoints.Product, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductInfoDto ProductInfoDto)
        {
            Ensure.Any.IsNotNull(ProductInfoDto, nameof(ProductInfoDto));
            await _ProductService.UpdateAsync(ProductInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ProductInfoDto = await _ProductService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ProductInfoDto, nameof(ProductInfoDto));
            await _ProductService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductInfoDto> GetByIdAsync(Guid id)
            => await _ProductService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductInfoDto>> GetAsync()
            => await _ProductService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _ProductService.PagedQueryAsync(name, page, limit);
    }
}

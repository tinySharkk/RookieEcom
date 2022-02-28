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
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        [HttpPost]
        public async Task<ActionResult<CartInfoDto>> CreateAsync([FromBody] CartInfoDto CartInfoDto)
        {
            Ensure.Any.IsNotNull(CartInfoDto, nameof(CartInfoDto));
            var asset = await _CartService.AddAsync(CartInfoDto);
            return Created(Endpoints.Cart, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CartInfoDto CartInfoDto)
        {
            Ensure.Any.IsNotNull(CartInfoDto, nameof(CartInfoDto));
            await _CartService.UpdateAsync(CartInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var CartInfoDto = await _CartService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(CartInfoDto, nameof(CartInfoDto));
            await _CartService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CartInfoDto> GetByIdAsync(Guid id)
            => await _CartService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CartInfoDto>> GetAsync()
            => await _CartService.GetAllAsync();

       /* [HttpGet("find")]
        public async Task<PagedResponseModel<CartInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _CartService.PagedQueryAsync(name, page, limit);*/
    }
}

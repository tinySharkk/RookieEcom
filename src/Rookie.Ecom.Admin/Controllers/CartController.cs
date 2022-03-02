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
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<ActionResult<CartInfoDto>> CreateAsync([FromBody] CartInfoDto cartInfoDto)
        {
            Ensure.Any.IsNotNull(cartInfoDto, nameof(cartInfoDto));
            var asset = await _cartService.AddAsync(cartInfoDto);
            return Created(Endpoints.Cart, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CartInfoDto cartInfoDto)
        {
            Ensure.Any.IsNotNull(cartInfoDto, nameof(cartInfoDto));
            await _cartService.UpdateAsync(cartInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var CartInfoDto = await _cartService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(CartInfoDto, nameof(CartInfoDto));
            await _cartService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CartInfoDto> GetByIdAsync(Guid id)
            => await _cartService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CartInfoDto>> GetAsync()
            => await _cartService.GetAllAsync();

       /* [HttpGet("find")]
        public async Task<PagedResponseModel<CartInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _cartService.PagedQueryAsync(name, page, limit);*/
    }
}

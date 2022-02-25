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
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService orderService)
        {
            _OrderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderInfoDto>> CreateAsync([FromBody] OrderInfoDto OrderInfoDto)
        {
            Ensure.Any.IsNotNull(OrderInfoDto, nameof(OrderInfoDto));
            var asset = await _OrderService.AddAsync(OrderInfoDto);
            return Created(Endpoints.Order, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderInfoDto OrderInfoDto)
        {
            Ensure.Any.IsNotNull(OrderInfoDto, nameof(OrderInfoDto));
            await _OrderService.UpdateAsync(OrderInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var OrderInfoDto = await _OrderService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(OrderInfoDto, nameof(OrderInfoDto));
            await _OrderService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderInfoDto> GetByIdAsync(Guid id)
            => await _OrderService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderInfoDto>> GetAsync()
            => await _OrderService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<OrderInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _OrderService.PagedQueryAsync(name, page, limit);*/
    }
}

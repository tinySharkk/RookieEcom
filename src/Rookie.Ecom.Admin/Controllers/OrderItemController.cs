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
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemInfoDto>> CreateAsync([FromBody] OrderItemInfoDto orderItemInfoDto)
        {
            Ensure.Any.IsNotNull(orderItemInfoDto, nameof(OrderItemInfoDto));
            var asset = await _orderItemService.AddAsync(orderItemInfoDto);
            return Created(Endpoints.Order, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderItemInfoDto orderItemInfoDto)
        {
            Ensure.Any.IsNotNull(orderItemInfoDto, nameof(orderItemInfoDto));
            await _orderItemService.UpdateAsync(orderItemInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var orderItemInfoDto = await _orderItemService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(orderItemInfoDto, nameof(orderItemInfoDto));
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderItemInfoDto> GetByIdAsync(Guid id)
            => await _orderItemService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderItemInfoDto>> GetAsync()
            => await _orderItemService.GetAllAsync();

      /*  [HttpGet("find")]
        public async Task<PagedResponseModel<OrderItemInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _orderItemService.PagedQueryAsync(name, page, limit);*/
    }
}

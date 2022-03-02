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
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderInfoDto>> CreateAsync([FromBody] OrderInfoDto orderInfoDto)
        {
            Ensure.Any.IsNotNull(orderInfoDto, nameof(orderInfoDto));
            var asset = await _orderService.AddAsync(orderInfoDto);
            return Created(Endpoints.Order, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderInfoDto OrderInfoDto)
        {
            Ensure.Any.IsNotNull(OrderInfoDto, nameof(OrderInfoDto));
            await _orderService.UpdateAsync(OrderInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var orderInfoDto = await _orderService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(orderInfoDto, nameof(orderInfoDto));
            await _orderService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderInfoDto> GetByIdAsync(Guid id)
            => await _orderService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderInfoDto>> GetAsync()
            => await _orderService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<OrderInfoDto>>
          FindAsync(string name, int page = 1, int limit = 10)
          => await _orderService.PagedQueryAsync(name, page, limit);*/
    }
}

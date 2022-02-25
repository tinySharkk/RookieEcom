using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemInfoDto>> GetAllAsync();

        //Task<PagedResponseModel<OrderItemInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<OrderItemInfoDto> GetByIdAsync(Guid id);

        Task<OrderItemInfoDto> GetByOrderIdAsync(Guid orderId);

        Task<OrderItemInfoDto> AddAsync(OrderItemInfoDto orderItemDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderItemInfoDto orderItemDto);
    }
}

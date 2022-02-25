using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderInfoDto>> GetAllAsync();

        //Task<PagedResponseModel<OrderDto>> PagedQueryAsync(string name, int page, int limit);

        Task<OrderInfoDto> GetByIdAsync(Guid id);

        Task<OrderInfoDto> GetByUserIdAsync(Guid userId);

        Task<OrderInfoDto> AddAsync(OrderInfoDto orderDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(OrderInfoDto orderDto);
    }
}

using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartInfoDto>> GetAllAsync();

        //Task<PagedResponseModel<CartInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<CartInfoDto> GetByIdAsync(Guid id);

        Task<CartInfoDto> GetByNameAsync(string name);

        Task<CartInfoDto> AddAsync(CartInfoDto cartInfoDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(CartInfoDto cartInfoDto);
    }
}

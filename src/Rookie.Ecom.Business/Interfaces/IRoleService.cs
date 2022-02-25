using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleInfoDto>> GetAllAsync();

        Task<PagedResponseModel<RoleInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<RoleInfoDto> GetByIdAsync(Guid id);

        Task<RoleInfoDto> GetByNameAsync(string name);

        Task<RoleInfoDto> AddAsync(RoleInfoDto roleDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(RoleInfoDto roleDto);
    }
}

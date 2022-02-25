using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountInfoDto>> GetAllAsync();

        Task<PagedResponseModel<UserAccountInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<UserAccountInfoDto> GetByIdAsync(Guid id);

        Task<UserAccountInfoDto> GetByUserNameAsync(string userName);

        //Task<UserAccountInfoDto> GetByNameAsync(string name);

        Task<UserAccountInfoDto> AddAsync(UserAccountInfoDto UserAccountInfoDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserAccountInfoDto UserAccountInfoDto);
    }
}

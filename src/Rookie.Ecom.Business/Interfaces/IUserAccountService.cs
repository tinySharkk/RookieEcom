using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountDto>> GetAllAsync();

        Task<PagedResponseModel<UserAccountDto>> PagedQueryAsync(string name, int page, int limit);

        Task<UserAccountDto> GetByUserNameAsync(string userName);

        //Task<UserAccountDto> GetByNameAsync(string name);

        Task<UserAccountDto> AddAsync(UserAccountDto userAccountDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserAccountDto userAccountDto);
    }
}

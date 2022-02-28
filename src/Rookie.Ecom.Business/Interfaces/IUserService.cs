using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfoDto>> GetAllAsync();

        Task<PagedResponseModel<UserInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<UserInfoDto> GetByIdAsync(Guid id);

        Task<UserInfoDto> GetByNameAsync(string name);

        Task<UserInfoDto> GetByEmailAsync(string email);

        Task<UserInfoDto> GetByPhoneNumber (string phoneNumber);

        Task<UserInfoDto> GetByRole(string role);

        Task<UserInfoDto> AddAsync(UserInfoDto addressDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserInfoDto userDto);
    }
}

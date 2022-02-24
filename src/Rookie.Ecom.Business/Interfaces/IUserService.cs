using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<PagedResponseModel<UserDto>> PagedQueryAsync(string name, int page, int limit);

        Task<UserDto> GetByIdAsync(Guid id);

        Task<UserDto> GetByNameAsync(string name);

        Task<UserDto> GetByEmailAsync(string email);

        Task<UserDto> GetByPhoneNumber (int phoneNumber);

        Task<UserDto> GetByRole(string role);

        Task<UserCreateDto> AddAsync(UserCreateDto addressDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserDto userDto);
    }
}

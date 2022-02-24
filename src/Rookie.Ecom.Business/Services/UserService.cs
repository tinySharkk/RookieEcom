using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<UserCreateDto> AddAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var item = await _baseRepository.AddAsync(user);
            return _mapper.Map<UserCreateDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByPhoneNumber(int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByRole(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<UserDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.FirstName.Contains(name));

            query = query.OrderBy(x => x.FirstName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<UserDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<UserDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _baseRepository.UpdateAsync(user);
        }
    }
}

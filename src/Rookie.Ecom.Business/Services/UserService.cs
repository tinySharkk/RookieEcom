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

        public async Task<UserInfoDto> AddAsync(UserInfoDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var item = await _baseRepository.AddAsync(user);
            return _mapper.Map<UserInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserInfoDto>> GetAllAsync()
        {
            var users = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserInfoDto>>(users);
        }

        public async Task<UserInfoDto> GetByEmailAsync(string email)
        {
            var user = await _baseRepository.GetByAsync(x => x.Email == email);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<UserInfoDto> GetByIdAsync(Guid id)
        {
            var user = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<UserInfoDto> GetByNameAsync(string name)
        {
            var user = await _baseRepository.GetByAsync(x => x.FirstName == name);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<UserInfoDto> GetByPhoneNumber(string phoneNumber)
        {
            var user = await _baseRepository.GetByAsync(x => x.PhoneNumber == phoneNumber);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<UserInfoDto> GetByRole(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<UserInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.FirstName.Contains(name));

            query = query.OrderBy(x => x.FirstName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<UserInfoDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<UserInfoDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(UserInfoDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _baseRepository.UpdateAsync(user);
        }
    }
}

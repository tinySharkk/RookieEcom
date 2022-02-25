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
    public class UserAccountService : IUserAccountService
    {
        private readonly IBaseRepository<UserAccount> _baseRepository;
        private readonly IMapper _mapper;

        public UserAccountService(IBaseRepository<UserAccount> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<UserAccountInfoDto> AddAsync(UserAccountInfoDto UserAccountInfoDto)
        {
            var userAccount = _mapper.Map<UserAccount>(UserAccountInfoDto);
            var item = await _baseRepository.AddAsync(userAccount);
            return _mapper.Map<UserAccountInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserAccountInfoDto>> GetAllAsync()
        {
            var userAccounts = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserAccountInfoDto>>(userAccounts);
        }

        public async Task<UserAccountInfoDto> GetByIdAsync(Guid id)
        {
            var user = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<UserAccountInfoDto>(user);
        }

        public async Task<UserAccountInfoDto> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<UserAccountInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserAccountInfoDto UserAccountInfoDto)
        {
            var userAccount = _mapper.Map<UserAccount>(UserAccountInfoDto);
            await _baseRepository.UpdateAsync(userAccount);
        }
    }
}

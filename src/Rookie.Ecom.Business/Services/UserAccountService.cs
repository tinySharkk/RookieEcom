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

        public async Task<UserAccountDto> AddAsync(UserAccountDto userAccountDto)
        {
            var userAccount = _mapper.Map<UserAccount>(userAccountDto);
            var item = await _baseRepository.AddAsync(userAccount);
            return _mapper.Map<UserAccountDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserAccountDto>> GetAllAsync()
        {
            var userAccounts = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserAccountDto>>(userAccounts);
        }

        public async Task<UserAccountDto> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<UserAccountDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserAccountDto userAccountDto)
        {
            var userAccount = _mapper.Map<UserAccount>(userAccountDto);
            await _baseRepository.UpdateAsync(userAccount);
        }
    }
}

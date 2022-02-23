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
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> _baseRepository;
        private readonly IMapper _mapper;

        public RoleService(IBaseRepository<Role> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> AddAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            var item = await _baseRepository.AddAsync(role);
            return _mapper.Map<RoleDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var role = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<RoleDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _baseRepository.UpdateAsync(role);
        }
    }
}

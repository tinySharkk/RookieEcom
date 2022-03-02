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

        public async Task<RoleInfoDto> AddAsync(RoleInfoDto roleInfoDto)
        {
            var role = _mapper.Map<Role>(roleInfoDto);
            var item = await _baseRepository.AddAsync(role);
            return _mapper.Map<RoleInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleInfoDto>> GetAllAsync()
        {
            var roles = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<RoleInfoDto>>(roles);
        }

        public async Task<RoleInfoDto> GetByIdAsync(Guid id)
        {
            var role = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<RoleInfoDto>(role);
        }

        public async Task<RoleInfoDto> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<RoleInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(RoleInfoDto roleInfoDto)
        {
            var role = _mapper.Map<Role>(roleInfoDto);
            await _baseRepository.UpdateAsync(role);
        }

        public async Task UpdateByIdAsync(Guid id, UpdateRoleDto updateRoleDto)
        {
            var role = await _baseRepository.GetByIdAsync(id);

            _mapper.Map(updateRoleDto, role);
            role.UpdatedDate = DateTime.Now;

            await _baseRepository.UpdateAsync(role);
        }
    }
}

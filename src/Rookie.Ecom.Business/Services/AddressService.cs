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
    internal class AddressService :IAddressService
    {
        private readonly IBaseRepository<Address> _baseRepository;
        private readonly IMapper _mapper;

        public AddressService(IBaseRepository<Address> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> AddAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            var item = await _baseRepository.AddAsync(address);
            return _mapper.Map<AddressDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresss = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<AddressDto>>(addresss);
        }

        public async Task<AddressDto> GetByCityIdAsync(Guid city)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDto> GetByIdAsync(Guid id)
        {
            var address = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<AddressDto>(address);
        }

        public async Task<AddressDto> GetByUserId(Guid user)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<AddressDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _baseRepository.UpdateAsync(address);
        }
    }
}

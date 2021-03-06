using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAsync();

        Task<PagedResponseModel<AddressDto>> PagedQueryAsync(string name, int page, int limit);

        Task<AddressDto> GetByIdAsync(Guid id);

        Task<AddressDto> GetByCityIdAsync(Guid cityId);

        Task<AddressDto> GetByUserId(Guid userId);


        Task<AddAddressDto> AddAsync(AddAddressDto addressDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(AddressInfoDto addressDto);

        Task UpdateByIdAsync (Guid id, UpdateAddressDto updateAddressDto);
    }
}

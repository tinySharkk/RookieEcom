using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<AddAddressDto>> CreateAsync([FromBody] AddAddressDto addressDto)
        {
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            var asset = await _addressService.AddAsync(addressDto);
            return Created(Endpoints.Address, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] AddressInfoDto addressDto)
        {
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            await _addressService.UpdateAsync(addressDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id ,[FromBody] UpdateAddressDto updateAddressDto)
        {
            Ensure.Any.IsNotNull(updateAddressDto, nameof(AddressDto));
            await _addressService.UpdateByIdAsync(id, updateAddressDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var AddressDto = await _addressService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(AddressDto, nameof(AddressDto));
            await _addressService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<AddressDto> GetByIdAsync(Guid id)
        {
            return await _addressService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<AddressDto>> GetAsync()
        {
            return await _addressService.GetAllAsync();
        }
    }
}

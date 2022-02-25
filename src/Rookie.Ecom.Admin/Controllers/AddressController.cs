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
        private readonly IAddressService _AddressService;
        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }

        [HttpPost]
        public async Task<ActionResult<AddressInfoDto>> CreateAsync([FromBody] AddressInfoDto addressDto)
        {
            Ensure.Any.IsNotNull(addressDto, nameof(addressDto));
            var asset = await _AddressService.AddAsync(addressDto);
            return Created(Endpoints.Address, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] AddressInfoDto AddressDto)
        {
            Ensure.Any.IsNotNull(AddressDto, nameof(AddressDto));
            await _AddressService.UpdateAsync(AddressDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var AddressDto = await _AddressService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(AddressDto, nameof(AddressDto));
            await _AddressService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<AddressDto> GetByIdAsync(Guid id)
        {
            return await _AddressService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<AddressDto>> GetAsync()
        {
            return await _AddressService.GetAllAsync();
        }
    }
}

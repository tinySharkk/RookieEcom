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
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _UserAccountService;
        public UserAccountController(IUserAccountService UserAccountService)
        {
            _UserAccountService = UserAccountService;
        }

        [HttpPost]
        public async Task<ActionResult<UserAccountDto>> CreateAsync([FromBody] UserAccountInfoDto UserAccountDto)
        {
            Ensure.Any.IsNotNull(UserAccountDto, nameof(UserAccountDto));
            var asset = await _UserAccountService.AddAsync(UserAccountDto);
            return Created(Endpoints.UserAccount, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserAccountInfoDto UserAccountDto)
        {
            Ensure.Any.IsNotNull(UserAccountDto, nameof(UserAccountDto));
            await _UserAccountService.UpdateAsync(UserAccountDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var UserAccountDto = await _UserAccountService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(UserAccountDto, nameof(UserAccountDto));
            await _UserAccountService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserAccountInfoDto> GetByIdAsync(Guid id)
        {
            return await _UserAccountService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserAccountInfoDto>> GetAsync()
        {
            return await _UserAccountService.GetAllAsync();
        }
    }
}

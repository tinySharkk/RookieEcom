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
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        public async Task<ActionResult<UserAccountDto>> CreateAsync([FromBody] UserAccountInfoDto userAccountDto)
        {
            Ensure.Any.IsNotNull(userAccountDto, nameof(userAccountDto));
            var asset = await _userAccountService.AddAsync(userAccountDto);
            return Created(Endpoints.UserAccount, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserAccountInfoDto userAccountDto)
        {
            Ensure.Any.IsNotNull(userAccountDto, nameof(userAccountDto));
            await _userAccountService.UpdateAsync(userAccountDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id, [FromBody] UpdateUserAccountDto updateUserAccountDto)
        {
            Ensure.Any.IsNotNull(updateUserAccountDto, nameof(updateUserAccountDto));
            await _userAccountService.UpdateByIdAsync(id, updateUserAccountDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var UserAccountDto = await _userAccountService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(UserAccountDto, nameof(UserAccountDto));
            await _userAccountService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserAccountInfoDto> GetByIdAsync(Guid id)
        {
            return await _userAccountService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserAccountInfoDto>> GetAsync()
        {
            return await _userAccountService.GetAllAsync();
        }
    }
}

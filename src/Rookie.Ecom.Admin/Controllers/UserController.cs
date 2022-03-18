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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] UserInfoDto userDto)
        {
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            var asset = await _userService.AddAsync(userDto);
            return Created(Endpoints.User, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserInfoDto userDto)
        {
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            await _userService.UpdateAsync(userDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateByIdAsync(Guid id,[FromBody] UpdateUserDto userDto)
        {
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            await _userService.UpdateByIdAsync(id, userDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var userDto = await _userService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(userDto, nameof(userDto));
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserInfoDto> GetByIdAsync(Guid id)
        { 
            return await _userService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserInfoDto>> GetAsync()
        { 
            return await _userService.GetAllAsync();
        }

        [HttpGet("find")]
        public async Task<PagedResponseModel<UserInfoDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _userService.PagedQueryAsync(name, page, limit);
    }
}

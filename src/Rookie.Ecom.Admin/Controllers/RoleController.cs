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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleInfoDto>> CreateAsync([FromBody] RoleInfoDto roleInfoDto)
        {
            Ensure.Any.IsNotNull(roleInfoDto, nameof(roleInfoDto));
            var asset = await _roleService.AddAsync(roleInfoDto);
            return Created(Endpoints.Role, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RoleInfoDto roleInfoDto)
        {
            Ensure.Any.IsNotNull(roleInfoDto, nameof(roleInfoDto));
            await _roleService.UpdateAsync(roleInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var RoleInfoDto = await _roleService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(RoleInfoDto, nameof(RoleInfoDto));
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RoleInfoDto> GetByIdAsync(Guid id)
            => await _roleService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RoleInfoDto>> GetAsync()
            => await _roleService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<RoleInfoDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _roleService.PagedQueryAsync(name, page, limit);
    }
}

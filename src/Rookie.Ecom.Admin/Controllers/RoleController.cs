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
        private readonly IRoleService _RoleService;
        public RoleController(IRoleService cityService)
        {
            _RoleService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleInfoDto>> CreateAsync([FromBody] RoleInfoDto RoleInfoDto)
        {
            Ensure.Any.IsNotNull(RoleInfoDto, nameof(RoleInfoDto));
            var asset = await _RoleService.AddAsync(RoleInfoDto);
            return Created(Endpoints.Role, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RoleInfoDto RoleInfoDto)
        {
            Ensure.Any.IsNotNull(RoleInfoDto, nameof(RoleInfoDto));
            await _RoleService.UpdateAsync(RoleInfoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var RoleInfoDto = await _RoleService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(RoleInfoDto, nameof(RoleInfoDto));
            await _RoleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RoleInfoDto> GetByIdAsync(Guid id)
            => await _RoleService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RoleInfoDto>> GetAsync()
            => await _RoleService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<RoleInfoDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _RoleService.PagedQueryAsync(name, page, limit);
    }
}

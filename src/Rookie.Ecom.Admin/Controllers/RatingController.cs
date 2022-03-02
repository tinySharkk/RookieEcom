﻿using EnsureThat;
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
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<ActionResult<RatingInfoDto>> CreateAsync([FromBody] RatingInfoDto ratingDto)
        {
            Ensure.Any.IsNotNull(ratingDto, nameof(ratingDto));
            var asset = await _ratingService.AddAsync(ratingDto);
            return Created(Endpoints.Rating, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RatingInfoDto ratingDto)
        {
            Ensure.Any.IsNotNull(ratingDto, nameof(ratingDto));
            await _ratingService.UpdateAsync(ratingDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ratingDto = await _ratingService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ratingDto, nameof(ratingDto));
            await _ratingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RatingInfoDto> GetByIdAsync(Guid id)
            => await _ratingService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RatingInfoDto>> GetAsync()
            => await _ratingService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<RatingInfoDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _ratingService.PagedQueryAsync(name, page, limit);
    }
}

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
    public class RatingService : IRatingService
    {
        private readonly IBaseRepository<Rating> _baseRepository;
        private readonly IMapper _mapper;

        public RatingService(IBaseRepository<Rating> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<RatingInfoDto> AddAsync(RatingInfoDto ratingInfoDto)
        {
            var rating = _mapper.Map<Rating>(ratingInfoDto);
            var item = await _baseRepository.AddAsync(rating);
            return _mapper.Map<RatingInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RatingInfoDto>> GetAllAsync()
        {
            var ratings = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<RatingInfoDto>>(ratings);
        }

        public async Task<RatingInfoDto> GetByIdAsync(Guid id)
        {
            var rating = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<RatingInfoDto>(rating);
        }

        public async Task<IEnumerable<RatingInfoDto>> GetByProductId(Guid productId)
        {
            var allRate = await _baseRepository.GetAllAsync();
            var rates = allRate.Where(x => x.ProductId == productId);

            return _mapper.Map<List<RatingInfoDto>>(rates);
        }

        public async Task<RatingInfoDto> GetByStar(int star)
        {
            throw new NotImplementedException();
        }

        public async Task<RatingInfoDto> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<RatingInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(RatingInfoDto RatingInfoDto)
        {
            var rating = _mapper.Map<Rating>(RatingInfoDto);
            await _baseRepository.UpdateAsync(rating);
        }

        public async Task UpdateByIdAsync(Guid id, UpdateRatingDto updateRatingDto)
        {
            var rating = await _baseRepository.GetByIdAsync(id);

            _mapper.Map(updateRatingDto, rating);
            rating.UpdatedDate = DateTime.Now; 

            await _baseRepository.UpdateAsync(rating);
        }
    }
}

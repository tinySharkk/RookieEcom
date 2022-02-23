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

        public async Task<RatingDto> AddAsync(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            var item = await _baseRepository.AddAsync(rating);
            return _mapper.Map<RatingDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RatingDto>> GetAllAsync()
        {
            var ratings = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<RatingDto>>(ratings);
        }

        public async Task<RatingDto> GetByIdAsync(Guid id)
        {
            var rating = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<RatingDto>(rating);
        }

        public async Task<RatingDto> GetByProductId(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<RatingDto> GetByStar(int star)
        {
            throw new NotImplementedException();
        }

        public async Task<RatingDto> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<RatingDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            await _baseRepository.UpdateAsync(rating);
        }
    }
}

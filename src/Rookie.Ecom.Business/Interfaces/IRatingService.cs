using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rookie.Ecom.Business.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingInfoDto>> GetAllAsync();

        Task<PagedResponseModel<RatingInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<RatingInfoDto> GetByIdAsync(Guid id);

        Task<RatingInfoDto> GetByUserIdAsync(Guid userId);

        Task<IEnumerable<RatingInfoDto>> GetByProductId(Guid productId);

        Task<RatingInfoDto> GetByStar(int star);

        Task<RatingInfoDto> AddAsync(RatingInfoDto ratingDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(RatingInfoDto ratingDto);

        Task UpdateByIdAsync(Guid id, UpdateRatingDto updateRatingDto);
    }
}

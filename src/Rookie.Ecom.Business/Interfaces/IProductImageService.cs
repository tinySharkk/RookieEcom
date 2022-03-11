using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageInfoDto>> GetAllAsync();

        Task<IEnumerable<ProductImageInfoDto>> GetAllByProductIdAsync(Guid productId);

        Task<PagedResponseModel<ProductImageInfoDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductImageInfoDto> GetByIdAsync(Guid id);

        Task<ProductImageInfoDto> GetByProductIdAsync(Guid productId);

        Task<ProductImageInfoDto> AddAsync(ProductImageInfoDto productImageDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductImageInfoDto productImageDto);

        Task UpdateByIdAsync(Guid id, UpdateProductImageDto updateProductImageDto);
    }
}

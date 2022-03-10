using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductInfoDto>> GetAllAsync();

        Task<IEnumerable<ProductInfoDto>> GetTopFeatureAsync(int limit);

        Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string? name, int page, int limit);

        Task<PagedResponseModel<ProductDto>> PagedQueryByCategoryAsync(Guid? category, int page, int limit);

        Task<ProductInfoDto> GetByIdAsync(Guid id);

        Task<ProductInfoDto> GetByNameAsync(string name);

        Task<ProductInfoDto> GetByCategory(Guid categoryId);

        Task<ProductInfoDto> AddAsync(ProductInfoDto productDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductInfoDto productDto);

        Task UpdateByIdAsync(Guid id, UpdateProductDto updateProductDto);
    }
}

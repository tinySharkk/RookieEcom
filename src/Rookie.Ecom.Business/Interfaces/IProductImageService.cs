using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    internal interface IProductImageService
    {
        Task<IEnumerable<ProductImageDto>> GetAllAsync();

        //Task<PagedResponseModel<ProductImageDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductImageDto> GetByIdAsync(Guid id);

        Task<ProductImageDto> GetByProductIdAsync(Guid productId);

        Task<ProductImageDto> AddAsync(ProductImageDto productImageDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductImageDto productImageDto);
    }
}

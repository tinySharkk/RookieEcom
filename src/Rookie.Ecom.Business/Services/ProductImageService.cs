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
    public class ProductImageService : IProductImageService
    {
        private readonly IBaseRepository<ProductImage> _baseRepository;
        private readonly IMapper _mapper;

        public ProductImageService(IBaseRepository<ProductImage> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductImageDto> AddAsync(ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            var item = await _baseRepository.AddAsync(productImage);
            return _mapper.Map<ProductImageDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductImageDto>> GetAllAsync()
        {
            var images = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductImageDto>>(images);
        }

        public async Task<ProductImageDto> GetByIdAsync(Guid id)
        {
            var productImage = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductImageDto>(productImage);
        }

        public async Task<ProductImageDto> GetByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<ProductImageDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            await _baseRepository.UpdateAsync(productImage);
        }
    }
}

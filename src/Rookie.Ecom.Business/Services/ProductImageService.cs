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

        public async Task<ProductImageInfoDto> AddAsync(ProductImageInfoDto ProductImageInfoDto)
        {
            var productImage = _mapper.Map<ProductImage>(ProductImageInfoDto);
            var item = await _baseRepository.AddAsync(productImage);
            return _mapper.Map<ProductImageInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductImageInfoDto>> GetAllAsync()
        {
            var images = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductImageInfoDto>>(images);
        }

        public async Task<ProductImageInfoDto> GetByIdAsync(Guid id)
        {
            var productImage = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductImageInfoDto>(productImage);
        }

        public async Task<ProductImageInfoDto> GetByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

       /* public async Task<PagedResponseModel<ProductImageInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }*/

        public async Task UpdateAsync(ProductImageInfoDto ProductImageInfoDto)
        {
            var productImage = _mapper.Map<ProductImage>(ProductImageInfoDto);
            await _baseRepository.UpdateAsync(productImage);
        }
    }
}

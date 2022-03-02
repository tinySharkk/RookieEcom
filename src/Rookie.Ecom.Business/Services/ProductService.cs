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
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductInfoDto> AddAsync(ProductInfoDto productInfoDto)
        {
            var product = _mapper.Map<Product>(productInfoDto);
            var item = await _baseRepository.AddAsync(product);
            return _mapper.Map<ProductInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductInfoDto>> GetAllAsync()
        {
            var products = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductInfoDto>>(products);
        }

        public async Task<ProductInfoDto> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductInfoDto> GetByIdAsync(Guid id)
        {
            var product = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductInfoDto>(product);
        }

        public async Task<ProductInfoDto> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<ProductInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductInfoDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductInfoDto>>(assets.Items)
            };
        }

        public async Task UpdateAsync(ProductInfoDto ProductInfoDto)
        {
            var product = _mapper.Map<Product>(ProductInfoDto);
            await _baseRepository.UpdateAsync(product);
        }

        public async Task UpdateByIdAsync(Guid id, UpdateProductDto updateProductDto)
        {
            var product = await _baseRepository.GetByIdAsync(id);

            _mapper.Map(updateProductDto, product);
            product.UpdatedDate = DateTime.Now;

            await _baseRepository.UpdateAsync(product);

        }
    }
}

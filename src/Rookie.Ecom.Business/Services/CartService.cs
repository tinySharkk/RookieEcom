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
    public class CartService : ICartService
    {
        private readonly IBaseRepository<Cart> _baseRepository;
        private readonly IMapper _mapper;

        public CartService(IBaseRepository<Cart> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CartInfoDto> AddAsync(CartInfoDto CartInfoDto)
        {
            var Cart = _mapper.Map<Cart>(CartInfoDto);
            var item = await _baseRepository.AddAsync(Cart);
            return _mapper.Map<CartInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CartInfoDto>> GetAllAsync()
        {
            var Carts = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<CartInfoDto>>(Carts);
        }

        public async Task<CartInfoDto> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartInfoDto> GetByIdAsync(Guid id)
        {
            var Cart = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CartInfoDto>(Cart);
        }

        public async Task<CartInfoDto> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        /*public async Task<PagedResponseModel<CartInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Id.Contains(name));

            query = query.OrderBy(x => x.Id);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<CartInfoDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CartInfoDto>>(assets.Items)
            };
        }*/

        public async Task UpdateAsync(CartInfoDto CartInfoDto)
        {
            var Cart = _mapper.Map<Cart>(CartInfoDto);
            await _baseRepository.UpdateAsync(Cart);
        }
    }
}

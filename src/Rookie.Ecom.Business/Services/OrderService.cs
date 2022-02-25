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
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _baseRepository;
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<OrderInfoDto> AddAsync(OrderInfoDto OrderInfoDto)
        {
            var order = _mapper.Map<Order>(OrderInfoDto);
            var item = await _baseRepository.AddAsync(order);
            return _mapper.Map<OrderInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderInfoDto>> GetAllAsync()
        {
            var orders = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderInfoDto>>(orders);
        }

        public async Task<OrderInfoDto> GetByIdAsync(Guid id)
        {
            var order = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderInfoDto>(order);
        }

        public async Task<OrderInfoDto> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

      /*  public async Task<PagedResponseModel<OrderInfoDto>> PagedQueryAsync(Guid name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Id.Contains(name));

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<CategoryDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CategoryDto>>(assets.Items)
            };
        }*/

        public async Task UpdateAsync(OrderInfoDto OrderInfoDto)
        {
            var order = _mapper.Map<Order>(OrderInfoDto);
            await _baseRepository.UpdateAsync(order);
        }
    }
}

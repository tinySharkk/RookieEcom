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
    public class OrderItemService : IOrderItemService
    {
        private readonly IBaseRepository<OrderItem> _baseRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IBaseRepository<OrderItem> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<OrderItemInfoDto> AddAsync(OrderItemInfoDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var item = await _baseRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderItemInfoDto>> GetAllAsync()
        {
            var orderItems = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderItemInfoDto>>(orderItems);
        }

        public async Task<OrderItemInfoDto> GetByIdAsync(Guid id)
        {
            var orderItem = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemInfoDto>(orderItem);
        }

        public async Task<OrderItemInfoDto> GetByOrderIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        /*public async Task<PagedResponseModel<OrderItemInfoDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x..Contains(name));

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

        public async Task UpdateAsync(OrderItemInfoDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _baseRepository.UpdateAsync(orderItem);
        }
    }
}

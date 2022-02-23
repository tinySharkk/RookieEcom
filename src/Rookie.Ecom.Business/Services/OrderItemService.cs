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
        public async Task<OrderItemDto> AddAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var item = await _baseRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var orderItems = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            var orderItem = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<OrderItemDto> GetByOrderIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponseModel<OrderItemDto>> PagedQueryAsync(string name, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _baseRepository.UpdateAsync(orderItem);
        }
    }
}

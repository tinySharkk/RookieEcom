using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public Guid? ShippingAdressId { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderItemDto> orderItems { get; set; }

        public UserDto User { get; set; }
    }

    public class OrderInfoDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public Guid? ShippingAdressId { get; set; }

        public OrderStatus Status { get; set; }

    }
}

public enum OrderStatus
{
    pending,
    processing,
    complete,
    cancel,
}
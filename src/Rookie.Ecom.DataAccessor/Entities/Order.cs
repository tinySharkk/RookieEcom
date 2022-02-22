using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid? ShippingAdressId { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> orderItems { get; set; }

        public User User { get; set; }

    }
}

public enum OrderStatus
{
    pending,
    processing,
    complete,
    cancel,
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderItemDto : BaseDto
    {
        public Guid? OrderId { get; set; }

        public Guid? ProductId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public OrderDto Order { get; set; }

        public ProductDto Product { get; set; }
    }

    public class OrderItemInfoDto : BaseDto
    {
        public Guid? OrderId { get; set; }

        public Guid? ProductId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

    }
}

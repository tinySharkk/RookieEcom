using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    internal class OrderItem : BaseEntity
    {
        [Required]
        public Guid? OrderId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}

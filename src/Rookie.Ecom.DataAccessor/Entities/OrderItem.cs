using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public Guid? OrderId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue,ErrorMessage = "Price must larger than 0.")]
        public int Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must larger than 0.")]
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}

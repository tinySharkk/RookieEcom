using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CartDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public UserDto User { get; set; }

        public ProductDto Product { get; set; }
    }

    public class CartInfoDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class AddCartDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class UpdateCartDto
    {
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class RatingDto : BaseDto
    {
        public Guid? UserId { get; set; }
        public Guid? ProductId { get; set; }

        public float Star { get; set; }

        public string Feedback { get; set; }

        public ProductDto Product { get; set; }

        public UserDto User { get; set; }
    }
}

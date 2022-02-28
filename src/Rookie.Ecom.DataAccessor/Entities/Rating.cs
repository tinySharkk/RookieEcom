using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Rating : BaseEntity
    {
        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Star must between {1} and {2}.")]
        public float Star { get; set; }

        public string Feedback  { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    internal class Rating : BaseEntity
    {
        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public float Star { get; set; }

        public string Feedback  { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }
    }
}

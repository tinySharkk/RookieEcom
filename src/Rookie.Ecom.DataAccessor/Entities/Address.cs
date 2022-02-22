using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    internal class Address : BaseEntity
    {
        public Guid? UserId { get; set; }

        [Required]
        public string AddressLine { get; set; }

        [Required]
        public Guid? CityId { get; set; }

        public City City { get; set; }

        public User User { get; set; }


    }
}

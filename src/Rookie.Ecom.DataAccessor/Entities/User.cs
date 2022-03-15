using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class User : BaseEntity
    {
        public static IEnumerable<object> Claims { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string LastName { get; set; }

        [Required]
        public UserGender Gender { get; set; }

        [StringLength(maximumLength:50)]
        public string Email { get; set; }

        [StringLength(maximumLength:10, MinimumLength =10, ErrorMessage = "Phone number must have 10 character")]
        public string PhoneNumber { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public UserAccount UserAccount { get; set; }

    }
}

public enum UserGender { 
    Male,
    Female,
    Other,
}

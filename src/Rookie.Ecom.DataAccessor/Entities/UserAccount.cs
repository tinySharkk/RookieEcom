using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class UserAccount : BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public User User { get; set; }


    }
}

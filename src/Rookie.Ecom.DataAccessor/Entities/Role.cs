using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public string RoleName { get; set; }

        public ICollection<User> User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserAccountDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid? UserId { get; set; }

        public UserDto User { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid? CreatorId { get; set; }

        public bool Pubished { get; set; }
    }
}

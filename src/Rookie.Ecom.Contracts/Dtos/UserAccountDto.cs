using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserAccountDto : BaseDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid? UserId { get; set; }

        public UserDto User { get; set; }

    }

    public class UserAccountInfoDto : BaseDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid? UserId { get; set; }

    }

}

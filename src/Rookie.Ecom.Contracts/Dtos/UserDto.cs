using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserGender Gender { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public ICollection<RoleDto> Roles { get; set; }

        public ICollection<OrderDto> Orders { get; set; }
    }
    public class UserInfoDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserGender Gender { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

    }
}

public enum UserGender
{
    Male,
    Female,
}
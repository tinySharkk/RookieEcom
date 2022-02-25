using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class AddressDto : BaseDto
    {
        public Guid? UserId { get; set; }

        public string AddressLine { get; set; }

        public Guid? CityId { get; set; }

        public CityDto City { get; set; }

        public UserDto User { get; set; }
    }
    public class AddressInfoDto : BaseDto
    {
        public Guid? UserId { get; set; }

        public string AddressLine { get; set; }

        public Guid? CityId { get; set; }

    }
}

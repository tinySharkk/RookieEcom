using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    internal class City :BaseEntity
    {
        [Required]
        public string CityName { get; set; }
    }
}

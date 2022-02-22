using System;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class ProductImage : BaseEntity
    {
        [StringLength(maximumLength: 500)]
        public string ImageUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }

        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
    }
}

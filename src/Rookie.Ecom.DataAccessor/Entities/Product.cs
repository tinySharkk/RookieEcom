using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must larger than 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "InStock must larger than 0.")]
        public int InStock { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        public Guid? CategoryId { get; set; }

        public ICollection<Category> Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}

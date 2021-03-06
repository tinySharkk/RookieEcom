using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<ProductImageDto> ProductImages { get; set; }
    }

    public class ProductInfoDto : BaseDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? CategoryId { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? CategoryId { get; set; }
    }
}

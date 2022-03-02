using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductImageDto : BaseDto
    {
        public string PictureUrl { get; set; }

        public string Title { get; set; }

        public Guid? ProductId { get; set; }

        public ProductDto Product { get; set; }
    }

    public class ProductImageInfoDto : BaseDto
    {
        public string PictureUrl { get; set; }

        public string Title { get; set; }

        public Guid? ProductId { get; set; }

    }

    public class UpdateProductImageDto
    {
        public string PictureUrl { get; set; }

        public string Title { get; set; }
    }
}

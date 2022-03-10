using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Image { get; set; }

    }

    public class CategoryInfoDto : BaseDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }
        public string Image { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string Name { get; set; }

        public string Desc { get; set; }
        public string Image { get; set; }
    }
}

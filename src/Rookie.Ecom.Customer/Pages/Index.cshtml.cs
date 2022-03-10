using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Microsoft.Extensions.Configuration;

namespace Rookie.Ecom.Customer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService, IProductService productService, IProductImageService productImageService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
            _productImageService = productImageService;     
        }

        public IEnumerable<ProductInfoDto> products { get; set; }
        public IEnumerable<CategoryDto> categorys { get; set; }
        public ProductImageInfoDto prodImage { get; set; }

        public async Task<string> productImage(Guid productId)
        {
            prodImage = await _productImageService.GetByProductIdAsync(productId);

            return prodImage.ImageUrl;
            //return "1eMRUN40mByRkFWBS2R1N1ZFFZGCrxdYx";
        }

        public async Task OnGet()
        {
            categorys = await _categoryService.GetAllAsync();
            products = await _productService.GetTopFeatureAsync(10);
        }
    }
}

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
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public ProductDetailModel(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public ProductInfoDto product { get; set; }
        public IEnumerable<ProductImageInfoDto> productImages{ get; set; }

        public async Task OnGet(Guid productId)
        {
            product = await _productService.GetByIdAsync(productId);
            productImages = await _productImageService.GetAllByProductIdAsync(productId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System;
using Rookie.Ecom.Business.Interfaces;
using System.Collections.Generic;
using Rookie.Ecom.Contracts.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly ICartService _cartService;

        public CartModel(IProductService productService, IProductImageService productImageService, ICartService cartService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _cartService = cartService;
        }

        public IEnumerable<CartInfoDto> carts { get; set; }

        public ProductInfoDto product { get; set; }

        public ProductImageInfoDto prodImage { get; set; }

        public async Task<string> productImage(Guid productId)
        {
            prodImage = await _productImageService.GetByProductIdAsync(productId);

            return prodImage.ImageUrl;
            //return "1eMRUN40mByRkFWBS2R1N1ZFFZGCrxdYx";
        }

        public async Task<string> productName(Guid productId)
        {
            product = await _productService.GetByIdAsync(productId);
            return product.Name;
        }

        public async Task<decimal> productPrice(Guid productId)
        {
            product = await _productService.GetByIdAsync(productId);
            return product.Price;
        }


        public async Task OnGet()
        {
            var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;
            carts = await _cartService.GetAllByUserIdAsync(Guid.Parse(userId));
        }
    }
}

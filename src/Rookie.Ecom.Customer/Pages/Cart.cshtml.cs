using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System;
using Rookie.Ecom.Business.Interfaces;
using System.Collections.Generic;
using Rookie.Ecom.Contracts.Dtos;

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

        public async void OnGet()
        {
            //carts = await _cartService.PagedQueryAsync(userId);
        }
    }
}

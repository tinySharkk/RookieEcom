using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Linq;

namespace Rookie.Ecom.Customer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult AddToCart(string Quanlity, string ProductId)
        {
            var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;

            var cart = new CartInfoDto
            {
                Id = Guid.NewGuid(),
                Quantity = int.Parse(Quanlity),
                UserId = Guid.Parse(userId),
                ProductId = Guid.Parse(ProductId),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatorId = Guid.Parse(userId),
                Pubished = true,
            };

            _cartService.AddAsync(cart);
            return Redirect("/ProductDetail?productId=" + ProductId);

        }
    }
}

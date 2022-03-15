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
    public class RatingController : Controller
    {

        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }


        public IActionResult Rating(string Comment, string Rating, string ProductId)
        {
            var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;

            var rate = new RatingInfoDto
            {
                Id = Guid.NewGuid(),
                Feedback = Comment,
                UserId = Guid.Parse(userId),
                ProductId = Guid.Parse(ProductId),
                Star = int.Parse(Rating),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatorId = Guid.Parse(userId),
            };

            _ratingService.AddAsync(rate);
            return Redirect("/ProductDetail?productId=" + ProductId);

        }
    }
}

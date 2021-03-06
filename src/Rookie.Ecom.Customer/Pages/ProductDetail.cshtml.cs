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
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IRatingService _ratingService;

        public ProductDetailModel(IProductService productService, IProductImageService productImageService, IRatingService ratingService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _ratingService = ratingService;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string productId { get; set; }

        public ProductInfoDto product { get; set; }
        public IEnumerable<ProductImageInfoDto> productImages{ get; set; }
        public IEnumerable<RatingInfoDto> productRatings { get;set; }

        public int rating =5;

        public float ratingStar;

        //Guid? productId;
        public async Task OnGet(Guid productId)
        {
            product = await _productService.GetByIdAsync(productId);
            productImages = await _productImageService.GetAllByProductIdAsync(productId);
            productRatings = await _ratingService.GetByProductId(productId);

            if (productRatings.Count() != 0)
            {
                ratingStar = productRatings.Average(x => x.Star);
            }

            //this.productId = product.Id;
            this.productId = productId.ToString();
        }

        [Authorize]
        public async Task<IActionResult> OnPostRatingAsync(string Comment, Guid productId)
        {

            var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;

            Guid id = Guid.Parse(userId);

            var rating = new RatingInfoDto
            {
                UserId = id,
                ProductId = productId,
                Feedback = Comment,
                Star = this.rating,
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatorId = id,
                Pubished = true,
            };
            await _ratingService.AddAsync(rating);

            return Page();
        }
    }
}

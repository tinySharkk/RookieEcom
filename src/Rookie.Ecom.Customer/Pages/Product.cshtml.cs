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

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductModel(IProductService productService)
        {
            _productService = productService;
        }


        public int currentPage { get; set; } = 1;
        public int pageItems { get; set; } = 12;
        public PagedResponseModel<ProductDto> listProduct { get; set; }

        public async Task OnGet()
        {
            listProduct = await _productService.PagedQueryAsync(null, currentPage, pageItems);
        }
    }
}

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
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IConfiguration _configuration;

        public ProductModel(IProductService productService, ICategoryService categoryService, IConfiguration configuration)
        {
            _productService = productService;
            _categoryService = categoryService;
            _configuration = configuration;
        }

        public int currentPage ;

        public string category = null;
        public int pageItems { get; set; } = 1;
        public PagedResponseModel<ProductDto> products { get; set; }
        public IEnumerable<CategoryDto> categorys { get; set; }

        public async Task OnGet(Guid? categoryId, int? pageNo)
        {
            currentPage = pageNo == null ? 1 : pageNo.Value ;

            if (categoryId == null)
            {

                products = await _productService.PagedQueryAsync(null, currentPage, pageItems);
            }
            else
            {
                category = categoryId.Value.ToString();
                products = await _productService.PagedQueryByCategoryAsync(categoryId, currentPage, pageItems);
            }

            categorys = await _categoryService.GetAllAsync();

           
        }
    }
}

using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class UserAccountModel : PageModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public UserGender Gender { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }


        private readonly ILogger<UserAccountModel> _logger;
        private readonly IUserService _userService;

        public UserAccountModel(ILogger<UserAccountModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public void OnGet()
        {
            /*var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;

            Guid id = Guid.Parse(userId);

            var _userExits = _userService.GetByIdAsync(id);

            if (_userExits != null)
            {
                return RedirectToPage("/Index");
            }

            return null;*/
        }

        public void OnPost()
        {
            
        }

        public async Task<IActionResult> OnPostAccountAsync(string FirstName, string LastName, string Email, string PhoneNumber, string Gender)
        {

            var userId = User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value;

            Guid id = Guid.Parse(userId);

            var usergender = Rookie.Ecom.Contracts.Dtos.UserGender.Male;

            switch (Gender)
            {
                case "Male":
                    usergender = Rookie.Ecom.Contracts.Dtos.UserGender.Male;
                    break;
                case "Femail":
                    usergender = Rookie.Ecom.Contracts.Dtos.UserGender.Female;
                    break;
            }

            var userAccount = new UserInfoDto
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Gender = usergender,
                Email = Email,
                Id = id,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatorId = id,
                Pubished = true,
            };
            await _userService.AddAsync(userAccount);

            return Redirect("/Index");
        }

        public enum UserGender
        {
            Male,
            Femail,
        }

    }

    
}

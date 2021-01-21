using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Server.Models;
namespace TimeTracker.Server.Areas.Identity.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        // *************************************************
        // This is the user that will be automatically 
        // made an Administrator
        // *************************************************
        const string SETUP_USERNAME = "Admin@email";
        const string SETUP_ROLE = "Setup";
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(100, ErrorMessage =
                "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage =
                "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins =
                (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins =
                (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .ToList();
            if (ModelState.IsValid)
            {
                var user =
                    new ApplicationUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email
                    };
                var result =
                    await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    // Set confirm Email for user
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    // ensure there is a SETUP_ROLE
                    var RoleResult =
                        await _roleManager.FindByNameAsync(SETUP_ROLE);
                    if (RoleResult == null)
                    {
                        // Create SETUP_ROLE Role
                        await _roleManager.CreateAsync(
                            new IdentityRole(SETUP_ROLE));
                    }
                    if (user.UserName.ToLower() == SETUP_USERNAME.ToLower())
                    {
                        // Put admin in setup role
                        await _userManager.AddToRoleAsync(user, SETUP_ROLE);
                    }
                    // Log user in
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
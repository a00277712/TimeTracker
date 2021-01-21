using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TimeTracker.Server.Data;
using TimeTracker.Server.Models;
using TimeTracker.Server.Services;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class SetupUsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public SetupUsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
        }

        [HttpGet]
        [Authorize]
        [Route("api/users")]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/{id}")]
        public IActionResult GetUsers(string id)
        {
            return Ok(_context.Users.Find(id));
        }

        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/users/create")]
        public async Task<IActionResult> Create(UserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                //email user
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                var message = new Message(new string[] { user.Email }, "Welcome to Time tracker", $"Please set your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                _emailSender.SendEmail(message);

                return Ok(user.Id);
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Ok(ModelState);
        }

        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/users/edit")]
        public IActionResult Edit(ApplicationUser dto)
        {
            var user = _context.Users.Find(dto.Id);
            user.UserName = dto.UserName;
            user.NormalizedUserName = dto.UserName.ToUpper();
            user.PhoneNumber = dto.PhoneNumber;
            user.Email = dto.Email;
            user.NormalizedEmail = dto.Email.ToUpper();

            _context.SaveChanges();

            return Ok(user.Id);
        }

        [HttpDelete]
        [Authorize(Roles = "Setup")]
        [Route("api/users/delete/{id}")]
        public IActionResult Delete(string id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Setup")]
        [Route("api/users/unique/email/{email?}")]
        public IActionResult IsEmailUnique(string email = null)
        {
            if (email == null)
            {
                return Ok(true);
            }
            return Ok(!_context.Users.Any(x => x.Email == email));
        }

        [HttpGet]
        [Authorize(Roles = "Setup")]
        [Route("api/users/unique/username/{username?}")]
        public IActionResult IsUsernameUnique(string username = null)
        {
            if(username == null)
            {
                return Ok(true);
            }
            return Ok(!_context.Users.Any(x => x.UserName == username));
        }

    }
}

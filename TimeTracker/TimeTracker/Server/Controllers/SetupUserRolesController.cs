using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeTracker.Server.Models;

namespace TimeTracker.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class SetupUserRolesController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [Route("api/roles/{userId}")]
        public IActionResult GetRoles(string userId)
        {
            using var db = new ModelContext();

            return Ok(db.VwUserRoles.Where(x => x.UserId == userId).ToList());
        }

        [HttpPost]
        [Route("api/roles/set")]
        [Authorize(Roles = "Setup")]
        public IActionResult SetRole(VwUserRoles dto)
        {
            using var db = new ModelContext();

            var user = db.AspNetUsers.FirstOrDefault(x => x.Id == dto.UserId);

            if (user != null)
            {
                var userRole = db.AspNetUserRoles.FirstOrDefault(x => x.RoleId == dto.RoleId && x.UserId == dto.UserId);

                if (dto.Assigned ?? false && userRole == null)
                {
                    var newrole = new AspNetUserRoles
                    {
                        UserId = dto.UserId,
                        RoleId = dto.RoleId
                    };

                    if (newrole != null)
                    {
                        user.AspNetUserRoles.Add(newrole);
                    }
                }

                if (!dto.Assigned.Value && userRole != null)
                {
                    user.AspNetUserRoles.Remove(userRole);
                }

                db.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using TimeTracker.Server.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [Route("api/time/{id}")]
        public IActionResult GetTimeById(int id)
        {
            using var db = new ModelContext();
            return Ok(db.Time.Find(id));
        }

        [HttpPost]
        [Authorize]
        [Route("api/times")]
        public IActionResult GetTimesByDate(DateDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(db.VwTime.Where(x => x.WorkDate == dto.Date && x.UserId == userId).ToList());
        }

        [HttpPost]
        [Authorize]
        [Route("api/time/create")]
        public IActionResult Create(TimeDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var time = new Time
            {
                UserId = userId,
                TaskId = dto.TaskId,
                WorkDate = dto.WorkDate,
                Hours = dto.Hours,
                Comment = dto.Comment,
                Location = dto.Location,
                BillableTypeId = dto.BillableTypeId,

                CreatedById = userId,
                DateCreated = date,
                LastModifiedById = userId,
                DateLastModified = date,

                Deleted = false
            };

            db.Time.Add(time);

            return Ok(db.SaveChanges());
        }

        [HttpPost]
        [Authorize]
        [Route("api/time/edit")]
        public IActionResult Edit(TimeDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var time = db.Time.Find(dto.Id);

            time.TaskId = dto.TaskId;
            time.WorkDate = dto.WorkDate;
            time.Hours = dto.Hours;
            time.Comment = dto.Comment;
            time.Location = dto.Location;
            time.BillableTypeId = dto.BillableTypeId;

            time.LastModifiedById = userId;
            time.DateLastModified = date;

            return Ok(db.SaveChanges());
        }

        [HttpDelete]
        [Authorize]
        [Route("api/time/delete/{id}")]
        public IActionResult Delete(int id)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var time = db.Time.Find(id);

            time.LastModifiedById = userId;
            time.DateLastModified = date;

            time.Deleted = true;

            return Ok(db.SaveChanges());
        }
    }
}

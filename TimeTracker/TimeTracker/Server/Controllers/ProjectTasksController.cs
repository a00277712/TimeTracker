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
    public class ProjectTasksController : ControllerBase
    {
        [Route("api/project/tasks")]
        public IActionResult Get()
        {
            using var db = new ModelContext();

            return Ok(db.Tasks
                .Where(x => !x.Deleted)
                .OrderBy(x => x.TaskNo)
                .ToList());
        }

        [Route("api/project/tasks/{projectId}")]
        public IActionResult GetByProjectId(int projectId)
        {
            using var db = new ModelContext();

            return Ok(db.Tasks
                .Where(x => x.ProjectId == projectId
                            && !x.Deleted)
                .OrderBy(x => x.TaskNo)
                .ToList());
        }

        [HttpGet]
        [Route("api/project/task/{id}")]
        public IActionResult GetTaskById(int id)
        {
            using var db = new ModelContext();
            return Ok(db.Tasks.Find(id));
        }

        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/project/task/create")]
        public IActionResult Create(TaskDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var task = new Tasks
            {
                ProjectId = dto.ProjectId,
                Title = dto.Title,
                TaskNo = dto.TaskNo,

                CreatedById = userId,
                DateCreated = date,
                LastModifiedById = userId,
                DateLastModified = date,

                Deleted = false
            };

            db.Tasks.Add(task);

            return Ok(db.SaveChanges());
        }

        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/project/task/edit")]
        public IActionResult Edit(TaskDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var task = db.Tasks.Find(dto.Id);

            task.ProjectId = dto.ProjectId;
            task.Title = dto.Title;
            task.TaskNo = dto.TaskNo;

            task.LastModifiedById = userId;
            task.DateLastModified = date;

            return Ok(db.SaveChanges());
        }

        [HttpDelete]
        [Authorize(Roles = "Setup")]
        [Route("api/project/task/delete/{id}")]
        public IActionResult Delete(int id)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var task = db.Tasks.Find(id);

            task.LastModifiedById = userId;
            task.DateLastModified = date;

            task.Deleted = true;

            return Ok(db.SaveChanges());
        }
    }
}

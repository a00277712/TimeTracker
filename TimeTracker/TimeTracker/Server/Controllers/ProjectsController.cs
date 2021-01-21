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
    public class ProjectsController : ControllerBase
    {
        [Route("api/projects")]
        public IActionResult Get()
        {
            using var db = new ModelContext();

            var projects = db.Projects
                .Where(x => x.Deleted == false)
                .ToList();

            return Ok(projects);
        }

        [HttpGet]
        [Route("api/projects/{id}")]
        public IActionResult GetProjectById(int id)
        {
            using var db = new ModelContext();
            return Ok(db.Projects.Find(id));
        }

        [HttpGet]
        [Route("api/projects/templates")]
        public IActionResult GetProjectTemplates()
        {
            using var db = new ModelContext();
            return Ok(db.ProjectTemplates.Select(x => x.ProjectType).Distinct().ToArray());
        }

        [HttpPost]
        [Authorize(Roles ="Setup")]
        [Route("api/projects/create")]
        public IActionResult Create(ProjectDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var project = new Projects
                    {
                        Code = dto.Code,
                        Title = dto.Title,
                        Description = dto.Description,
                        Client = dto.Client,
                        ClientContact = dto.ClientContact,
                        Notes = dto.Notes,
                        StartDate = dto.StartDate,
                        EndDate = dto.EndDate,
                        CommercialCover = dto.CommercialCover,
                        ProjectDeliverables = dto.ProjectDeliverables,
                        DataProcessing = dto.DataProcessing,
                        BudgetDays = dto.BudgetDays,
                        ProjectManagerId = dto.ProjectManagerId,
                        ContactEmail = dto.ContactEmail,
                        ReferenceProcesses = dto.ReferenceProcesses,

                        CreatedById = userId,
                        DateCreated = date,
                        LastModifiedById = userId,
                        DateLastModified = date,

                        Deleted = false
                    };

            db.Projects.Add(project);

            db.SaveChanges();

            if(dto.ProjectTemplate != null)
            {
                var projectTemplateTasks = db.ProjectTemplates.Where(x => x.ProjectType == dto.ProjectTemplate);

                foreach(var task in projectTemplateTasks)
                {
                    db.Tasks.Add(new Tasks
                    {
                        ProjectId = project.Id,
                        Title = task.TaskTitle,
                        TaskNo = task.TaskNo,

                        DateCreated = date,
                        CreatedById = userId,
                        LastModifiedById = userId,
                        DateLastModified = date,

                        Deleted = false
                    });
                }
            }

            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/projects/edit")]
        public IActionResult Edit(ProjectDto dto)
        {
            using var db = new ModelContext();

            var project = db.Projects.Find(dto.Id);
            project.Code = dto.Code;
            project.Title = dto.Title;
            project.Description = dto.Description;
            project.Client = dto.Client;
            project.ClientContact = dto.ClientContact;
            project.Notes = dto.Notes;
            project.StartDate = dto.StartDate;
            project.EndDate = dto.EndDate;
            project.CommercialCover = dto.CommercialCover;
            project.ProjectDeliverables = dto.ProjectDeliverables;
            project.DataProcessing = dto.DataProcessing;
            project.BudgetDays = dto.BudgetDays;
            project.ProjectManagerId = dto.ProjectManagerId;
            project.ContactEmail = dto.ContactEmail;
            project.ReferenceProcesses = dto.ReferenceProcesses;

            project.LastModifiedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            project.DateLastModified = DateTime.Now;

            return Ok(db.SaveChanges());
        }

        [HttpDelete]
        [Authorize(Roles = "Setup")]
        [Route("api/projects/delete/{id}")]
        public IActionResult Delete(int id)
        {
            using var db = new ModelContext();

            var project = db.Projects.Find(id);

            project.LastModifiedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            project.DateLastModified = DateTime.Now;

            project.Deleted = true;

            return Ok(db.SaveChanges());
        }

        [HttpGet]
        [Authorize(Roles = "Setup")]
        [Route("api/projects/unique/code/{code?}")]
        public IActionResult IsEmailUnique(string code = null)
        {
            if (code == null)
            {
                return Ok(true);
            }

            using var db = new ModelContext();
            return Ok(!db.Projects.Any(x => x.Code == code));
        }

        [HttpGet]
        [Authorize(Roles = "Setup")]
        [Route("api/projects/unique/title/{title?}")]
        public IActionResult IsUsernameUnique(string title = null)
        {
            if (title == null)
            {
                return Ok(true);
            }
            using var db = new ModelContext();
            return Ok(!db.Projects.Any(x => x.Title == title));
        }
    }
}

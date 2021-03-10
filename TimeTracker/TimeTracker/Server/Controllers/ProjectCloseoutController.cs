using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using TimeTracker.Server.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Controllers
{
    [ApiController]
    [Authorize(Roles = "Setup")]
    public class ProjectCloseoutController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Setup")]
        [Route("api/project/closeout/create")]
        public IActionResult Create(ProjectCloseoutDto dto)
        {
            using var db = new ModelContext();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var date = DateTime.Now;

            var projectCloseout = new ProjectCloseouts
            {
                ProjectId = dto.ProjectId,
                CloseoutReasonId = dto.CloseoutReasonId,
                CommercialMilestonesComplete = dto.CommercialMilestonesComplete,
                DeliverablesComplete = dto.DeliverablesComplete,
                CustomerDataManagement = dto.CustomerDataManagement,
                SalesLearnings = dto.SalesLearnings,
                OpsLearnings = dto.OpsLearnings,
                LearningActions = dto.LearningActions,
                FollowUpActions = dto.FollowUpActions,
                CommercialScoreId = dto.CommercialScoreId,
                OperationalScoreId = dto.OperationalScoreId,
                BusinessDevelopmentScoreId = dto.BusinessDevelopmentScoreId,
                ReputationalScoreId = dto.ReputationalScoreId,
                ResourceProfileScoreId = dto.ResourceProfileScoreId,
                ProjectScore = dto.ProjectScore,
                CustomerFeedback = dto.CustomerFeedback,
                DataPurged = dto.DataPurged,
                CaseStudy = dto.CaseStudy,
                FeedBack = dto.FeedBack,

                CreatedById = userId,
                DateCreated = date
            };

            db.ProjectCloseouts.Add(projectCloseout);

            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Setup")]
        [Route("api/project/closeout/vw")]
        public IActionResult GetVw()
        {
            using var db = new ModelContext();
            ProjectCloseoutVw vw = new ProjectCloseoutVw
            {
                CloseoutReasons = db.CloseoutReasons
                .Select(x => new DropdownDto() { Id = x.Id, Text = x.Text})
                .ToList(),

                CommercialScores = db.CommercialScores
                .Select(x => new ScoredDropdownDto() { Id = x.Id, Score = x.Value, Text = x.Text })
                .ToList(),

                OperationalScores = db.OperationalScores
                .Select(x => new ScoredDropdownDto() { Id = x.Id, Score = x.Value, Text = x.Text })
                .ToList(),

                BusDevScores = db.BusinessDevelopmentScores
                .Select(x => new ScoredDropdownDto() { Id = x.Id, Score = x.Value, Text = x.Text })
                .ToList(),

                RepScores = db.ReputationalScores
                .Select(x => new ScoredDropdownDto() { Id = x.Id, Score = x.Value, Text = x.Text })
                .ToList(),

                ResProfScores = db.ResourceProfileScores
                .Select(x => new ScoredDropdownDto() { Id = x.Id, Score = x.Value, Text = x.Text })
                .ToList()
            };

            return Ok(vw);
        }
    }
}

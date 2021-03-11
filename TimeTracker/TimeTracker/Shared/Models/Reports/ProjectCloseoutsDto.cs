using System;

namespace TimeTracker.Shared.Models.Reports
{
    public class ProjectCloseoutsDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Client { get; set; }
        public string CloseoutReason { get; set; }
        public bool CommercialMilestonesComplete { get; set; }
        public bool DeliverablesComplete { get; set; }
        public string CustomerDataManagement { get; set; }
        public string SalesLearnings { get; set; }
        public string Opslearnings { get; set; }
        public string LearningActions { get; set; }
        public string FollowUpActions { get; set; }
        public string CommercialScore { get; set; }
        public string OperationalScore { get; set; }
        public string BusinessDevelopmentScore { get; set; }
        public string ReputationalScore { get; set; }
        public string ResourceProfileScore { get; set; }
        public int ProjectScore { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Feedback { get; set; }
        public bool CustomerFeedback { get; set; }
        public bool DataPurged { get; set; }
        public bool CaseStudy { get; set; }
    }
}

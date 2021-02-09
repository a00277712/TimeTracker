using System;

namespace TimeTracker.Shared.Models.Reports
{
    class ProjectCloseoutsDto
    {
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public string CloseoutReason { get; set; }
        public bool CommercialMilestonesComplete { get; set; }
        public bool DeliverablesComplete { get; set; }
        public bool CustomerDataManagement { get; set; }
        public string SalesLearnings { get; set; }
        public string Opslearnings { get; set; }
        public string LearningActions { get; set; }
        public string FollowUpActions { get; set; }
        public int CommercialScore { get; set; }
        public int OperationalScore { get; set; }
        public int BuisnessDevelopmentScore { get; set; }
        public int ReputationalScore { get; set; }
        public int ProjectScore { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public bool FeedbackRecieved { get; set; }
        public string CustomerFeedback { get; set; }
        public bool DataPurged { get; set; }
        public bool CaseStudy { get; set; }
    }
}

using System;

namespace TimeTracker.Server.Models
{
    public partial class ProjectCloseouts
    {
        public int ProjectId { get; set; }
        public int CloseoutReasonId { get; set; }
        public bool CommercialMilestonesComplete { get; set; }
        public bool DeliverablesComplete { get; set; }
        public string CustomerDataManagement { get; set; }
        public string SalesLearnings { get; set; }
        public string OpsLearnings { get; set; }
        public string LearningActions { get; set; }
        public string FollowUpActions { get; set; }
        public int CommercialScoreId { get; set; }
        public int OperationalScoreId { get; set; }
        public int BusinessDevelopmentScoreId { get; set; }
        public int ReputationalScoreId { get; set; }
        public int ResourceProfileScoreId { get; set; }
        public int ProjectScore { get; set; }
        public DateTime DateCreated { get; set; }
        public bool CustomerFeedback { get; set; }
        public bool DataPurged { get; set; }
        public bool CaseStudy { get; set; }
        public string FeedBack { get; set; }
        public string CreatedById { get; set; }

        public virtual BusinessDevelopmentScores BusinessDevelopmentScore { get; set; }
        public virtual CloseoutReasons CloseoutReason { get; set; }
        public virtual CommercialScores CommercialScore { get; set; }
        public virtual AspNetUsers CreatedBy { get; set; }
        public virtual OperationalScores OperationalScore { get; set; }
        public virtual Projects Project { get; set; }
        public virtual ReputationalScores ReputationalScore { get; set; }
        public virtual ResourceProfileScores ResourceProfileScore { get; set; }
    }
}

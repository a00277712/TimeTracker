using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class ProjectCloseoutDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Project Id missing")]
        public int ProjectId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Closeout Reason Required")]
        public int CloseoutReasonId { get; set; }
        public bool CommercialMilestonesComplete { get; set; }
        public bool DeliverablesComplete { get; set; }
        public string CustomerDataManagement { get; set; }
        public string SalesLearnings { get; set; }
        public string OpsLearnings { get; set; }
        public string LearningActions { get; set; }
        public string FollowUpActions { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Commercial Score Required")]
        public int CommercialScoreId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Operational Score Required")]
        public int OperationalScoreId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Business Development Score Required")]
        public int BusinessDevelopmentScoreId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Reputational Score Id Required")]
        public int ReputationalScoreId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Resource Profile Score Required")]
        public int ResourceProfileScoreId { get; set; }
        public int ProjectScore { get; set; }
        public bool CustomerFeedback { get; set; }
        public bool DataPurged { get; set; }
        public bool CaseStudy { get; set; }
        public string FeedBack { get; set; }
    }
}

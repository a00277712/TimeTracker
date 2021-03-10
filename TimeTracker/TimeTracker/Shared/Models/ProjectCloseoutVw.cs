using System.Collections.Generic;

namespace TimeTracker.Shared.Models
{
    public class ProjectCloseoutVw
    {
        public List<DropdownDto> CloseoutReasons { get; set; }
        public List<ScoredDropdownDto> CommercialScores { get; set; }
        public List<ScoredDropdownDto> OperationalScores { get; set; }
        public List<ScoredDropdownDto> BusDevScores { get; set; }
        public List<ScoredDropdownDto> RepScores { get; set; }
        public List<ScoredDropdownDto> ResProfScores { get; set; }
    }
}

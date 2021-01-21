using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class ReputationalScores
    {
        public ReputationalScores()
        {
            ProjectCloseouts = new HashSet<ProjectCloseouts>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }

        public virtual ICollection<ProjectCloseouts> ProjectCloseouts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class ResourceProfileScores
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
    }
}

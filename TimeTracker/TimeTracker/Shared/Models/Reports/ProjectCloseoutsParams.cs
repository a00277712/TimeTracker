﻿using System;

namespace TimeTracker.Shared.Models
{
    class ProjectCloseoutsParams
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Client { get; set; }
        public string ProjectTitle { get; set; }
    }
}
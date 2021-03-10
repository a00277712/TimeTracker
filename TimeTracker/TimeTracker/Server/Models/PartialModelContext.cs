using Microsoft.EntityFrameworkCore;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Models
{
    public partial class ModelContext
    {
        public virtual DbSet<MonthSummaryByWeekDto> MonthSummaryByWeekDto { get; set; }
        public virtual DbSet<MonthSummaryByUserDto> MonthSummaryByUserDto { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder builder)
        {
            builder.Entity<MonthSummaryByWeekDto>().HasNoKey();
            builder.Entity<MonthSummaryByUserDto>().HasNoKey();
        }
    }
}

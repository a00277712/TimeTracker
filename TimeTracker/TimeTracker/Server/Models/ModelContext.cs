﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BillableType> BillableType { get; set; }
        public virtual DbSet<BusinessDevelopmentScores> BusinessDevelopmentScores { get; set; }
        public virtual DbSet<CloseoutReasons> CloseoutReasons { get; set; }
        public virtual DbSet<ClosoutReasons> ClosoutReasons { get; set; }
        public virtual DbSet<CommercialScores> CommercialScores { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<OperationalScores> OperationalScores { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<ProjectCloseouts> ProjectCloseouts { get; set; }
        public virtual DbSet<ProjectLog> ProjectLog { get; set; }
        public virtual DbSet<ProjectTemplates> ProjectTemplates { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ReputationalScores> ReputationalScores { get; set; }
        public virtual DbSet<ResourceProfileScores> ResourceProfileScores { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<VwHoursEntered> VwHoursEntered { get; set; }
        public virtual DbSet<VwLatestProjectLog> VwLatestProjectLog { get; set; }
        public virtual DbSet<VwProjectCloseouts> VwProjectCloseouts { get; set; }
        public virtual DbSet<VwProjectDashboard> VwProjectDashboard { get; set; }
        public virtual DbSet<VwTasks> VwTasks { get; set; }
        public virtual DbSet<VwTime> VwTime { get; set; }
        public virtual DbSet<VwTimeProjectUser> VwTimeProjectUser { get; set; }
        public virtual DbSet<VwUserRoles> VwUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=maps-dev-db;Database=TimeTracker;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(512);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(512);
            });

            modelBuilder.Entity<BillableType>(entity =>
            {
                entity.Property(e => e.CreatedById).HasMaxLength(1800);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedById).HasMaxLength(1800);

                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<BusinessDevelopmentScores>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<CloseoutReasons>(entity =>
            {
                entity.Property(e => e.CreatedById).HasMaxLength(1800);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedById).HasMaxLength(1800);

                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<ClosoutReasons>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<CommercialScores>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(800);

                entity.Property(e => e.DeviceCode).HasMaxLength(400);

                entity.Property(e => e.SubjectId).HasMaxLength(800);
            });

            modelBuilder.Entity<OperationalScores>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(400);

                entity.Property(e => e.SubjectId).HasMaxLength(400);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<ProjectCloseouts>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CustomerDataManagement).IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FeedBack).IsUnicode(false);

                entity.Property(e => e.FollowUpActions).IsUnicode(false);

                entity.Property(e => e.LearningActions).IsUnicode(false);

                entity.Property(e => e.OpsLearnings).IsUnicode(false);

                entity.Property(e => e.SalesLearnings).IsUnicode(false);

                entity.HasOne(d => d.BusinessDevelopmentScore)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.BusinessDevelopmentScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_BusinessDevelopmentScores");

                entity.HasOne(d => d.CloseoutReason)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.CloseoutReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_CloseoutReasons1");

                entity.HasOne(d => d.CommercialScore)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.CommercialScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_CommercialScores");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_AspNetUsers");

                entity.HasOne(d => d.OperationalScore)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.OperationalScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_OperationalScores");

                entity.HasOne(d => d.Project)
                    .WithOne(p => p.ProjectCloseouts)
                    .HasForeignKey<ProjectCloseouts>(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_Projects");

                entity.HasOne(d => d.ReputationalScore)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.ReputationalScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_ReputationalScores");

                entity.HasOne(d => d.ResourceProfileScore)
                    .WithMany(p => p.ProjectCloseouts)
                    .HasForeignKey(d => d.ResourceProfileScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCloseouts_ResourceProfileScores");
            });

            modelBuilder.Entity<ProjectLog>(entity =>
            {
                entity.Property(e => e.CreatedById).HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectLog)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectLog_AspNetUsers");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectLog)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectLog_Projects");
            });

            modelBuilder.Entity<ProjectTemplates>(entity =>
            {
                entity.Property(e => e.ProjectType).HasMaxLength(200);

                entity.Property(e => e.TaskTitle).HasMaxLength(200);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Client).HasMaxLength(200);

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.CreatedById).HasMaxLength(1800);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LastModifiedById).HasMaxLength(1800);

                entity.Property(e => e.ProjectManagerId).HasMaxLength(1800);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<ReputationalScores>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<ResourceProfileScores>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.CreatedById).HasMaxLength(1800);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedById).HasMaxLength(1800);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Projects");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastModified).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.LastModifiedById).HasMaxLength(450);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.WorkDate).HasColumnType("date");

                entity.HasOne(d => d.BillableType)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.BillableTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time_BillableType");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time_Tasks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Time)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time_AspNetUsers");
            });

            modelBuilder.Entity<VwHoursEntered>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwHoursEntered");

                entity.Property(e => e.BillableType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Client).HasMaxLength(200);

                entity.Property(e => e.Comments).IsRequired();

                entity.Property(e => e.Days).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Hours).HasColumnType("numeric(38, 2)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProjectCode).HasMaxLength(200);

                entity.Property(e => e.ProjectTitle).HasMaxLength(200);

                entity.Property(e => e.TaskTitle)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.WorkDate).HasColumnType("date");
            });

            modelBuilder.Entity<VwLatestProjectLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwLatestProjectLog");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwProjectCloseouts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProjectCloseouts");

                entity.Property(e => e.BusinessDevelopmentScore).HasMaxLength(200);

                entity.Property(e => e.CaseStudy).HasColumnName("caseStudy");

                entity.Property(e => e.Client).HasMaxLength(200);

                entity.Property(e => e.CloseoutReason).HasMaxLength(200);

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.CommercialScore).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(512);

                entity.Property(e => e.CustomerDataManagement).IsUnicode(false);

                entity.Property(e => e.DataPurged).HasColumnName("dataPurged");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FeedBack).IsUnicode(false);

                entity.Property(e => e.FollowUpActions).IsUnicode(false);

                entity.Property(e => e.LearningActions).IsUnicode(false);

                entity.Property(e => e.OperationalScore).HasMaxLength(200);

                entity.Property(e => e.OpsLearnings).IsUnicode(false);

                entity.Property(e => e.ReputationalScore).HasMaxLength(200);

                entity.Property(e => e.ResourceProfileScore).HasMaxLength(200);

                entity.Property(e => e.SalesLearnings).IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<VwProjectDashboard>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwProjectDashboard");

                entity.Property(e => e.Client).HasMaxLength(200);

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Lead).HasMaxLength(512);

                entity.Property(e => e.ProjectLog).IsUnicode(false);

                entity.Property(e => e.ProjectLogDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<VwTasks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTasks");

                entity.Property(e => e.DisplayText).HasMaxLength(213);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SpentDays).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<VwTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTime");

                entity.Property(e => e.Billable).HasMaxLength(50);

                entity.Property(e => e.Hours).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.ProjectTitle).HasMaxLength(50);

                entity.Property(e => e.TaskTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.WorkDate).HasColumnType("date");
            });

            modelBuilder.Entity<VwTimeProjectUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTimeProjectUser");

                entity.Property(e => e.Hrs)
                    .HasColumnName("hrs")
                    .HasColumnType("numeric(38, 2)");

                entity.Property(e => e.UserName).HasMaxLength(512);
            });

            modelBuilder.Entity<VwUserRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUserRoles");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.RoleName).HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using WorkAssistantApp.Data.Models;
using WorkAssistantApp.Helpers;

namespace WorkAssistantApp.Data
{
    public class WorkAssistantDbContext : DbContext
    {
        public WorkAssistantDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
    new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region ApplicationUser
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>().HasOne(u => u.StatusCurrent).WithOne(s => s.User);
            builder.Entity<ApplicationUser>().HasMany(u => u.StatusEvents).WithOne(s => s.User);
            #endregion

            #region StatusCurrent
            builder.Entity<StatusCurrent>().ToTable("StatusCurrents");
            builder.Entity<StatusCurrent>().Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Entity<StatusCurrent>().HasOne(s => s.User).WithOne(u => u.StatusCurrent);
            builder.Entity<StatusCurrent>().HasOne(s => s.Project)
                 .WithMany()
                 .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.StartHourOnMonday).WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.StartHourOnTuesday).WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.StartHourOnWednesday).WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.StartHourOnThursday).WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.StartHourOnFriday).WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusCurrent>().HasOne(s => s.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region StatusStartHour
            builder.Entity<StatusStartHour>().ToTable("StatusStartHour");
            builder.Entity<StatusStartHour>().Property(h => h.Id).ValueGeneratedOnAdd();
            #endregion

            #region StatusEvent
            builder.Entity<StatusEvent>().ToTable("StatusEvents");
            builder.Entity<StatusEvent>().Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Entity<StatusEvent>().HasOne(s => s.User).WithMany(u => u.StatusEvents);
            builder.Entity<StatusEvent>().HasOne(s => s.Type).WithMany();
            builder.Entity<StatusEvent>().HasOne(s => s.Project).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusEvent>().HasOne(s => s.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StatusEvent>().HasOne(s => s.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region StatusEventType
            builder.Entity<StatusEventType>().ToTable("StatusEventType");
            builder.Entity<StatusEventType>().Property(t => t.Id).ValueGeneratedOnAdd();
            #endregion

            #region Project
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Project>().HasOne(p => p.ProjectManager).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Project>().HasOne(p => p.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Project>().HasOne(p => p.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            #endregion
        }

        public override int SaveChanges()
        {
            SetCreatedModified();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetCreatedModified();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetCreatedModified()
        {
            ChangeTracker.DetectChanges();

            foreach(var entity in ChangeTracker.Entries())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        SetUserCreated(entity);
                        SetUserModified(entity);
                        break;

                    case EntityState.Modified:
                        SetUserModified(entity);
                        break;
                }
            }
        }

        private void SetUserCreated(EntityEntry entityEntry)
        {
            var userCreated = entityEntry.Entity as IUserCreated;
            if (userCreated != null)
            {
                userCreated.CreatedAt = DateTime.UtcNow;
                userCreated.CreatedById = LoginUserToApp.Id;
            }
        }
        private void SetUserModified(EntityEntry entityEntry)
        {
            var userModified = entityEntry.Entity as IUserModified;
            if (userModified != null)
            {
                userModified.ModifiedAt = DateTime.UtcNow;
                userModified.ModifiedById = LoginUserToApp.Id;
            }
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<StatusCurrent> StatusCurrents { get; set; }
        public DbSet<StatusEvent> StatusEvents { get; set; }
        public DbSet<StatusEventType> StatusEventTypes { get; set; }
        public DbSet<StatusStartHour> StatusStartHours { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}

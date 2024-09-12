using Doctorly.Scheduler.Application.Contracts.Identity;
using Microsoft.EntityFrameworkCore;
using Doctorly.Scheduler.Domain.Common;
using Doctorly.Scheduler.Domain.Events;

namespace Doctorly.Scheduler.Persistence.DatabaseContext
{
    public class DoctorlyDatabaseContext : DbContext
    {
        private readonly IUserService _userService;

        public DoctorlyDatabaseContext(DbContextOptions<DoctorlyDatabaseContext> options, IUserService userService) : base(options)
        {
            this._userService = userService;
        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventAllocation> EventAllocations { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorlyDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                         .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

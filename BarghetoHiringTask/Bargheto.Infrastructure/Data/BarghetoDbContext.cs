using Bargheto.Application.Common.Enums;
using Bargheto.Domain.Entities;
using Bargheto.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Data
{
    public class BarghetoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<TicketPriority> TicketPriorities { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }

        public BarghetoDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());

            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus((int)TicketStatusEnum.Open, "Open"),
                new TicketStatus((int)TicketStatusEnum.InProcess, "InProcess"),
                new TicketStatus((int)TicketStatusEnum.Close, "Close")
                );

            modelBuilder.Entity<TicketPriority>().HasData(
                new TicketStatus((int)TicketPriorityEnum.Low, "Low"),
                new TicketStatus((int)TicketPriorityEnum.Medium, "Medium"),
                new TicketStatus((int)TicketPriorityEnum.High, "High")
                );

            Guid adminRoleId = Guid.NewGuid();
            Guid employeeRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
            new { Id = adminRoleId, CreatedAt = DateTime.Now, Name = "Admin" },
            new { Id = employeeRoleId, CreatedAt = DateTime.UtcNow, Name = "Employee", }
            );

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DateTime now = DateTime.Now;

            foreach (var entity in ChangeTracker.Entries<BaseEntity>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = now;
                }
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

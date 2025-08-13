using Bargheto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Configurations
{
    public sealed class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x=> new {x.UserId, x.RoleId});

            builder.HasOne(u => u.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.RoleId);

            builder.HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.UserId);
        }
    }
}

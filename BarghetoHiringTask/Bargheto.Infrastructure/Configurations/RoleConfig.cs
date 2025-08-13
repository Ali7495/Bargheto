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
    public sealed class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);

            builder.HasMany(b=> b.UserRoles)
                .WithOne(u=> u.Role)
                .HasForeignKey(u=> u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

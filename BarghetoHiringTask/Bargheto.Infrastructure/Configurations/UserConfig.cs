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
    public sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);

            builder.OwnsOne(o => o.Email, b =>
            {
                b.Property(p => p.Value)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
                b.HasIndex(p => p.Value).IsUnique();
            });

            builder.OwnsOne(o => o.HashedPassword, b =>
            {
                b.Property(p => p.Value)
                .HasColumnName("PasswordHash")
                .HasMaxLength(200)
                .IsRequired();
            });

            builder.HasMany(b=> b.UserRoles)
                .WithOne(u=> u.User)
                .HasForeignKey(u=> u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b=> b.CreatedTickets)
                .WithOne(u=> u.CreatedByUser)
                .HasForeignKey(u=> u.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b=> b.AssignedTickets)
                .WithOne(u=> u.AssignedToUser)
                .HasForeignKey(u=> u.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

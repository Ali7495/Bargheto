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
    public sealed class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");
            builder.HasKey(t => t.Id);

            builder.HasOne(b => b.TicketStatus)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TicketStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.TicketPriority)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TicketPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.TicketStatusId, x.TicketPriorityId });
            builder.HasIndex(x => x.CreatedByUserId);
            builder.HasIndex(x => x.AssignedToUserId);
        }
    }
}

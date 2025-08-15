using Bargheto.Domain.Entities.Tickets;
using Bargheto.Domain.Interfaces.Repositories.Tickets;
using Bargheto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Repositories.Tickets
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(BarghetoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Ticket>> GetAllCurrentUserTickets(Guid currentUserId, CancellationToken cancellationToken = default)
        {
            return await Entities.AsNoTracking().Where(t=> t.CreatedByUserId == currentUserId).ToListAsync(cancellationToken);
        }

        public async Task<Ticket> GetOnlyById(Guid id, CancellationToken cancellationToken = default)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<List<Ticket>> GetTicketsByStatus(int statusId, CancellationToken cancellationToken = default)
        {
            return await Entities.AsNoTracking().Include(t=> t.TicketStatus).Where(t=> t.TicketStatusId ==  statusId).ToListAsync(cancellationToken);
        }

        public async Task<List<Ticket>> GetTicketsWithStatus(CancellationToken cancellationToken = default)
        {
            return await Entities.AsNoTracking().Include(t => t.TicketStatus).ToListAsync(cancellationToken);
        }

        public async Task<Ticket> GetTicketWithDetailsByIdAndAssignedId(Guid id, Guid userId, CancellationToken cancellationToken = default)
        {
            return await Entities.Where(t => t.AssignedToUserId == userId && t.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Ticket> GetTicketWithDetailsByIdAndCreatorId(Guid id, Guid userId, CancellationToken cancellationToken = default)
        {
            return await Entities.Where(t => t.CreatedByUserId == userId && t.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}

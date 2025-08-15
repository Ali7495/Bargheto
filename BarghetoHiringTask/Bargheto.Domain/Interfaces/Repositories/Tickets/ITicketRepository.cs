using Bargheto.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.Interfaces.Repositories.Tickets
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<List<Ticket>> GetAllCurrentUserTickets(Guid currentUserId, CancellationToken cancellationToken = default);
        Task<Ticket> GetOnlyById(Guid id, CancellationToken cancellationToken = default);
        Task<Ticket> GetTicketWithDetailsByIdAndCreatorId(Guid id, Guid userId, CancellationToken cancellationToken = default);
        Task<Ticket> GetTicketWithDetailsByIdAndAssignedId(Guid id, Guid userId, CancellationToken cancellationToken = default);
        Task<List<Ticket>> GetTicketsByStatus(int statusId, CancellationToken cancellationToken = default);
        Task<List<Ticket>> GetTicketsWithStatus(CancellationToken cancellationToken = default);
    }
}

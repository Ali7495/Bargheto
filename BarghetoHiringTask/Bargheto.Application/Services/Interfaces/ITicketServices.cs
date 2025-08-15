using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Services.Interfaces
{
    public interface ITicketServices
    {
        Task<ResultStatusDto> CreateTicket(Guid creatorId, TicketInputDto ticketInputDto, CancellationToken cancellationToken);
        Task<List<TicketOutPutDto>> GetAllCurrentUserTickets(Guid currentUserId, CancellationToken cancellationToken);
        Task<List<TicketOutPutDto>> GetAllTickets(CancellationToken cancellationToken);
        Task<ResultStatusDto> UpdateTickets(Guid ticketId, TicketInputDto ticketsInputDto, CancellationToken cancellationToken);
        Task<List<TicketCountStatusDto>> GetTicketsCountPerStatus(CancellationToken cancellationToken);
        Task<List<TicketCountStatusDto>> GetTicketsCountByStatus(int statusId, CancellationToken cancellationToken);
        Task<TicketOutPutDto> GetTicketWithDetailsById(Guid userId , string roleName,Guid ticketId, CancellationToken cancellationToken);
        Task<ResultStatusDto> DeleteTicket(Guid ticketId, CancellationToken cancellationToken);


        Task<List<TicketStatusOutPutDto>> GetAllTicketStatuses(CancellationToken cancellationToken);
    }
}

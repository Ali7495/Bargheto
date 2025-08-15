using AutoMapper;
using Bargheto.Application.Common.UnitOfWorkPattern;
using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.Tickets;
using Bargheto.Application.Services.Interfaces;
using Bargheto.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Services.Implementations
{
    public class TicketServices : ITicketServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultStatusDto> CreateTicket(Guid creatorId, TicketInputDto ticketInputDto, CancellationToken cancellationToken)
        {
            Ticket ticket = _mapper.Map<Ticket>(ticketInputDto);

            ticket.Id = Guid.NewGuid();
            ticket.CreatedByUserId = creatorId;

            await _unitOfWork.TicketRepository.AddAsync(ticket, cancellationToken);
            await _unitOfWork.CompleteTaskAsync(cancellationToken);

            return new() { Status = Common.Enums.ResultStatusEnum.Success, Message = "Ticket submitted successfully" };
        }

        public async Task<ResultStatusDto> DeleteTicket(Guid ticketId, CancellationToken cancellationToken)
        {
            Ticket ticket = await _unitOfWork.TicketRepository.GetOnlyById(ticketId, cancellationToken);

            ticket.IsDeleted = true;

            await _unitOfWork.TicketRepository.UpdateAsync(ticket);
            await _unitOfWork.CompleteTaskAsync(cancellationToken);

            return new() { Status = Common.Enums.ResultStatusEnum.Success, Message = "The Ticket successfully deleted" };
        }

        public async Task<List<TicketOutPutDto>> GetAllCurrentUserTickets(Guid currentUserId, CancellationToken cancellationToken)
        {
            List<Ticket> tickets = await _unitOfWork.TicketRepository.GetAllCurrentUserTickets(currentUserId, cancellationToken);

            return _mapper.Map<List<TicketOutPutDto>>(tickets);
        }

        public async Task<List<TicketOutPutDto>> GetAllTickets(CancellationToken cancellationToken)
        {
            List<Ticket> tickets = await _unitOfWork.TicketRepository.GetAllAsync(true, cancellationToken);

            return _mapper.Map<List<TicketOutPutDto>>(tickets);
        }

        public async Task<List<TicketStatusOutPutDto>> GetAllTicketStatuses(CancellationToken cancellationToken)
        {
            List<TicketStatus> ticketStatuses = await _unitOfWork.TicketStatusRepository.GetAllAsync(false, cancellationToken);

            return _mapper.Map<List<TicketStatusOutPutDto>>(ticketStatuses);
        }

        public async Task<List<TicketCountStatusDto>> GetTicketsCountByStatus(int statusId, CancellationToken cancellationToken)
        {
            List<Ticket> tickets = await _unitOfWork.TicketRepository.GetTicketsByStatus(statusId, cancellationToken);

            int ticketCount = tickets.Count;

            List<TicketCountStatusDto> ticketCountStatuses = tickets.Select(t => new TicketCountStatusDto()
            {
                StatusId = statusId,
                StatusName = t.TicketStatus.Name,
                TicketCount = ticketCount
            }).ToList();

            return ticketCountStatuses;
        }

        public async Task<List<TicketCountStatusDto>> GetTicketsCountPerStatus(CancellationToken cancellationToken)
        {
            List<Ticket> tickets = await _unitOfWork.TicketRepository.GetTicketsWithStatus(cancellationToken);

            List<TicketCountStatusDto> ticketCountStatusDtos = tickets.GroupBy(t => new { t.TicketStatusId, t.TicketStatus.Name }).Select(g => new TicketCountStatusDto
            {
                StatusId = g.Key.TicketStatusId,
                StatusName = g.Key.Name,
                TicketCount = g.Count()
            }).ToList();

            return ticketCountStatusDtos;
        }

        public async Task<TicketOutPutDto> GetTicketWithDetailsById(Guid userId, string roleName, Guid ticketId, CancellationToken cancellationToken)
        {
            Ticket ticket = new();

            if (roleName == "Admin")
            {
                ticket = await _unitOfWork.TicketRepository.GetTicketWithDetailsByIdAndAssignedId(ticketId, userId, cancellationToken);
            }
            else
            {

                ticket = await _unitOfWork.TicketRepository.GetTicketWithDetailsByIdAndCreatorId(ticketId, userId, cancellationToken);
            }

            return _mapper.Map<TicketOutPutDto>(ticket);
        }

        public async Task<ResultStatusDto> UpdateTickets(Guid ticketId, TicketInputDto ticketsInputDto, CancellationToken cancellationToken)
        {
            Ticket ticket = await _unitOfWork.TicketRepository.GetOnlyById(ticketId, cancellationToken);

            ticket.TicketStatusId = ticketsInputDto.TicketStatusId;
            ticket.AssignedToUserId = ticketsInputDto.AssignedToUserId;

            await _unitOfWork.TicketRepository.UpdateAsync(ticket);
            await _unitOfWork.CompleteTaskAsync(cancellationToken);

            return new() { Status = Common.Enums.ResultStatusEnum.Success, Message = "The ticket updated successfully" };
        }
    }
}

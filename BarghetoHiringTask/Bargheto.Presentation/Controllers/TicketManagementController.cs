using Bargheto.Application.Common.Extentions;
using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.Tickets;
using Bargheto.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bargheto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketManagementController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketManagementController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetAllTicketStasuses(CancellationToken cancellationToken)
        {
            List<TicketStatusOutPutDto> ticketStatuses = await _ticketServices.GetAllTicketStatuses(cancellationToken);

            return Ok(ticketStatuses);
        }


        [HttpPost("tickets")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AddTicket([FromBody]TicketInputDto ticket, CancellationToken cancellationToken)
        {
            string userId = HttpContext.User.GetUserId();

            ResultStatusDto resultStatusDto = await _ticketServices.CreateTicket(Guid.Parse(userId), ticket, cancellationToken);

            return Ok(resultStatusDto);
        }

        [HttpGet("tickets/my")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyTickets(CancellationToken cancellationToken)
        {
            string userId = HttpContext.User.GetUserId();

            List<TicketOutPutDto> tickets = await _ticketServices.GetAllCurrentUserTickets(Guid.Parse(userId), cancellationToken);

            return Ok(tickets);
        }

        [HttpGet("tickets")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTickets(CancellationToken cancellationToken)
        {
            List<TicketOutPutDto> tickets = await _ticketServices.GetAllTickets(cancellationToken);

            return Ok(tickets);
        }

        [HttpPut("tickets/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTheTicket(Guid id, [FromBody] TicketInputDto ticketInputDto, CancellationToken cancellationToken)
        {
            ResultStatusDto resultStatusDto = await _ticketServices.UpdateTickets(id, ticketInputDto, cancellationToken);

            return Ok(resultStatusDto);
        }

        [HttpGet("tickets/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ShowTicketsStatus(CancellationToken cancellationToken)
        {
            List<TicketCountStatusDto> ticketCountStatuses = await _ticketServices.GetTicketsCountPerStatus(cancellationToken);

            return Ok(ticketCountStatuses);
        }

        [HttpGet("tickets/status/{statusId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ShowTicketsByStatus(int statusId, CancellationToken cancellationToken)
        {
            List<TicketCountStatusDto> ticketCountStatuses = await _ticketServices.GetTicketsCountByStatus(statusId, cancellationToken);

            return Ok(ticketCountStatuses);
        }

        [HttpGet("tickets/{id}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetTicketById(Guid id, CancellationToken cancellationToken)
        {
            string userId = HttpContext.User.GetUserId();
            List<string> roles = HttpContext.User.GetUserRoles();

            TicketOutPutDto ticket = await _ticketServices.GetTicketWithDetailsById(Guid.Parse(userId), roles.FirstOrDefault(),id,cancellationToken);

            return Ok(ticket);
        }

        [HttpDelete("tickets/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTheTicket(Guid id, CancellationToken cancellationToken)
        {
            ResultStatusDto resultStatusDto = await _ticketServices.DeleteTicket(id, cancellationToken);

            return Ok(resultStatusDto);
        }
    }
}

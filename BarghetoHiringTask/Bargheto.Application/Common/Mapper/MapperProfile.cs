using AutoMapper;
using Bargheto.Application.DataTransferObjects.Tickets;
using Bargheto.Application.DataTransferObjects.UserManagement;
using Bargheto.Domain.Entities.Tickets;
using Bargheto.Domain.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserOutputDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Name));

            CreateMap<Role, RoleOutputDto>();
            CreateMap<TicketStatus, TicketStatusOutPutDto>();
            CreateMap<TicketPriority, TicketPriorityOutPutDto>();

            CreateMap<Ticket, TicketOutPutDto>()
                .ForMember(dest => dest.UserCreatorEmail, opt => opt.MapFrom(src => src.CreatedByUser.Email.Value))
                .ForMember(dest => dest.UserAssignedEmail, opt => opt.MapFrom(src => src.AssignedToUser.Email.Value))
                .ForMember(dest => dest.TicketStatus, opt => opt.MapFrom(src => src.TicketStatus.Name))
                .ForMember(dest => dest.TicketPriority, opt => opt.MapFrom(src => src.TicketPriority.Name));

            CreateMap<TicketInputDto, Ticket>();

        }
    }
}

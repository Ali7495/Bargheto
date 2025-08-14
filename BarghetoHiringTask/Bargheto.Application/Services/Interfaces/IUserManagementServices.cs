using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Services.Interfaces
{
    public interface IUserManagementServices
    {
        Task<ResultStatusDto> CreateUser(UserInputDto userInputDto, CancellationToken cancellationToken);
        Task<ResultStatusDto> UpdateUser(Guid id, UserInputDto userInputDto, CancellationToken cancellationToken);
        Task<ResultStatusDto> DeleteUser(Guid id, CancellationToken cancellationToken);
        Task<UserOutputDto> GetUserById(Guid id, CancellationToken cancellationToken);
        Task<List<UserOutputDto>> GetAllUsers(CancellationToken cancellationToken);
    }
}

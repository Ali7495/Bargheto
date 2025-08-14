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
        #region User
        Task<ResultStatusDto> CreateUser(UserInputDto userInputDto, CancellationToken cancellationToken);
        Task<TokenRespons> LoginUser(LoginDto loginDto, CancellationToken cancellationToken);
        Task<ResultStatusDto> UpdateUser(Guid id, UserInputDto userInputDto, CancellationToken cancellationToken);
        Task<ResultStatusDto> DeleteUser(Guid id, CancellationToken cancellationToken);
        Task<UserOutputDto> GetUserById(Guid id, CancellationToken cancellationToken);
        Task<List<UserOutputDto>> GetAllUsers(CancellationToken cancellationToken);

        #endregion


        #region Role

        Task<List<RoleOutputDto>> GetRoles(CancellationToken cancellationToken);

        #endregion
    }
}

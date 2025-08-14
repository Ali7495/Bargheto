using Bargheto.Domain.Interfaces.Repositories.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        #region UserManagement

        IUserReopsitory UserReopsitory { get; }
        IRoleRepository RoleRepository { get; }

        #endregion

        Task CompleteTaskAsync(CancellationToken cancellationToken);
        Task DisposeAsync();
    }
}

using Bargheto.Application.Common.UnitOfWorkPattern;
using Bargheto.Domain.Interfaces.Repositories.Tickets;
using Bargheto.Domain.Interfaces.Repositories.UserManagement;
using Bargheto.Infrastructure.Data;
using Bargheto.Infrastructure.Repositories.Tickets;
using Bargheto.Infrastructure.Repositories.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BarghetoDbContext _dbContext;


        #region UserManagement

        public IUserReopsitory UserReopsitory { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        #endregion

        #region Ticket

        public ITicketRepository TicketRepository { get; private set; }
        public ITicketStatusRepository TicketStatusRepository { get; private set; }


        #endregion

        public UnitOfWork(BarghetoDbContext dbContext)
        {
            _dbContext = dbContext;

            #region UserManagement

            UserReopsitory = new UserRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);

            #endregion

            #region Ticket

            TicketRepository = new TicketRepository(dbContext);
            TicketStatusRepository = new TicketStatusRepository(dbContext);

            #endregion
        }

        public async Task CompleteTaskAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}

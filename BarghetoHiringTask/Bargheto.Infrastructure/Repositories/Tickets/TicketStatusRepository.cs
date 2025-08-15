using Bargheto.Domain.Entities.Tickets;
using Bargheto.Domain.Interfaces.Repositories.Tickets;
using Bargheto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Repositories.Tickets
{
    public class TicketStatusRepository : Repository<TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(BarghetoDbContext dbContext) : base(dbContext)
        {
        }
    }
}

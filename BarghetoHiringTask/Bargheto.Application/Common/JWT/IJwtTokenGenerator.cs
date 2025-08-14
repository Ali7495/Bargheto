using Bargheto.Domain.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.JWT
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}

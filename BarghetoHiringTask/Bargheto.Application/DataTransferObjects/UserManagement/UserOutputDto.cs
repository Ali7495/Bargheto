using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects.UserManagement
{
    public class UserOutputDto : BaseEntityDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

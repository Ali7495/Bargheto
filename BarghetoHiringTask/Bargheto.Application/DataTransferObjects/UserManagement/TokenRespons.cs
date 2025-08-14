using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects.UserManagement
{
    public sealed record TokenRespons
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

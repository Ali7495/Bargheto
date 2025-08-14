using Bargheto.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects
{
    public class ResultStatusDto
    {
        public ResultStatusEnum Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

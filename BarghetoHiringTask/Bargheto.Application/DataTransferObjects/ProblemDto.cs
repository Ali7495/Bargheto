using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects
{
    public class ProblemDto
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}

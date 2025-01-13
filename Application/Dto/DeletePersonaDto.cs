using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DeletePersonaDto
    {
        public int Id { get; set; }
        public int ErrorCode { get; set; }
        public string ResultMessage { get; set; }
    }
}

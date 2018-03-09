using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateJigsMasterRequestDto
    {
        public decimal JigsCode { get; set; }

        public string Description { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Production
{
    public class AddProcesssCardCopyRequestDto
    {
        public decimal FromPartCode { get; set; }

        public decimal ToPartCode { get; set; }
    }
}

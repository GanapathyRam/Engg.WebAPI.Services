using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
   public class AddSymbolMasterRequestDto
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}

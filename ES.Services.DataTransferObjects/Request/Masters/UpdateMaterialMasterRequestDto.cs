using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateMaterialMasterRequestDto
    {
        public decimal MaterialCode { get; set; }

        public string MaterialDescription { get; set; }

        public string MaterialShortDescription { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

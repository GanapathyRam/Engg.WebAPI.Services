using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class AddMaterialMasterRequestDto
    {
        public string MaterialDescription { get; set; }

        public string MaterialShortDescription { get; set; }
        //   ,@CreatedBy uniqueidentifier
        public Guid CreatedBy { get; set; }
        //   , @CreatedDateTime datetime
        public DateTime CreatedDateTime { get; set; }
    }
}

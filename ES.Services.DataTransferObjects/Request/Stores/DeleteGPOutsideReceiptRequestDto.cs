using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
   public class DeleteGPOutsideReceiptRequestDto
    {
        public string GPOutsideReceiptNumber { get; set; }

        public int IsDeleteFrom { get; set; }  /* 1. Delete From GP Master 2. Delete From GP Details */

        public List<DeleteGPOutsideReceiptDetailsModel> DeleteGPOutsideReceiptDetailList { get; set; }
    }
    public class DeleteGPOutsideReceiptDetailsModel
    {
        public string GPOutsideReceiptNumber { get; set; }

        public int GPOutsideSerialNo { get; set; }
    }
}

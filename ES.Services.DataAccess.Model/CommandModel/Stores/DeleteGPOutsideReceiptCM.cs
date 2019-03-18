using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
     public class DeleteGPOutsideReceiptCM
    {
        public string GPOutsideReceiptNumber { get; set; }

        public int IsDeleteFrom { get; set; }  /* 1. Delete From GP Master 2. Delete From GP Details */

        public List<DeleteGPOutsideReceiptDetailsCM> DeleteGPOutsideReceiptDetailList { get; set; }
    }

    public class DeleteGPOutsideReceiptDetailsCM
    {
        public string GPOutsideReceiptNumber { get; set; }

        public int GPOutsideSerialNo { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

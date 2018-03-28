using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Production
{
    public class DeleteProcessCardCM
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal SerialNo { get; set; }

        public int IsDeleteFrom { get; set; }  /* 1. Delete From Process Card Master and Details 2. Delete Process Card Details (SerialNo) */
    }
}

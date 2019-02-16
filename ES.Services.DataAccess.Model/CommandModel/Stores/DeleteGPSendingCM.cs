using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class DeleteGPSendingCM
    {
        public string GPNumber { get; set; }

        public int IsDeleteFrom { get; set; }  /* 1. Delete From GP Master 2. Delete From GP Details */

        public List<DeleteGPSendingDetailsCM> DeleteGPSendingDetailsCM { get; set; }
    }

    public class DeleteGPSendingDetailsCM
    {
        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

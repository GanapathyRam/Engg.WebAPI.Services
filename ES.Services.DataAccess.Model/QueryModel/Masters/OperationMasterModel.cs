using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class OperationMasterModel
    {
        public decimal OperationCode { get; set; }

        public string OperationName { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}

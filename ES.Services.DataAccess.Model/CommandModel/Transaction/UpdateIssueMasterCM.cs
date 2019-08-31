using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class UpdateIssueMasterCM
    {
        public string IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal DepartmentCode { get; set; }

        public string Remarks { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

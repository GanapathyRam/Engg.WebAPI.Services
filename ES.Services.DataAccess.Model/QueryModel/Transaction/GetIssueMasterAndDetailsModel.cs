using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetIssueMasterAndDetailsModel
    {
        public string IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal DepartmentCode { get; set; }

        public string Remarks { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public decimal IssueQuantity { get; set; }

        public decimal StockQuantity { get; set; }
    }
}

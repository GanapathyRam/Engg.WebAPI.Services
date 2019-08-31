using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class AddIssueMasterRequestDto
    {
        public string IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal DepartmentCode { get; set; }

        public string Remarks { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public List<AddIssueDetailsRequest> getAddIssueDetailsRequestList { get; set; }
    }

    public class AddIssueDetailsRequest
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public decimal IssueQuantity { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}

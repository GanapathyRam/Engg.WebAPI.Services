using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class DeleteIssueRequestDto
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public int IsDeleteFrom { get; set; }

        public List<DeleteIssueDetails> GetDeleteIssuesDetails { get; set; }
    }

    public class DeleteIssueDetails
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public decimal IssueQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

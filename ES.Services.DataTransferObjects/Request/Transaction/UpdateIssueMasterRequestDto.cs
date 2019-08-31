using ES.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class UpdateIssueMasterRequestDto : BaseResponse
    {
        public string IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal DepartmentCode { get; set; }

        public string Remarks { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public List<UpdateIssueDetailsRequestDto> getUpdateIssueDetailsRequestDto { get; set; }
    }

    public class UpdateIssueDetailsRequestDto
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public decimal IssueQuantity { get; set; }

        public bool IsNew { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

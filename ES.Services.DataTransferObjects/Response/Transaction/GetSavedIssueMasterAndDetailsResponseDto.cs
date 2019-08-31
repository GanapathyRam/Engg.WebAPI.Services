using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetSavedIssueMasterAndDetailsResponseDto : BaseResponse
    {
        public List<GetSavedIssueMasterResponse> GetSavedIssueMasterResponseList { get; set; }
    }

    public class GetSavedIssueMasterResponse
    {
        public string IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal DepartmentCode { get; set; }

        public string Remarks { get; set; }

        public List<GetSavedIssueDetailsResponse> GetSavedIssueDetailsResponseList { get; set; }
    }

    public class GetSavedIssueDetailsResponse
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

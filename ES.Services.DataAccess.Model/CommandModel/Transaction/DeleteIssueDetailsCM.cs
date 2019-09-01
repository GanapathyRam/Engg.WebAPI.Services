using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class DeleteIssueDetailsCM
    {
        public IList<DeleteIssueDetailsCMItem> DeleteIssueDetailsCMItemList { get; set; }
    }

    public class DeleteIssueDetailsCMItem
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public decimal IssueQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

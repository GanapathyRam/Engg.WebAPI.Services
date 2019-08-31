using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class AddIssueDetailsCM
    {
        public IEnumerable<AddIssueDetailsCMItems> AddIssueDetailsCMItems { get; set; }
    }

    public class AddIssueDetailsCMItems
    {
        public string IssueNumber { get; set; }

        public decimal IssueSerial { get; set; }

        public decimal ItemCode { get; set; }

        public decimal IssueQuantity { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}

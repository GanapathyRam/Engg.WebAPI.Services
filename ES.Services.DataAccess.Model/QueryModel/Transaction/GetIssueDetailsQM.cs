using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetIssueDetailsQM
    {
        public IEnumerable<GetIssueDetailsModel> GetIssueDetailsModelList { get; set; }
    }

    public class GetIssueDetailsModel
    {
        public decimal Itemcode { get; set; }

        public string ItemDescription { get; set; }

        public string UOMDescription { get; set; }

        public decimal BalanceQuantity { get; set; }

        public string IssueQuantity { get; set; }
    }

}

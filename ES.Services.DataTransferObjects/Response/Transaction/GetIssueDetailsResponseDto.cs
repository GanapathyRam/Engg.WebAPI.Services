using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetIssueDetailsResponseDto : BaseResponse
    {
        public IEnumerable<GetIssueDetailsResponseModel> getIssueDetailsResponseModelList { get; set; }
    }

    public class GetIssueDetailsResponseModel
    {
        public decimal Itemcode { get; set; }

        public string ItemDescription { get; set; }

        public string UOMDescription { get; set; }

        public decimal BalanceQuantity { get; set; }

        public string IssueQuantity { get; set; }
    }
}

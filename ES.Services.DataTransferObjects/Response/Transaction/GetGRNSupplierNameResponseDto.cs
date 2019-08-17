using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetGRNSupplierNameResponseDto : BaseResponse
    {
        public List<GetGRNSupplierNameResponse> GetGRNSupplierNameResponseList { get; set; }

    }

    public class GetGRNSupplierNameResponse
    {
        public Int64 VendorCode { get; set; }


        public string VendorName { get; set; }
    }
}

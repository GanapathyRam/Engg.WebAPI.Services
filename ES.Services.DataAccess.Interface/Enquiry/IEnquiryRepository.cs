using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Enquiry
{
    public interface IEnquiryRepository
    {
        DataSet GetStockEnquiry();
    }
}

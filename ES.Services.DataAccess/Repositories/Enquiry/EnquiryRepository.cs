using ES.Services.DataAccess.Commands.Enquiry;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Repositories.Enquiry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Enquiry
{
    public class EnquiryRepository : IEnquiryRepository
    {
        public DataSet GetStockEnquiry()
        {
            DataSet ds = new DataSet();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetStockEnquirySelectCommand { Connection = connection };
                ds = command.Execute();
            }

            return ds;
        }
    }
}

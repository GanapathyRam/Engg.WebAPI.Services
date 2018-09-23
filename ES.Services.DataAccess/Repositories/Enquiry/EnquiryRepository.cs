using ES.Services.DataAccess.Commands.Enquiry;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Model.QueryModel.Enquiry;
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
        public DataSet GetStockEnquiry(Int16 Option)
        {
            DataSet ds = new DataSet();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetStockEnquirySelectCommand { Connection = connection };
                ds = command.Execute(Option);
            }

            return ds;
        }

        public StockEnquiryOptionQM GetStockEnquiryForGrid(Int16 Option)
        {
            StockEnquiryOptionQM ds = new StockEnquiryOptionQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetStockEnquirySelectCommandForGrid { Connection = connection };
                ds = command.Execute(Option);
            }

            return ds;
        }

        public DespatchEnquiryOptionQM GetDespatchEnquiryForGrid(Int16 Option, DateTime? fromDate, DateTime? ToDate)
        {
            DespatchEnquiryOptionQM ds = new DespatchEnquiryOptionQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDespatchEnquirySelectCommandForGrid { Connection = connection };
                ds = command.Execute(Option, fromDate, ToDate);
            }

            return ds;
        }

        public DataSet GetDespatchEnquiry(Int16 Option, DateTime? FromDate, DateTime? ToDate)
        {
            DataSet ds = new DataSet();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDespatchEnquirySelectCommand { Connection = connection };
                ds = command.Execute(Option, FromDate, ToDate);
            }

            return ds;
        }
    }
}

using ES.Services.DataAccess.Model.CommandModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class CompanyMasterInsertCommand: SsDbCommand
    {
        public void Execute(AddCompanyMasterCommandModel addCompanyMaster)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddCompanyMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@CompanyCode", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.CompanyCode));
                sqlCommand.Parameters.Add(AddParameter("@CompanyName", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyName));
                sqlCommand.Parameters.Add(AddParameter("@CompanyAddress1", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyAddress1));
                sqlCommand.Parameters.Add(AddParameter("@CompanyAddress2", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyAddress2));
                sqlCommand.Parameters.Add(AddParameter("@CompanyCity", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyCity));
                sqlCommand.Parameters.Add(AddParameter("@CompanyPincode", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyPincode));
                sqlCommand.Parameters.Add(AddParameter("@CompanyPhone", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyPhone));
                sqlCommand.Parameters.Add(AddParameter("@CompanyFax", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyFax));
                sqlCommand.Parameters.Add(AddParameter("@CompanyEmail", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyEmail));
                sqlCommand.Parameters.Add(AddParameter("@CompanyWeb", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyWeb));
                sqlCommand.Parameters.Add(AddParameter("@CompanyTNGST", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyTNGST));
                sqlCommand.Parameters.Add(AddParameter("@CompanyCST", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyCST));
                sqlCommand.Parameters.Add(AddParameter("@CompanyTIN", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyTIN));
                sqlCommand.Parameters.Add(AddParameter("@CompanyIECode", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyIECode));
                sqlCommand.Parameters.Add(AddParameter("@CompanyCECode", SsDbType.VarChar, ParameterDirection.Input, addCompanyMaster.CompanyCECode));
                sqlCommand.Parameters.Add(AddParameter("@PFLimit", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.PFLimit));
                sqlCommand.Parameters.Add(AddParameter("@ESILimit", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.ESILimit));
                sqlCommand.Parameters.Add(AddParameter("@PFPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.PFPercent));
                sqlCommand.Parameters.Add(AddParameter("@EPFPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.EPFPercent));
                sqlCommand.Parameters.Add(AddParameter("@FPFPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.FPFPercent));
                sqlCommand.Parameters.Add(AddParameter("@ESIPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.ESIPercent));
                sqlCommand.Parameters.Add(AddParameter("@ESIPercent_Employer", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.ESIPercent_Employer));
                sqlCommand.Parameters.Add(AddParameter("@EDPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.EDPercent));
                sqlCommand.Parameters.Add(AddParameter("@Cess1Percent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.Cess1Percent));
                sqlCommand.Parameters.Add(AddParameter("@Cess2Percent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.Cess2Percent));
                sqlCommand.Parameters.Add(AddParameter("@VatPercent", SsDbType.Int, ParameterDirection.Input, addCompanyMaster.VatPercent));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, addCompanyMaster.CreatedBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, addCompanyMaster.CreatedDateTime));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
    
}

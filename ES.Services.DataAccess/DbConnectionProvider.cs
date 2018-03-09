using SS.Framework.DataAccess;
using System.Configuration;

namespace ES.Services.DataAccess
{
    public class DbConnectionProvider : SsDbConnectionProvider
    {
        protected override string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ESConnectionString"].ConnectionString;
        }
    }
}

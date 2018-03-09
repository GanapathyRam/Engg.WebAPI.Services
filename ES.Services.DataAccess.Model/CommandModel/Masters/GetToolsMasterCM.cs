using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class GetToolsMasterCM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public decimal ToolsCode { get; set; }
    }
}

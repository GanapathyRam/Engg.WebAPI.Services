using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Sales
{
    public class GetWorkOrderDetailsStatusQM
    {
        public bool Dc { get; set; }
        public bool Invoice { get; set; }
        public bool SubContract { get; set; }
        public bool JTC { get; set; }

    }
}

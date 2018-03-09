using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetWOMasterForDcModel
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public decimal WOQuantity { get; set; }
        public decimal PartCode { get; set; }
        public string PartDescription { get; set; }
        public string ItemCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string DCNumber { get; set; }
        public string PONumber { get; set; }
    }
}

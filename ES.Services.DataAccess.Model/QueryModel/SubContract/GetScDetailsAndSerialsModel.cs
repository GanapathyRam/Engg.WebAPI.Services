using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.SubContract
{
    public class GetScDetailsAndSerialsModel
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public decimal PartCode { get; set; }
        public string PartDescription { get; set; }
        public string ItemCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string DrawingNumber { get; set; }
        public string ProcessDescription { get; set; }
        public string DCNumber { get; set; }
        public string SerialNo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Enquiry
{
    public class DeliveryFollowUpOptionModel
    {
        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public string SerialNo { get; set; }

        public string HeatNo { get; set; }

        public string DeliveryDate { get; set; }

        public bool DC { get; set; }
    }
}

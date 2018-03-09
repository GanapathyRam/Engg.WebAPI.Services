using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class UpdateMaterialMasterQM
    {
        public decimal MaterialCode { get; set; }

        public string MaterialDescription { get; set; }
        public string MaterialShortDescription { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class AddInvoiceRequestDto
    {
        public IEnumerable<InvoiceDetail> GetInvoiceDetailList { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string DcNumber { get; set; }

        public string WoType { get; set; }

        public Int64 VendorCode { get; set; }

        public string Tariff { get; set; }

        public string Vehicle { get; set; }

        public string EWayBill { get; set; }

        public decimal CGSTPercent { get; set; }

        public decimal SGSTPercent { get; set; }

        public decimal IGSTPercent { get; set; }

        public decimal ValueOfGoods { get; set; }

        public decimal CGSTAmount { get; set; }

        public decimal SGSTAmount { get; set; }

        public decimal IGSTAmount { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal RoundOff { get; set; }

        public decimal FineTotal { get; set; }

        public bool PrintTag { get; set; }

        public bool IsNew { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        //public InvoiceMaster GetInvoiceMaster { get; set; }

        //public IEnumerable<InvoiceDetailSerial> GetInvoiceDetailSerialList { get; set; }
    }

    //public class InvoiceMaster
    //{
    //    public string InvoiceNumber { get; set; }

    //    public DateTime InvoiceDate { get; set; }

    //    public string WoType { get; set; }

    //    public Int64 VendorCode { get; set; }

    //    public string Tariff { get; set; }

    //    public string Vehicle { get; set; }

    //    public string EWayBill { get; set; }

    //    public decimal CGSTPercent { get; set; }

    //    public decimal SGSTPercent { get; set; }

    //    public decimal IGSTPercent { get; set; }

    //    public decimal ValueOfGoods { get; set; }

    //    public decimal CGSTAmount { get; set; }

    //    public decimal SGSTAmount { get; set; }

    //    public decimal IGSTAmount { get; set; }

    //    public decimal GrandTotal { get; set; }

    //    public decimal RoundOff { get; set; }

    //    public decimal FineTotal { get; set; }

    //    public bool PrintTag { get; set; }

    //    public Guid CreatedBy { get; set; }

    //    public DateTime CreatedDateTime { get; set; }

    //}

    public class InvoiceDetail
    {
        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public decimal PartCode { get; set; }

        public decimal Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal Rate { get; set; }

        public decimal Value { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }

    //public class InvoiceDetailSerial
    //{
    //    public string InvoiceNumber { get; set; }

    //    public decimal InvoiceSerial { get; set; }

    //    public string DcNumber { get; set; }

    //    public decimal DcSerial { get; set; }

    //    public string SerialNo { get; set; }

    //    public string WoNumber { get; set; }

    //    public int WoSerial { get; set; }

    //    public Guid CreatedBy { get; set; }

    //    public DateTime CreatedDateTime { get; set; }
    //}
}

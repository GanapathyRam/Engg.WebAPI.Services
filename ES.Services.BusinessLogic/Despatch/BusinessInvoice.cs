using ES.Services.BusinessLogic.Interface.Despatch;
using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.ReportLogic.Interface.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Despatch
{
    public class BusinessInvoice : IBusinessInvoice, IReportInvoice
    {
        private readonly IInvoiceRepository invoiceRepository;

        public BusinessInvoice(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public AddInvoiceResponseDto AddInvoice(AddInvoiceRequestDto addInvoiceRequestDto)
        {
            AddInvoiceResponseDto response = new AddInvoiceResponseDto();

            if (addInvoiceRequestDto.IsNew)
            {

                #region InvoiceDetails

                var invoiceDetailsItemsCM = new List<InvoiceDetailsItems>();
                var invoiceDetailsCM = new InvoiceDetailCM();

                foreach (var invoiceDetails in addInvoiceRequestDto.GetInvoiceDetailList)
                {
                    var invoiceDetailsItems = new InvoiceDetailsItems
                    {
                        InvoiceNumber = addInvoiceRequestDto.InvoiceNumber,
                        InvoiceSerial = invoiceDetails.InvoiceSerial,
                        DcNumber = invoiceDetails.DcNumber,
                        PartCode = invoiceDetails.PartCode,
                        Quantity = invoiceDetails.Quantity,
                        Rate = invoiceDetails.Rate,
                        Value = invoiceDetails.Value,
                        Remarks = invoiceDetails.Remarks,
                        DcSerial = invoiceDetails.DcSerial,
                        CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    invoiceDetailsItemsCM.Add(invoiceDetailsItems);
                }

                invoiceDetailsCM.InvoiceDetailsItems = invoiceDetailsItemsCM;

                invoiceRepository.AddInvoiceDetails(invoiceDetailsCM);

                #endregion

                #region InvoiceMaster

                invoiceRepository.AddInvoiceMaster(addInvoiceRequestDto.InvoiceNumber, addInvoiceRequestDto.InvoiceDate, addInvoiceRequestDto.DcNumber,
                    addInvoiceRequestDto.WoType, addInvoiceRequestDto.VendorCode, addInvoiceRequestDto.Tariff, addInvoiceRequestDto.Vehicle,
                    addInvoiceRequestDto.EWayBill, addInvoiceRequestDto.CGSTPercent, addInvoiceRequestDto.SGSTPercent,
                    addInvoiceRequestDto.IGSTPercent, addInvoiceRequestDto.ValueOfGoods, addInvoiceRequestDto.CGSTAmount,
                    addInvoiceRequestDto.SGSTAmount, addInvoiceRequestDto.IGSTAmount, addInvoiceRequestDto.GrandTotal,
                    addInvoiceRequestDto.RoundOff, addInvoiceRequestDto.FineTotal, addInvoiceRequestDto.PrintTag);

                #endregion

                var model = invoiceRepository.GetDcDetailsSerialForInvoiceSerial(addInvoiceRequestDto.DcNumber);

                #region InvoiceDetailsSerial
                var invoiceDetailSerialItemCM = new List<InvoiceDetailSerialItem>();
                var invoiceDetailSerialCM = new InvoiceDetailSerialCM();

                foreach (var invoiceDetailsSerial in model.GetDcSerialForInvoiceSerialQMList)
                {
                    var invoiceDetailSerialItem = new InvoiceDetailSerialItem
                    {
                        InvoiceNumber = addInvoiceRequestDto.InvoiceNumber,
                        InvoiceSerial = invoiceDetailsSerial.InvoiceSerial,
                        DcNumber = invoiceDetailsSerial.DcNumber,
                        DcSerial = invoiceDetailsSerial.DcSerial,
                        SerialNo = invoiceDetailsSerial.SerialNo,
                        WoNumber = invoiceDetailsSerial.WoNumber,
                        WoSerial = invoiceDetailsSerial.WoSerial,
                        CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    invoiceDetailSerialItemCM.Add(invoiceDetailSerialItem);
                }

                invoiceDetailSerialCM.InvoiceDetailSerialItem = invoiceDetailSerialItemCM;

                invoiceRepository.AddInvoiceDetailSerial(invoiceDetailSerialCM);
                #endregion
            }
            else
            {
                #region InvoiceDetails Update

                var invoiceDetailsItemsCM = new List<InvoiceDetailsItems>();
                var invoiceDetailsCM = new InvoiceDetailCM();

                foreach (var invoiceDetails in addInvoiceRequestDto.GetInvoiceDetailList)
                {
                    var invoiceDetailsItems = new InvoiceDetailsItems
                    {
                        InvoiceNumber = addInvoiceRequestDto.InvoiceNumber,
                        InvoiceSerial = invoiceDetails.InvoiceSerial,
                        DcNumber = invoiceDetails.DcNumber,
                        PartCode = invoiceDetails.PartCode,
                        Quantity = invoiceDetails.Quantity,
                        Rate = invoiceDetails.Rate,
                        Value = invoiceDetails.Value,
                        Remarks = invoiceDetails.Remarks,
                        DcSerial = invoiceDetails.DcSerial,
                        CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    invoiceDetailsItemsCM.Add(invoiceDetailsItems);
                }

                invoiceDetailsCM.InvoiceDetailsItems = invoiceDetailsItemsCM;

                invoiceRepository.UpdateInvoiceDetails(invoiceDetailsCM);

                #endregion

                #region InvoiceMaster Update

                invoiceRepository.UpdateInvoiceMaster(addInvoiceRequestDto.InvoiceNumber, addInvoiceRequestDto.InvoiceDate, addInvoiceRequestDto.DcNumber,
                    addInvoiceRequestDto.WoType, addInvoiceRequestDto.VendorCode, addInvoiceRequestDto.Tariff, addInvoiceRequestDto.Vehicle,
                    addInvoiceRequestDto.EWayBill, addInvoiceRequestDto.CGSTPercent, addInvoiceRequestDto.SGSTPercent,
                    addInvoiceRequestDto.IGSTPercent, addInvoiceRequestDto.ValueOfGoods, addInvoiceRequestDto.CGSTAmount,
                    addInvoiceRequestDto.SGSTAmount, addInvoiceRequestDto.IGSTAmount, addInvoiceRequestDto.GrandTotal,
                    addInvoiceRequestDto.RoundOff, addInvoiceRequestDto.FineTotal);

                #endregion
            }

            return response;
        }

        public DeleteInvoiceResponseDto DeleteInvoice(DeleteInvoiceRequestDto deleteInvoiceRequestDto)
        {
            var response = new DeleteInvoiceResponseDto();

            var deleteInvoiceCMModel = new List<DeleteInvoiceCMModel>();

            var deleteInvoiceCM = new DeleteInvoiceCM();
            foreach (var invoiceItems in deleteInvoiceRequestDto.DeleteInvoiceRequestModelList)
            {
                var deleteInvoiceCMModelItems = new DeleteInvoiceCMModel
                {
                    WoNumber = invoiceItems.WoNumber,
                    WoSerial = invoiceItems.WoSerial,
                    DcSerial = invoiceItems.DcSerial,
                    UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                    UpdatedDateTime = System.DateTime.UtcNow
                };

                deleteInvoiceCMModel.Add(deleteInvoiceCMModelItems);
            }

            deleteInvoiceCM.DcNumber = deleteInvoiceRequestDto.DcNumber;
            deleteInvoiceCM.InvoiceNumber = deleteInvoiceRequestDto.InvoiceNumber;
            deleteInvoiceCM.DeleteInvoiceCMModelList = deleteInvoiceCMModel;

            invoiceRepository.DeleteInvoice(deleteInvoiceCM);

            return response;
        }

        GetDcDetailsForInvoiceResponseDto IReportInvoice.GetDcDetailsForInvoice(string DcNumber)
        {
            throw new NotImplementedException();
        }

        GetDcNumberForInvoiceResponseDto IReportInvoice.GetDcNumberForInvoice(GetInvoiceNumberRequestDto getInvoiceNumberRequestDto)
        {
            throw new NotImplementedException();
        }

        GetInvoiceDetailsResponseDto IReportInvoice.GetInvoiceDetails(GetInvoiceDetailsRequestDto getInvoiceDetailsRequestDto)
        {
            throw new NotImplementedException();
        }

        GetInvoiceMasterResponseDto IReportInvoice.GetInvoiceMaster()
        {
            throw new NotImplementedException();
        }

        GetInvoiceNumberResponseDto IReportInvoice.GetInvoiceNumber(string WoType)
        {
            throw new NotImplementedException();
        }

        public GetDimensionReportResponseDto GetDimensionReport(string InvoiceNumber, decimal InvoiceSerial, int IsReportFor)
        {
            GetDimensionReportResponseDto respone = new GetDimensionReportResponseDto();

            return respone;
        }
    }
}

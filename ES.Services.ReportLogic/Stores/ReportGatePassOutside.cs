using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using ES.Services.ReportLogic.Interface.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Stores
{
    public class ReportGatePassOutside : IReportGPOutside
    {
        private readonly IGatePassOutsideRepository gatePassOutsideRepository;

        public ReportGatePassOutside(IGatePassOutsideRepository gatePassOutsideRepository)
        {
            this.gatePassOutsideRepository = gatePassOutsideRepository;
        }

        public GetGPOutsideReceiptResponseDto getGPOutsideReceipt()
        {
            var response = new GetGPOutsideReceiptResponseDto()
            {
                GetGPOutsideReceiptResponse = new List<GPOutsideReceiptMaster>()
            };

            var model = gatePassOutsideRepository.getGPOutsideReceipt();


            foreach (var responseModel in model.getGPOutsideReceiptList)
            {
                var getsingle = new GPOutsideReceiptMaster
                {
                    GPOutsideReceiptDetailsList = new List<GPOutsideReceiptDetailsRModel>()
                };
                var getGPReceivingDetailsItems = new GPOutsideReceiptDetailsRModel();
                getGPReceivingDetailsItems.GPOutsideReceiptNumber = responseModel.GPOutsideReceiptNumber;
                getGPReceivingDetailsItems.GPOutsideSerialNo = responseModel.GPOutsideSerialNo;
                getGPReceivingDetailsItems.Units = responseModel.Units;
                getGPReceivingDetailsItems.UnitsDescription = responseModel.UnitsDescription;
                getGPReceivingDetailsItems.SentQuantity = responseModel.SentQuantity;
                getGPReceivingDetailsItems.ReceivedQuantity = responseModel.ReceivedQuantity;
                getGPReceivingDetailsItems.Description = responseModel.Description;

                if (response.GetGPOutsideReceiptResponse.Count > 0)
                {
                    var isExist = response.GetGPOutsideReceiptResponse.Any(dcMaster => dcMaster.GPOutsideReceiptNumber == responseModel.GPOutsideReceiptNumber);
                    if (isExist)
                    {
                        var index = response.GetGPOutsideReceiptResponse.FindIndex(a => a.GPOutsideReceiptNumber == responseModel.GPOutsideReceiptNumber);

                        response.GetGPOutsideReceiptResponse[index].GPOutsideReceiptDetailsList.Add(getGPReceivingDetailsItems);
                    }
                    else
                    {
                        getsingle.GPOutsideType = responseModel.GPOutsideType;
                        getsingle.GPDescription = responseModel.GPDescription;
                        getsingle.GPOutsideReceiptNumber = responseModel.GPOutsideReceiptNumber;
                        getsingle.VendorCode = responseModel.VendorCode;
                        getsingle.VendorName = responseModel.VendorName;
                        getsingle.GPOutsideReceiptDate = responseModel.GPOutsideReceiptDate;
                        getsingle.RecievedBy = responseModel.RecievedBy;
                        getsingle.RecievedName = responseModel.RecievedName;
                        getsingle.Remarks = responseModel.Remarks;

                        getsingle.GPOutsideReceiptDetailsList.Add
                        (getGPReceivingDetailsItems);

                        response.GetGPOutsideReceiptResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPOutsideType = responseModel.GPOutsideType;
                    getsingle.GPDescription = responseModel.GPDescription;
                    getsingle.GPOutsideReceiptNumber = responseModel.GPOutsideReceiptNumber;
                    getsingle.VendorCode = responseModel.VendorCode;
                    getsingle.VendorName = responseModel.VendorName;
                    getsingle.GPOutsideReceiptDate = responseModel.GPOutsideReceiptDate;
                    getsingle.RecievedBy = responseModel.RecievedBy;
                    getsingle.RecievedName = responseModel.RecievedName;
                    getsingle.Remarks = responseModel.Remarks;

                    getsingle.GPOutsideReceiptDetailsList.Add
                    (getGPReceivingDetailsItems);

                    response.GetGPOutsideReceiptResponse.Add(getsingle);
                }
            }

            return response;
        }

        public GetGPOutsideReceiptNumberResponseDto getGPOutsideReceiptNumber(string gpOutsideType)
        {
            var response = new GetGPOutsideReceiptNumberResponseDto();
            var model = gatePassOutsideRepository.getGPOutsideReceiptNumber(gpOutsideType);
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(1, 2));
                if (!savedYear.Equals(currentYear))
                {
                    response.GPOutsideReceiptNumber = "G" + Convert.ToString(currentYear + "O" + gpOutsideType + "0001");
                }
                else
                {
                    var gpnumbernc = (Int32.Parse(model.ToString().Substring(model.ToString().Length - 4)) + 1).ToString().PadLeft(4, '0');
                    response.GPOutsideReceiptNumber = "G" + Convert.ToString(currentYear + "O" + gpOutsideType + gpnumbernc);
                }
            }
            else
            {
                response.GPOutsideReceiptNumber = "G" + Convert.ToString(currentYear + "O" + gpOutsideType + "0001");
            }
            return response;
        }
    }
}

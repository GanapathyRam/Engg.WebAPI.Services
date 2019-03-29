using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using ES.Services.DataTransferObjects.Request.Stores;
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
                        getsingle.IsDeletable = responseModel.IsDeletable;

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
                    getsingle.IsDeletable = responseModel.IsDeletable;
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

        public GPOutsideReturnResponseDto GetGPOutsideReturn()
        {
            var response = new GPOutsideReturnResponseDto()
            {
                GetGPOutsideReturnResponse = new List<GPOutsideReturnMaster>()
            };

            var model = gatePassOutsideRepository.GetGPOutsideReturn();

            foreach (var responseModel in model.getGPOutsideReturnList)
            {
                var getsingle = new GPOutsideReturnMaster
                {
                    GPOutsideReturnDetailsList = new List<GPOutsideReturnDetailsRes>()
                };
                var getGPReceivingDetailsItems = new GPOutsideReturnDetailsRes();
                getGPReceivingDetailsItems.GPOutsideReceiptNumber = responseModel.GPOutsideReceiptNumber;
                getGPReceivingDetailsItems.GPOutsideSerialNo = responseModel.GPOutsideSerialNo;
                getGPReceivingDetailsItems.Units = responseModel.Units;
                getGPReceivingDetailsItems.UnitsDescription = responseModel.UnitsDescription;
                getGPReceivingDetailsItems.SentQuantity = responseModel.SentQuantity;
                getGPReceivingDetailsItems.Description = responseModel.Description;

                if (response.GetGPOutsideReturnResponse.Count > 0)
                {
                    var isExist = response.GetGPOutsideReturnResponse.Any(dcMaster => dcMaster.GPOutsideReturnNumber == responseModel.GPOutsideReturnNumber);
                    if (isExist)
                    {
                        var index = response.GetGPOutsideReturnResponse.FindIndex(a => a.GPOutsideReturnNumber == responseModel.GPOutsideReturnNumber);

                        response.GetGPOutsideReturnResponse[index].GPOutsideReturnDetailsList.Add(getGPReceivingDetailsItems);
                    }
                    else
                    {
                        getsingle.GPOutsideReturnNumber = responseModel.GPOutsideReturnNumber;
                        getsingle.GPOutsideReturnDate = responseModel.GPOutsideReturnDate;
                        getsingle.Remarks = responseModel.Remarks;
                        getsingle.VendorCode = responseModel.VendorCode;
                        getsingle.VendorName = responseModel.VendorName;
                        getsingle.FullAddress = responseModel.FullAddress;
                        getsingle.City = responseModel.City;
                        getsingle.PinCode = responseModel.PinCode;
                        getsingle.CompanyGST = responseModel.CompanyGST;
                        getsingle.GPOutsideReturnDetailsList.Add
                            (getGPReceivingDetailsItems);

                        response.GetGPOutsideReturnResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPOutsideReturnNumber = responseModel.GPOutsideReturnNumber;
                    getsingle.GPOutsideReturnDate = responseModel.GPOutsideReturnDate;
                    getsingle.Remarks = responseModel.Remarks;
                    getsingle.VendorCode = responseModel.VendorCode;
                    getsingle.VendorName = responseModel.VendorName;
                    getsingle.FullAddress = responseModel.FullAddress;
                    getsingle.City = responseModel.City;
                    getsingle.PinCode = responseModel.PinCode;
                    getsingle.CompanyGST = responseModel.CompanyGST;
                    getsingle.GPOutsideReturnDetailsList.Add
                        (getGPReceivingDetailsItems);

                    response.GetGPOutsideReturnResponse.Add(getsingle);
                }
            }


            return response;
        }

        public GetGPOutsideReturnNumberResponseDto GetGPOutsideReturnNumber()
        {
            var response = new GetGPOutsideReturnNumberResponseDto();
            var model = gatePassOutsideRepository.GetGPOutsideReturnNumber();
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(1, 2));
                if (!savedYear.Equals(currentYear))
                {
                    response.GPOutsideReturnNumber = "R" + Convert.ToString(currentYear + "IR0001");
                }
                else
                {
                    var gpnumbernc = (Int32.Parse(model.ToString().Substring(model.ToString().Length - 4)) + 1).ToString().PadLeft(4, '0');
                    response.GPOutsideReturnNumber = "R" + Convert.ToString(currentYear + "IR" + gpnumbernc);
                }
            }
            else
            {
                response.GPOutsideReturnNumber = "R" + Convert.ToString(currentYear + "IR0001");
            }
            return response;
        }

        public GetGPOutsideReturnVendorResponseDto GetGPOutsideReturnVendorList()
        {
            var response = new GetGPOutsideReturnVendorResponseDto();
            var model = gatePassOutsideRepository.GetGPOutsideReturnVendorList();
            if (model != null)
            {
                response = GPOReturnVendorMapper((List<GPpReturnVendorModel>)model.gpReturnVendorList, response);
            }

            return response;
        }

        private GetGPOutsideReturnVendorResponseDto GPOReturnVendorMapper(List<GPpReturnVendorModel> gpReturnVendorList, GetGPOutsideReturnVendorResponseDto response)
        {
            Mapper.CreateMap<GPpReturnVendorModel, GPReturnVendorResponse>();
            response.gpReturnVendorList =
                Mapper.Map<List<GPpReturnVendorModel>, List<GPReturnVendorResponse>>(gpReturnVendorList);

            return response;
        }

        public GPOutsideReturnDetailsGridResponseDto GetGPReceivedDetailsGrid(Int64 VendorCode)
        {

            var response = new GPOutsideReturnDetailsGridResponseDto();

            var model = gatePassOutsideRepository.GetGPReceivedDetailsGrid(VendorCode);
            if (model != null)
            {
                response = GPReceivedDetailsGridMapper((List<GPOutsideReturnDetailsGridModel>)model.GetGPReceivedDetailsList, response);
            }
            return response;
        }

        private GPOutsideReturnDetailsGridResponseDto GPReceivedDetailsGridMapper(List<GPOutsideReturnDetailsGridModel> getGPReceivedDetailsList, GPOutsideReturnDetailsGridResponseDto response)
        {
            Mapper.CreateMap<GPOutsideReturnDetailsGridModel, GPOutsideReturnDetailsGrid>();
            response.GetGPReceivedDetailsList =
                Mapper.Map<List<GPOutsideReturnDetailsGridModel>, List<GPOutsideReturnDetailsGrid>>(getGPReceivedDetailsList);

            return response;
        }
    }
}

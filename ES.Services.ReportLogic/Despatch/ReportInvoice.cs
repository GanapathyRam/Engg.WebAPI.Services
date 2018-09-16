using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.ReportLogic.Interface.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Despatch
{
    public class ReportInvoice : IReportInvoice
    {
        private readonly IInvoiceRepository invoiceRepository;

        public ReportInvoice(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public GetInvoiceNumberResponseDto GetInvoiceNumber(string WoType)
        {
            var response = new GetInvoiceNumberResponseDto();

            var model = invoiceRepository.GetInvoiceNumber(WoType);

            var currentYear = Helper.CurrentFiniancialYear();

            if (WoType == "S")
            {
                if (!string.IsNullOrEmpty(model))
                {
                    var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                    //var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                    if (!savedYear.Equals(currentYear))
                    {
                        response.InvoiceNumber = "I" + WoType + Convert.ToString(currentYear + "0001");
                    }
                    else
                    {
                        var dcType = Convert.ToString(model.ToString().Substring(0, 1));
                        var workOrderInc = Int32.Parse(model.ToString().Substring(2, 6)) + 1;
                        response.InvoiceNumber = dcType + WoType + Convert.ToString(workOrderInc);
                    }
                }
                else
                {
                    response.InvoiceNumber = "I" + WoType + Convert.ToString(currentYear + "0001");
                }
            }
            else if (WoType == "L")
            {
                if (!string.IsNullOrEmpty(model))
                {
                    var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                    //var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                    if (!savedYear.Equals(currentYear))
                    {
                        response.InvoiceNumber = "I" + WoType + Convert.ToString(currentYear + "3001");
                    }
                    else
                    {
                        var dcType = Convert.ToString(model.ToString().Substring(0, 1));
                        var workOrderInc = Int32.Parse(model.ToString().Substring(2, 6)) + 1;
                        response.InvoiceNumber = dcType + WoType + Convert.ToString(workOrderInc);
                    }
                }
                else
                {
                    response.InvoiceNumber = "I" + WoType + Convert.ToString(currentYear + "3001");
                }
            }

            return response;
        }

        public GetDcNumberForInvoiceResponseDto GetDcNumberForInvoice(GetInvoiceNumberRequestDto getInvoiceNumberRequestDto)
        {
            var response = new GetDcNumberForInvoiceResponseDto();

            var model = invoiceRepository.GetDcNumberForInvoice(getInvoiceNumberRequestDto.VendorCode, getInvoiceNumberRequestDto.WoType);

            if (model != null)
            {
                response = DcNumberForInvoiceMapper((List<GetDcNumberForInvoiceModel>)model.GetDcNumberForInvoiceList, response);
            }

            return response;
        }

        public GetDcDetailsForInvoiceResponseDto GetDcDetailsForInvoice(string DcNumber)
        {
            var response = new GetDcDetailsForInvoiceResponseDto();

            var model = invoiceRepository.GetDcDetailsForInvoice(DcNumber);

            if (model != null)
            {
                response = DcDetailsForInvoiceMapper((List<GetDcDetailsForInvoiceModel>)model.GetDcDetailsForInvoiceModel, response);
            }

            return response;
        }

        public GetInvoiceMasterResponseDto GetInvoiceMaster()
        {
            var response = new GetInvoiceMasterResponseDto();

            var model = invoiceRepository.GetInvoiceMaster();

            if (model != null)
            {
                response = InvoiceMasterMapper((List<GetInvoiceMasterQMModel>)model.GetInvoiceMasterQMModel, response);
            }

            return response;

        }

        public GetInvoiceDetailsResponseDto GetInvoiceDetails(GetInvoiceDetailsRequestDto getInvoiceDetailsRequestDto)
        {
            var response = new GetInvoiceDetailsResponseDto();

            var model = invoiceRepository.GetInvoiceDetails(getInvoiceDetailsRequestDto.InvoiceNumber);

            if (model != null)
            {
                response = InvoiceDetailsMapper((List<SavedInvoiceDetailsQMModel>)model.GetSavedInvoiceDetailsList, response);
            }

            return response;
        }

        public GetDimensionReportResponseDto GetDimensionReport(string InvoiceNumber, decimal InvoiceSerial, int IsReportFor)
        {
            GetDimensionReportResponseDto response = new GetDimensionReportResponseDto()
            {
                getDimensionReportResponseList = new List<GetDimensionReportResponse>()
            };

            var model = invoiceRepository.GetDimensionReport(InvoiceNumber, InvoiceSerial, IsReportFor);

            if (model != null && model.getDimensionReportModel.Count() > 0)
            {
                var getsingle = new GetDimensionReportResponse
                {
                    getDimensionReportSerialList = new List<DimensionReportSerialList>(),
                    getDimensionReportSequenceList = new List<DimensionReportSequenceList>()
                };

                foreach (var workOrderMasterDetails in model.getDimensionReportModel)
                {
                    var getJobCardEntrySerialList = new DimensionReportSerialList();
                    getJobCardEntrySerialList.SerialNo = workOrderMasterDetails.SerialNo;

                    var isExist = getsingle.getDimensionReportSerialList.Any(serialNo => serialNo.SerialNo == workOrderMasterDetails.SerialNo);

                    if (!isExist)
                    {
                        getsingle.getDimensionReportSerialList.Add(getJobCardEntrySerialList);
                    }

                    var getDimensionReportSequenceList = new List<DimensionReportSequenceList>();
                    var dimensionReportSequenceList = new DimensionReportSequenceList()
                    {
                        getDimensionReportBySerial = new List<DimensionReportBySerial>()
                    };
                    var dimensionReportBySerial = new DimensionReportBySerial();

                    dimensionReportSequenceList.Description = workOrderMasterDetails.Description;
                    dimensionReportSequenceList.DimensionMax = workOrderMasterDetails.DimensionMax;
                    dimensionReportSequenceList.DimensionMin = workOrderMasterDetails.DimensionMin;
                    dimensionReportSequenceList.Serial = workOrderMasterDetails.Serial;
                    dimensionReportSequenceList.SequenceNumber = workOrderMasterDetails.SequenceNumber;
                    dimensionReportSequenceList.InstrumentDescription = workOrderMasterDetails.InstrumentName;

                    dimensionReportBySerial.SequenceNumber = workOrderMasterDetails.SequenceNumber;
                    dimensionReportBySerial.DimensionActual = workOrderMasterDetails.DimensionActual;
                    dimensionReportBySerial.SerialNo = workOrderMasterDetails.SerialNo;
                    dimensionReportBySerial.Serial = workOrderMasterDetails.Serial;

                    var isSequenceExist = getsingle.getDimensionReportSequenceList.Any(sequenceNo => sequenceNo.SequenceNumber == workOrderMasterDetails.SequenceNumber && sequenceNo.Serial == workOrderMasterDetails.Serial);

                    if (!isSequenceExist)
                    {
                        dimensionReportSequenceList.getDimensionReportBySerial.Add(dimensionReportBySerial);
                        getsingle.getDimensionReportSequenceList.Add(dimensionReportSequenceList);
                    }
                    else
                    {
                        var indexForSequence = getsingle.getDimensionReportSequenceList.FindIndex(a => a.SequenceNumber == workOrderMasterDetails.SequenceNumber && a.Serial == workOrderMasterDetails.Serial);

                        var isSerialExist = getsingle.getDimensionReportSequenceList[indexForSequence].getDimensionReportBySerial.Any(serial => serial.Serial == workOrderMasterDetails.Serial);

                        //if (!isSerialExist)
                        //{
                        getsingle.getDimensionReportSequenceList[indexForSequence].getDimensionReportBySerial.Add(dimensionReportBySerial);
                        //}
                    }

                    getsingle.ItemCode = workOrderMasterDetails.ItemCode;
                    getsingle.PartCode = workOrderMasterDetails.PartCode;
                    getsingle.CustomerName = workOrderMasterDetails.VendorName;
                    getsingle.Description = workOrderMasterDetails.Description;
                    getsingle.DrawingNo = workOrderMasterDetails.DrawingNumber;
                    getsingle.DrawingNumberRevision = workOrderMasterDetails.DrawingNumberRevision;
                    getsingle.InvoiceDate = workOrderMasterDetails.InvoiceDate;
                    getsingle.InvoiceNumber = workOrderMasterDetails.InvoiceNumber;
                    getsingle.InvoiceSerial = workOrderMasterDetails.InvoiceSerial;
                    getsingle.MaterialDescription = workOrderMasterDetails.MaterialShortDescription;
                    getsingle.Description = workOrderMasterDetails.PartDescription;
                    getsingle.PoNumber = workOrderMasterDetails.PONumber;
                    getsingle.Quantity = workOrderMasterDetails.Quantity;
                    getsingle.UnitDescription = workOrderMasterDetails.UnitDescription;
                    getsingle.Units = workOrderMasterDetails.Unit;

                }
                 
                response.getDimensionReportResponseList.Add(getsingle);
            }

            return response;
        }


        #region Mapper Section
        private static GetDcNumberForInvoiceResponseDto DcNumberForInvoiceMapper(List<GetDcNumberForInvoiceModel> list, GetDcNumberForInvoiceResponseDto getDcNumberForInvoiceResponseDto)
        {
            Mapper.CreateMap<GetDcNumberForInvoiceModel, GetDcNumberForInvoiceList>();
            getDcNumberForInvoiceResponseDto.GetDcNumberForInvoiceList =
                Mapper.Map<List<GetDcNumberForInvoiceModel>, List<GetDcNumberForInvoiceList>>(list);

            return getDcNumberForInvoiceResponseDto;
        }

        private static GetDcDetailsForInvoiceResponseDto DcDetailsForInvoiceMapper(List<GetDcDetailsForInvoiceModel> list, GetDcDetailsForInvoiceResponseDto getDcDetailsForInvoiceResponseDto)
        {
            Mapper.CreateMap<GetDcDetailsForInvoiceModel, GetDcDetailsForInvoiceList>();
            getDcDetailsForInvoiceResponseDto.GetDcDetailsForInvoiceList =
                Mapper.Map<List<GetDcDetailsForInvoiceModel>, List<GetDcDetailsForInvoiceList>>(list);

            return getDcDetailsForInvoiceResponseDto;
        }

        private static GetInvoiceMasterResponseDto InvoiceMasterMapper(List<GetInvoiceMasterQMModel> list, GetInvoiceMasterResponseDto getInvoiceMasterResponseDto)
        {
            Mapper.CreateMap<GetInvoiceMasterQMModel, GetInvoiceMasterResponseModel>();
            getInvoiceMasterResponseDto.GetInvoiceMasterResponseModel =
                Mapper.Map<List<GetInvoiceMasterQMModel>, List<GetInvoiceMasterResponseModel>>(list);

            return getInvoiceMasterResponseDto;
        }

        private static GetInvoiceDetailsResponseDto InvoiceDetailsMapper(List<SavedInvoiceDetailsQMModel> list, GetInvoiceDetailsResponseDto getInvoiceDetailsResponseDto)
        {
            Mapper.CreateMap<SavedInvoiceDetailsQMModel, SavedInvoiceDetails>();
            getInvoiceDetailsResponseDto.GetSavedInvoiceDetailsList =
                Mapper.Map<List<SavedInvoiceDetailsQMModel>, List<SavedInvoiceDetails>>(list);

            return getInvoiceDetailsResponseDto;
        }


        #endregion
    }
}

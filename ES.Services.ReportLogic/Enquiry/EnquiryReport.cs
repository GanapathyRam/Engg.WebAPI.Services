using AutoMapper;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Model.QueryModel.Enquiry;
using ES.Services.DataTransferObjects.Request.Enquiry;
using ES.Services.DataTransferObjects.Response.Enquiry;
using ES.Services.ReportLogic.Enquiry;
using ES.Services.ReportLogic.Interface.Enquiry;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Enquiry
{
    public class EnquiryReport : IEnquiryReport
    {
        protected Application excel = null;
        protected Workbooks workbooks = null;
        protected Workbook workbook = null;

        private readonly IEnquiryRepository enquiryRepository;

        public EnquiryReport(IEnquiryRepository enquiryRepository)
        {
            this.enquiryRepository = enquiryRepository;
        }

        public void GetStockEnquiry(Int16 Option, string filePath)
        {
            var dataSet = enquiryRepository.GetStockEnquiry(Option);

            //Open();

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "StockEnquiry");
        }

        public StockEnquiryOptionResponseDto GetStockEnquiryForGrid(Int16 Option)
        {
            StockEnquiryOptionResponseDto response = new StockEnquiryOptionResponseDto();

            var model = enquiryRepository.GetStockEnquiryForGrid(Option);

            if (model != null)
            {
                if (Option == 0)
                {
                    response = GetStockEnquiryForSerialMapper((List<GetStockOptionEnquiryForSerialModel>)model.getStockOptionEnquiryForSerialModel, response);
                }
                else
                {
                    response = GetStockEnquiryForItemMapper((List<GetStockOptionEnquiryForItemModel>)model.getStockOptionEnquiryForItemModel, response);
                }
            }

            return response;
        }

        public DespatchEnquiryOptionResponseDto GetDespatchEnquiryForGrid(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto)
        {
            DespatchEnquiryOptionResponseDto response = new DespatchEnquiryOptionResponseDto();

            var model = enquiryRepository.GetDespatchEnquiryForGrid(despatchEnquiryOptionRequestDto.Option, despatchEnquiryOptionRequestDto.FromDate, despatchEnquiryOptionRequestDto.ToDate);

            if (model != null)
            {
                response = GetDespatchEnquiryForItemMapper((List<DespatchEnquiryOptionModel>)model.getDespatchEnquiryOptionModel, response);
            }

            return response;
        }

        public void GetDespacthEnquiry(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto, string filePath)
        {
            var dataSet = enquiryRepository.GetDespatchEnquiry(despatchEnquiryOptionRequestDto.Option, despatchEnquiryOptionRequestDto.FromDate, despatchEnquiryOptionRequestDto.ToDate);

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "DespacthEnquiry");
        }

        public void GetInvoicedEnquiry(string filePath)
        {
            var dataSet = enquiryRepository.GetInvoicedEnquiry();

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "InvoicedEnquiry");
        }

        public InvoicedEnquiryOptionResponseDto GetInvoicedEnquiryForGrid()
        {
            InvoicedEnquiryOptionResponseDto response = new InvoicedEnquiryOptionResponseDto();

            var model = enquiryRepository.GetInvoicedEnquiryForGrid();

            if (model != null)
            {
                response = GetInvoicedEnquiryForItemMapper((List<InvoicedEnquiryOptionModel>)model.GetInvoicedEnquiryOptionModel, response);
            }

            return response;
        }

        public void GetSerialNoEnquiry(string filePath, string SerialNo)
        {
            var dataSet = enquiryRepository.GetSerialNoEnquiry(SerialNo);

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "SerialNoEnquiry");
        }

        public SerialNoEnquiryOptionResponseDto GetSerialNoEnquiryForGrid(string SerialNo)
        {
            SerialNoEnquiryOptionResponseDto response = new SerialNoEnquiryOptionResponseDto();

            var model = enquiryRepository.GetSerialNoEnquiryForGrid(SerialNo);

            if (model != null)
            {
                response = GetSerialNoEnquiryForItemMapper((List<SerialNoEnquiryOptionModel>)model.getSerialNoEnquiryOptionModel, response);
            }

            return response;
        }


        public void GetDeliveryFollowUpEnquiry(string filePath, DateTime FromDate)
        {
            var dataSet = enquiryRepository.GetDeliveryFollowUpEnquiry(FromDate);

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "DeliveryFollowUpEnquiry");
        }

        public DeliveryFollowUpEnquiryOptionResponseDto GetDeliveryFollowUpEnquiryForGrid(DateTime FromDate)
        {
            DeliveryFollowUpEnquiryOptionResponseDto response = new DeliveryFollowUpEnquiryOptionResponseDto();

            var model = enquiryRepository.GetDeliveryFollowUpEnquiryForGrid(FromDate);

            if (model != null)
            {
                response = GetDeliveryFollowUpEnquiryForItemMapper((List<DeliveryFollowUpOptionModel>)model.getDeliveryFollowUpOptionModel, response);
            }

            return response;
        }

        public void GetSalesEnquiry(string filePath, DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type)
        {
            var dataSet = enquiryRepository.GetSalesEnquiry(FromDate, ToDate, WorkOrdeType, Option, Type);

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "SalesEnquiry");

        }

        public SalesEnquiryOptionResponseDto GetSalesEnquiryForGrid(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type)
        {
            SalesEnquiryOptionResponseDto response = new SalesEnquiryOptionResponseDto();

            var model = enquiryRepository.GetSalesEnquiryForGrid(FromDate, ToDate, WorkOrdeType, Option, Type);

            if (model != null)
            {
                response = GetSalesEnquiryForItemMapper((List<SalesEnquiryOptionModel>)model.getSalesEnquiryOptionModel, response);
            }

            return response;
        }

        public void GetSubContractStockEnquiry(string filePath)
        {
            var dataSet = enquiryRepository.GetSubContractStockEnquiry();

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "SubContractStock");

        }

        public void GetDespatchDetailsEnquiry(string filePath, DateTime FromDate, DateTime ToDate)
        {
            var dataSet = enquiryRepository.GetDespatchDetailsEnquiry(FromDate, ToDate);

            //ConvertToExcel(dataSet, filePath);

            ExportDataSet(dataSet, filePath, "DespatchDetails");

        }


        public GetSubContractStockEnquiryResponseDto GetSubContractStockEnquiryForGrid()
        {
            GetSubContractStockEnquiryResponseDto response = new GetSubContractStockEnquiryResponseDto();

            var model = enquiryRepository.GetSubContractStockEnquiryForGrid();

            if (model != null)
            {
                response = GetSubContractStockEnquiryForItemMapper((List<GetSubContractStockEnquiryModel>)model.GetSubContractStockEnquiryModelList, response);
            }

            return response;

        }

        public GetDespatchDetailsEnquiryResponseDto GetDespatchDetailsEnquiryForGrid(DateTime FromDate, DateTime ToDate)
        {
            GetDespatchDetailsEnquiryResponseDto response = new GetDespatchDetailsEnquiryResponseDto();

            var model = enquiryRepository.GetDespatchDetailsEnquiryForGrid(FromDate, ToDate);

            if (model != null)
            {
                response = GetDespatchDetailsEnquiryForItemMapper((List<GetDespatchDetailsEnquiryModel>)model.GetDespatchDetailsEnquiryModelList, response);
            }

            return response;

        }


        public void ConvertToExcel(DataSet ds, string filePath)
        {
            ////Instance reference for Excel Application

            //Microsoft.Office.Interop.Excel.Application objXL = null;

            ////Workbook refrence

            //Microsoft.Office.Interop.Excel.Workbook objWB = null;

            try

            {
                //Instancing Excel using COM services

                excel = new Microsoft.Office.Interop.Excel.Application();

                //Adding WorkBook

                workbook = excel.Workbooks.Add(ds.Tables.Count);

                //Variable to keep sheet count

                int sheetcount = 1;

                //Do I need to explain this ??? If yes please close my website and learn abc of .net .

                foreach (System.Data.DataTable dt in ds.Tables)

                {

                    //Adding sheet to workbook for each datatable

                    Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.Add();

                    //Naming sheet as SheetData1.SheetData2 etc....

                    objSHT.Name = "SheetData" + sheetcount.ToString();

                    for (int j = 0; j < dt.Rows.Count; j++)

                    {

                        for (int i = 0; i < dt.Columns.Count; i++)

                        {

                            //Condition to put column names in 1st row

                            //Excel work book indexes start from 1,1 and not 0,0

                            if (j == 0)

                            {

                                objSHT.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();

                            }

                            //Writing down data

                            objSHT.Cells[j + 2, i + 1] = dt.Rows[j][i].ToString();

                        }

                    }

                    //Incrementing sheet count

                    sheetcount++;

                }

                //Saving the work book

                //objWB.Saved = true;

                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}

                //objWB.SaveAs(filePath);

                //Closing work book

                //objWB.Close();

                //Closing excel application

                //objXL.Quit();
            }

            catch (Exception ex)

            {

                workbook.Saved = true;

                //Closing work book

                workbook.Close();

                //Closing excel application

                excel.Quit();

                Console.Write("Illegal permission");

            }
            finally
            {
                SaveAndClose(filePath);
            }

        }

        private void ExportDataSet(DataSet ds, string filePath, string fileName)
        {
            using (Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook())
            {
                workbook.Worksheets[0].Name = fileName;

                workbook.Worksheets[0].Cells.ImportDataTable(ds.Tables[0], true, 0, 0, true, false);

                workbook.Save(filePath);
            }
        }

        private void ExportDataSetToExcel(DataSet ds)
        {
            //Creae an Excel application instance

            //Create an Excel workbook instance and open it from the predefined location
            workbook = excel.Workbooks.Open(@"F:\Excel_Download\StockEnquiryOption.xlsx");

            //foreach (dynamic worksheet in workbook.Worksheets)
            //{
            //    worksheet.Cells.ClearContents();
            //}

            //workbook.SaveAs(@"F:\Excel_Download\StockEnquiryOption.xlsx");

            foreach (System.Data.DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = workbook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            SaveAndClose(@"F:\Excel_Download\StockEnquiryOption.xlsx");

        }

        public void Open()
        {
            excel = new Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.StandardFont = "Arial";
            workbooks = excel.Workbooks;
            workbook = workbooks.Add(Type.Missing);
        }

        public void SaveAndClose(string path)
        {
            if (workbook != null)
            {
                workbook.SaveAs(path);
                workbook.Close();
                Marshal.FinalReleaseComObject(workbook);
                workbook = null;

                workbooks.Close();
                Marshal.FinalReleaseComObject(workbooks);
                workbooks = null;
            }

            if (excel != null)
            {
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();

                Marshal.FinalReleaseComObject(excel.Application);
                Marshal.FinalReleaseComObject(excel);
                excel = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #region Mapper

        private static StockEnquiryOptionResponseDto GetStockEnquiryForSerialMapper(List<GetStockOptionEnquiryForSerialModel> list, StockEnquiryOptionResponseDto getStockEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<GetStockOptionEnquiryForSerialModel, GetStockOptionEnquiryForSerial>();
            getStockEnquiryOptionResponseDto.GetStockOptionEnquiryForSerialList = Mapper.Map<List<GetStockOptionEnquiryForSerialModel>, List<GetStockOptionEnquiryForSerial>>(list);

            return getStockEnquiryOptionResponseDto;
        }

        private static StockEnquiryOptionResponseDto GetStockEnquiryForItemMapper(List<GetStockOptionEnquiryForItemModel> list, StockEnquiryOptionResponseDto getStockEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<GetStockOptionEnquiryForItemModel, GetStockOptionEnquiryForItem>();
            getStockEnquiryOptionResponseDto.GetStockOptionEnquiryForItemList = Mapper.Map<List<GetStockOptionEnquiryForItemModel>, List<GetStockOptionEnquiryForItem>>(list);

            return getStockEnquiryOptionResponseDto;
        }

        private static DespatchEnquiryOptionResponseDto GetDespatchEnquiryForItemMapper(List<DespatchEnquiryOptionModel> list, DespatchEnquiryOptionResponseDto getDespatchEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<DespatchEnquiryOptionModel, DespatchEnquiryOptionResponse>();
            getDespatchEnquiryOptionResponseDto.GetDespatchEnquiryOptionResponse = Mapper.Map<List<DespatchEnquiryOptionModel>, List<DespatchEnquiryOptionResponse>>(list);

            return getDespatchEnquiryOptionResponseDto;
        }

        private static InvoicedEnquiryOptionResponseDto GetInvoicedEnquiryForItemMapper(List<InvoicedEnquiryOptionModel> list, InvoicedEnquiryOptionResponseDto getInvoicedEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<InvoicedEnquiryOptionModel, InvoicedEnquiryOptionResponse>();
            getInvoicedEnquiryOptionResponseDto.GetInvoicedEnquiryOptionResponse = Mapper.Map<List<InvoicedEnquiryOptionModel>, List<InvoicedEnquiryOptionResponse>>(list);

            return getInvoicedEnquiryOptionResponseDto;
        }

        private static SerialNoEnquiryOptionResponseDto GetSerialNoEnquiryForItemMapper(List<SerialNoEnquiryOptionModel> list, SerialNoEnquiryOptionResponseDto getSerialNoEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<SerialNoEnquiryOptionModel, SerialNoEnquiryOptionResponse>();
            getSerialNoEnquiryOptionResponseDto.getSerialNoEnquiryOptionResponse = Mapper.Map<List<SerialNoEnquiryOptionModel>, List<SerialNoEnquiryOptionResponse>>(list);

            return getSerialNoEnquiryOptionResponseDto;
        }

        private static DeliveryFollowUpEnquiryOptionResponseDto GetDeliveryFollowUpEnquiryForItemMapper(List<DeliveryFollowUpOptionModel> list, DeliveryFollowUpEnquiryOptionResponseDto getDeliveryFollowUpEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<DeliveryFollowUpOptionModel, DeliveryFollowUpEnquiryOptionResponse>();
            getDeliveryFollowUpEnquiryOptionResponseDto.GetDeliveryFollowUpEnquiryOptionResponse = Mapper.Map<List<DeliveryFollowUpOptionModel>, List<DeliveryFollowUpEnquiryOptionResponse>>(list);

            return getDeliveryFollowUpEnquiryOptionResponseDto;
        }

        private static SalesEnquiryOptionResponseDto GetSalesEnquiryForItemMapper(List<SalesEnquiryOptionModel> list, SalesEnquiryOptionResponseDto getSalesEnquiryOptionResponseDto)
        {
            Mapper.CreateMap<SalesEnquiryOptionModel, SalesEnquiryOptionResponse>();
            getSalesEnquiryOptionResponseDto.GetSalesEnquiryOptionResponse = Mapper.Map<List<SalesEnquiryOptionModel>, List<SalesEnquiryOptionResponse>>(list);

            return getSalesEnquiryOptionResponseDto;
        }

        private static GetSubContractStockEnquiryResponseDto GetSubContractStockEnquiryForItemMapper(List<GetSubContractStockEnquiryModel> list, GetSubContractStockEnquiryResponseDto getGetSubContractStockEnquiryResponseDto)
        {
            Mapper.CreateMap<GetSubContractStockEnquiryModel, GetSubContractStockEnquiryResponse>();
            getGetSubContractStockEnquiryResponseDto.GetSubContractStockEnquiryResponseList = Mapper.Map<List<GetSubContractStockEnquiryModel>, List<GetSubContractStockEnquiryResponse>>(list);

            return getGetSubContractStockEnquiryResponseDto;
        }

        private static GetDespatchDetailsEnquiryResponseDto GetDespatchDetailsEnquiryForItemMapper(List<GetDespatchDetailsEnquiryModel> list, GetDespatchDetailsEnquiryResponseDto getDespatchDetailsEnquiryResponseDto)
        {
            Mapper.CreateMap<GetDespatchDetailsEnquiryModel, GetDespatchDetailsEnquiryResponse>();
            getDespatchDetailsEnquiryResponseDto.GetDespatchDetailsEnquiryResponseList = Mapper.Map<List<GetDespatchDetailsEnquiryModel>, List<GetDespatchDetailsEnquiryResponse>>(list);

            return getDespatchDetailsEnquiryResponseDto;
        }
        #endregion
    }
}

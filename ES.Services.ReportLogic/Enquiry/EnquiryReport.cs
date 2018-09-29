﻿using AutoMapper;
using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.DataAccess.Model.QueryModel.Enquiry;
using ES.Services.DataTransferObjects.Request.Enquiry;
using ES.Services.DataTransferObjects.Response.Enquiry;
using ES.Services.ReportLogic.Enquiry;
using ES.Services.ReportLogic.Interface.Enquiry;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Enquiry
{
    public class EnquiryReport : IEnquiryReport
    {
        private readonly IEnquiryRepository enquiryRepository;

        public EnquiryReport(IEnquiryRepository enquiryRepository)
        {
            this.enquiryRepository = enquiryRepository;
        }

        public void GetStockEnquiry(Int16 Option, string filePath)
        {
            var dataSet = enquiryRepository.GetStockEnquiry(Option);

            ConvertToExcel(dataSet, filePath);
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

            ConvertToExcel(dataSet, filePath);
        }

        public void GetInvoicedEnquiry(string filePath)
        {
            var dataSet = enquiryRepository.GetInvoicedEnquiry();

            ConvertToExcel(dataSet, filePath);
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

            ConvertToExcel(dataSet, filePath);
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

            ConvertToExcel(dataSet, filePath);
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

            ConvertToExcel(dataSet, filePath);
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

        public void ConvertToExcel(DataSet ds, string filePath)
        {
            //Instance reference for Excel Application

            Microsoft.Office.Interop.Excel.Application objXL = null;

            //Workbook refrence

            Microsoft.Office.Interop.Excel.Workbook objWB = null;

            try

            {
                //Instancing Excel using COM services

                objXL = new Microsoft.Office.Interop.Excel.Application();

                //Adding WorkBook

                objWB = objXL.Workbooks.Add(ds.Tables.Count);

                //Variable to keep sheet count

                int sheetcount = 1;

                //Do I need to explain this ??? If yes please close my website and learn abc of .net .

                foreach (DataTable dt in ds.Tables)

                {

                    //Adding sheet to workbook for each datatable

                    Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)objWB.Sheets.Add();

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

                objWB.Saved = true;

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                objWB.SaveAs(filePath);

                //Closing work book

                objWB.Close();

                //Closing excel application

                objXL.Quit();
            }

            catch (Exception ex)

            {

                objWB.Saved = true;

                //Closing work book

                objWB.Close();

                //Closing excel application

                objXL.Quit();

                Console.Write("Illegal permission");

            }

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
        #endregion
    }
}

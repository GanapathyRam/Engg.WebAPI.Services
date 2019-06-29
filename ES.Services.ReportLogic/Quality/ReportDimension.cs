using AutoMapper;
using ES.Services.DataAccess.Interface.Quality;
using ES.Services.DataAccess.Model.QueryModel.Quality;
using ES.Services.DataTransferObjects.Response.Quality;
using ES.Services.ReportLogic.Interface.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Quality
{
    public class ReportDimension : IReportDimension
    {
        private readonly IDimensionRepository dimensionRepository;

        public ReportDimension(IDimensionRepository dimensionRepository)
        {
            this.dimensionRepository = dimensionRepository;
        }

        public GetDimensionEntryResponseDto GetDimensionReport(string SerialNo)
        {
            var response = new GetDimensionEntryResponseDto()
            {
                GetDimensionEntryEditResponseList = new List<GetDimensionEntryEditResponse>()
            };
            var responseDto = new GetDimensionEntryResponseDto();
            var model = dimensionRepository.GetDimensionEntryReport(SerialNo);

            if (model != null)
            {
                responseDto = DimensionEntryMapper((List<GetDimensionEntryEditModel>)model.GetDimensionEntryEditModelList, response);
                responseDto.WONumber = model.GetDimensionEntryEditModelList.FirstOrDefault().WONumber;
                responseDto.WOSerial = model.GetDimensionEntryEditModelList.FirstOrDefault().WOSerial;
                responseDto.VendorName = model.GetDimensionEntryEditModelList.FirstOrDefault().VendorName;
                responseDto.PartDescription = model.GetDimensionEntryEditModelList.FirstOrDefault().PartDescription;
                responseDto.DrawingNumber = model.GetDimensionEntryEditModelList.FirstOrDefault().DrawingNumber;
                responseDto.ItemCode = model.GetDimensionEntryEditModelList.FirstOrDefault().ItemCode;
                responseDto.MaterialDescription = model.GetDimensionEntryEditModelList.FirstOrDefault().MaterialDescription;
            }

            return responseDto;
        } 


        #region Mapper

        private static GetDimensionEntryResponseDto DimensionEntryMapper(List<GetDimensionEntryEditModel> list, GetDimensionEntryResponseDto getDimensionEntryResponseDto)
        {
            Mapper.CreateMap<GetDimensionEntryEditModel, GetDimensionEntryEditResponse>();
            getDimensionEntryResponseDto.GetDimensionEntryEditResponseList =
                Mapper.Map<List<GetDimensionEntryEditModel>, List<GetDimensionEntryEditResponse>>(list);

            return getDimensionEntryResponseDto;
        }

        #endregion
    }
}

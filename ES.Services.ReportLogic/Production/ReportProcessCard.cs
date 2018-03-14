using ES.Services.DataAccess.Interface.Production;
using ES.Services.ReportLogic.Interface.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using AutoMapper;

namespace ES.Services.ReportLogic.Production
{
    public class ReportProcessCard : IReportProcessCard
    {
        private readonly IProcessCardRepository processCardRepository;

        public ReportProcessCard(IProcessCardRepository processCardRepository)
        {
            this.processCardRepository = processCardRepository;
        }

        public GetSequenceNumberResponseDto GetSequenceNumber(GetSequenceNumberRequestDto getSequenceNumberRequestDto)
        {
            GetSequenceNumberResponseDto response = new GetSequenceNumberResponseDto();

            var model = processCardRepository.GetSequenceNumber(getSequenceNumberRequestDto.PartCode);

            if (model != null)
            {
                response = GetSequnceNumberMapper((List<GetSequenceNumberModel>)model.SequenceNumberList, response);
            }

            return response;
        }


        #region Mapper Method
        private static GetSequenceNumberResponseDto GetSequnceNumberMapper(List<GetSequenceNumberModel> list, GetSequenceNumberResponseDto getSequenceNumberResponseDto)
        {
            Mapper.CreateMap<GetSequenceNumberModel, GetSequenceNumberResponseModel>();
            getSequenceNumberResponseDto.SequenceNumberList =
                Mapper.Map<List<GetSequenceNumberModel>, List<GetSequenceNumberResponseModel>>(list);

            return getSequenceNumberResponseDto;
        }

        #endregion
    }
}

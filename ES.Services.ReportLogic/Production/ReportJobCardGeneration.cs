using AutoMapper;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.ReportLogic.Interface.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Production
{
    public class ReportJobCardGeneration : IReportJobCardGeneration
    {
        private readonly IJobCardGenerationRepository jobCardGenerationRepository;

        public ReportJobCardGeneration(IJobCardGenerationRepository jobCardGenerationRepository)
        {
            this.jobCardGenerationRepository = jobCardGenerationRepository;
        }

        public GetJobCardGenerationResponseDto GetJobCardGeneration()
        {
            var response = new GetJobCardGenerationResponseDto();

            var model = jobCardGenerationRepository.GetJobCardGeneration();

            if (model != null)
            {
               response = GetJobCardGenerationMapper((List<GetJobCardGenerationModel>)model.GetJobCardGenerationModelList, response);
            }

            return response;
        }

        #region Mapper Method

        private static GetJobCardGenerationResponseDto GetJobCardGenerationMapper(List<GetJobCardGenerationModel> list, GetJobCardGenerationResponseDto getJobCardGenerationResponseDto)
        {
            Mapper.CreateMap<GetJobCardGenerationModel, GetJobCardGenerationResponse>();
            getJobCardGenerationResponseDto.GetJobCardGenerationResponseList =
                Mapper.Map<List<GetJobCardGenerationModel>, List<GetJobCardGenerationResponse>>(list);

            return getJobCardGenerationResponseDto;
        }

        #endregion

    }
}

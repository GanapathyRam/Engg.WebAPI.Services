using ES.Services.BusinessLogic.Interface.Quality;
using ES.Services.DataAccess.Interface.Quality;
using ES.Services.DataAccess.Model.CommandModel.Quality;
using ES.Services.DataTransferObjects.Request.Quality;
using ES.Services.DataTransferObjects.Response.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Quality
{
    public class BusinessDimension : IBusinessDimension
    {
        private readonly IDimensionRepository dimensionRepository;

        public BusinessDimension(IDimensionRepository dimensionRepository)
        {
            this.dimensionRepository = dimensionRepository;
        }

        public UpdateDimensionEntryResponseDto UpdateDimensionEntry(UpdateDimensionEntryRequestDto updateDimensionEntryRequestDto)
        {
            foreach (var updateWorKOrderHeat in updateDimensionEntryRequestDto.UpdateDimensionEntryResponseList)
            {
                var cModel = new UpdateDimensioEntryCM();
                cModel.SerialNo = updateWorKOrderHeat.SerialNo;
                cModel.DimensionActual = updateWorKOrderHeat.DimensionActual;
                cModel.DatumDimesionActual = updateWorKOrderHeat.DatumDimesionActual;
                cModel.Serial = updateWorKOrderHeat.Serial;
                cModel.SequenceNumber = updateWorKOrderHeat.SequenceNumber;

                dimensionRepository.UpdateDimensionEntry(cModel);
            }

            return new UpdateDimensionEntryResponseDto();
        }
    }
}

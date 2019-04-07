using ES.Services.DataTransferObjects.Request.Quality;
using ES.Services.DataTransferObjects.Response.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Quality
{
    public interface IBusinessDimension
    {
        UpdateDimensionEntryResponseDto UpdateDimensionEntry(UpdateDimensionEntryRequestDto updateDimensionEntryRequestDto);
    }
}

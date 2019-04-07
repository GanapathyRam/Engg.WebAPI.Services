using ES.Services.DataTransferObjects.Response.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Quality
{
    public interface IReportDimension
    {
        GetDimensionEntryResponseDto GetDimensionReport(string SerialNo);
    }
}

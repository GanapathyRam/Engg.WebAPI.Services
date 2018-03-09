using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using SS.Framework.Exceptions;

namespace ES.Shared.Services.Controllers.Masters
{
    public class MaterialMasterController : ApiController, IBusinessMaterialMaster, IReportMaterialMaster
    {
        private readonly IBusinessMaterialMaster bMaterialMasterProvider;
        private readonly IReportMaterialMaster rMaterialMasterProvider;

        public MaterialMasterController()
        {
            this.bMaterialMasterProvider = ObjectFactory.GetInstance<IBusinessMaterialMaster>();
            this.rMaterialMasterProvider = ObjectFactory.GetInstance<IReportMaterialMaster>();
        }

        [HttpPost]
        public AddMaterialMasterResponseDto AddMaterialMaster(AddMaterialMasterRequestDto addMaterialMasterRequestDto)
        {
            AddMaterialMasterResponseDto addMaterialMasterResponseDto;

            try
            {
                addMaterialMasterResponseDto = bMaterialMasterProvider.AddMaterialMaster(addMaterialMasterRequestDto);
                addMaterialMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addMaterialMasterResponseDto = new AddMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addMaterialMasterResponseDto = new AddMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addMaterialMasterResponseDto;
        }

        [HttpPost]
        public GetMaterialMasterResponseDto GetMaterialMaster()
        {
            GetMaterialMasterResponseDto getMaterialMasterResponseDto;

            try
            {
                getMaterialMasterResponseDto = rMaterialMasterProvider.GetMaterialMaster();
                getMaterialMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getMaterialMasterResponseDto = new GetMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getMaterialMasterResponseDto = new GetMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getMaterialMasterResponseDto;
        }

        [HttpPost]
        public UpdateMaterialMasterResponseDto UpdateMaterialMaster(UpdateMaterialMasterRequestDto updateMaterialMasterRequestDto)
        {
            UpdateMaterialMasterResponseDto updateMaterialMasterResponseDto;

            try
            {
                updateMaterialMasterResponseDto = bMaterialMasterProvider.UpdateMaterialMaster(updateMaterialMasterRequestDto);
                updateMaterialMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateMaterialMasterResponseDto = new UpdateMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateMaterialMasterResponseDto = new UpdateMaterialMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateMaterialMasterResponseDto;
        }

        [HttpPost]
        public GetMaterialMasterListResponseDto GetMaterialMasterList()
        {
            GetMaterialMasterListResponseDto GetMaterialMasterListResponseDto;

            try
            {
                GetMaterialMasterListResponseDto = rMaterialMasterProvider.GetMaterialMasterList();
                GetMaterialMasterListResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                GetMaterialMasterListResponseDto = new GetMaterialMasterListResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                GetMaterialMasterListResponseDto = new GetMaterialMasterListResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return GetMaterialMasterListResponseDto;
        }
    }
}

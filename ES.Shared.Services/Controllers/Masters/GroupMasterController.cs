using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class GroupMasterController : ApiController, IBusinessGroupMaster, IReportGroupMaster
    {
        private readonly IBusinessGroupMaster bGroupMasterProvider;
        private readonly IReportGroupMaster rGroupMasterProvider;

        public GroupMasterController()
        {
            this.bGroupMasterProvider = ObjectFactory.GetInstance<IBusinessGroupMaster>();
            this.rGroupMasterProvider = ObjectFactory.GetInstance<IReportGroupMaster>();
        }
        [HttpPost]
        public AddGroupMasterResponseDto AddGroupMaster(AddGroupMasterRequestDto addGroupMasterRequestDto)
        {
            AddGroupMasterResponseDto aAddGroupMasterResponseDto;

            try
            {
                aAddGroupMasterResponseDto = bGroupMasterProvider.AddGroupMaster(addGroupMasterRequestDto);
                aAddGroupMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                aAddGroupMasterResponseDto = new AddGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                aAddGroupMasterResponseDto = new AddGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return aAddGroupMasterResponseDto;
        }
        [HttpPost]
        public GetGroupMasterResponseDto GetGroupMaster()
        {
            GetGroupMasterResponseDto getGroupMasterResponseDto;

            try
            {
                getGroupMasterResponseDto = rGroupMasterProvider.GetGroupMaster();
                getGroupMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getGroupMasterResponseDto = new GetGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getGroupMasterResponseDto = new GetGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGroupMasterResponseDto;
        }
        [HttpPost]
        public UpdateGroupMasterResponseDto UpdateGroupMaster(UpdateGroupMasterRequestDto updateGroupMasterRequestDto)
        {
            UpdateGroupMasterResponseDto updateGroupMasterResponseDto;

            try
            {
                updateGroupMasterResponseDto = bGroupMasterProvider.UpdateGroupMaster(updateGroupMasterRequestDto);
                updateGroupMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateGroupMasterResponseDto = new UpdateGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateGroupMasterResponseDto = new UpdateGroupMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateGroupMasterResponseDto;
        }
    }
}

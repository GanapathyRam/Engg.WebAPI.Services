using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
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
    public class SymbolMasterController : ApiController, IReportSymbolMaster, IBusinessSymbolMaster
    {
        private readonly IBusinessSymbolMaster bSymbolMasterProvider;
        private readonly IReportSymbolMaster rSymbolMasterProvider;
      
        public SymbolMasterController()
        {
             this.bSymbolMasterProvider = ObjectFactory.GetInstance<IBusinessSymbolMaster>();
            this.rSymbolMasterProvider = ObjectFactory.GetInstance<IReportSymbolMaster>();
        }
        [HttpPost]
        public GetSymbolMasterResponseDto GetSymbolMaster()
        {
            GetSymbolMasterResponseDto getSymbolMasterResponseDto;
            try
            {
                getSymbolMasterResponseDto = rSymbolMasterProvider.GetSymbolMaster();
                getSymbolMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getSymbolMasterResponseDto = new GetSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getSymbolMasterResponseDto = new GetSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getSymbolMasterResponseDto;
        }

        [HttpPost]
        public HttpResponseMessage AddOrUpdateSymbolMasterFormData()
        {
           
            HttpRequestMessage re = Request;
            var context = System.Web.HttpContext.Current.Request;
            AddSymbolMasterRequestDto addSymbolMasterRequestDto = new AddSymbolMasterRequestDto();
            UpdateSymbolMasterRequestDto updateSymbolMasterRequestDto = new UpdateSymbolMasterRequestDto();



            updateSymbolMasterRequestDto.Symbol= addSymbolMasterRequestDto.Symbol = context.Params["Symbol"];

            if (Convert.ToByte(context.Params["isExistingImage"]) == 0) { 
            foreach (string file in context.Files)
            {
                var fileContent = context.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var inputStream = fileContent.InputStream;
                     updateSymbolMasterRequestDto.Name= addSymbolMasterRequestDto.Name = fileContent.FileName;
                        updateSymbolMasterRequestDto.ContentType= addSymbolMasterRequestDto.ContentType = fileContent.ContentType;
                    using (var reader = new System.IO.BinaryReader(inputStream))
                    {
                            updateSymbolMasterRequestDto.Data= addSymbolMasterRequestDto.Data  = reader.ReadBytes(fileContent.ContentLength);
                    }
                }
            }
            }
            if (context.Params["SymbolCode"] !="null")
            {
                updateSymbolMasterRequestDto.isExistingImage = Convert.ToInt16(context.Params["isExistingImage"]);
                updateSymbolMasterRequestDto.SymbolCode = Convert.ToDecimal(context.Params["SymbolCode"]);
                var responseUpdate = this.UpdateSymbolMaster(updateSymbolMasterRequestDto);
                return Request.CreateResponse(responseUpdate);
            }
            var response= this.AddSymbolMaster(addSymbolMasterRequestDto);
            return Request.CreateResponse(response); 
        }

        public AddSymbolMasterResponseDto AddSymbolMaster(AddSymbolMasterRequestDto addSymbolMasterRequestDto)
        {
            AddSymbolMasterResponseDto addSymbolMasterResponseDto;
            try
            {
                addSymbolMasterResponseDto = bSymbolMasterProvider.AddSymbolMaster(addSymbolMasterRequestDto);
                addSymbolMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addSymbolMasterResponseDto = new AddSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addSymbolMasterResponseDto = new AddSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addSymbolMasterResponseDto;
        }
        public UpdateSymbolMasterResponseDto UpdateSymbolMaster(UpdateSymbolMasterRequestDto updateSymbolMasterRequestDto)
        {
            UpdateSymbolMasterResponseDto updateSymbolMasterResponseDto;
            try
            {
                updateSymbolMasterResponseDto = bSymbolMasterProvider.UpdateSymbolMaster(updateSymbolMasterRequestDto);
                updateSymbolMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateSymbolMasterResponseDto = new UpdateSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateSymbolMasterResponseDto = new UpdateSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }
            return updateSymbolMasterResponseDto;

        }
    }
}
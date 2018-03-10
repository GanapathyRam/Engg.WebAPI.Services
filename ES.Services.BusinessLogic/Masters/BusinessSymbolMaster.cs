using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;

namespace ES.Services.BusinessLogic.Masters
{
   public class BusinessSymbolMaster : IBusinessSymbolMaster
    {
        private readonly ISymbolMasterRepository symbolMasterRepository;
        public BusinessSymbolMaster(ISymbolMasterRepository symbolMasterRepository)
        {
            this.symbolMasterRepository = symbolMasterRepository;
        }
        public AddSymbolMasterResponseDto AddSymbolMaster(AddSymbolMasterRequestDto addSymbolMasterRequestDto)
        {
            var cModel = new AddSymbolMasterCM
            {
                Symbol = addSymbolMasterRequestDto.Symbol,
                Name = addSymbolMasterRequestDto.Name,
                ContentType= addSymbolMasterRequestDto.ContentType,
                Data= addSymbolMasterRequestDto.Data,
                CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                CreatedDateTime = System.DateTime.UtcNow
            };

            var response = symbolMasterRepository.AddSymbolMaster(cModel);

            return new AddSymbolMasterResponseDto();
        }


        public UpdateSymbolMasterResponseDto UpdateSymbolMaster(UpdateSymbolMasterRequestDto updateSymbolMasterRequestDto)
        {
            var cModel = new UpdateSymbolMasterCM
            {
                SymbolCode = updateSymbolMasterRequestDto.SymbolCode,
                Symbol = updateSymbolMasterRequestDto.Symbol,
                Name = updateSymbolMasterRequestDto.Name,
                ContentType= updateSymbolMasterRequestDto.ContentType,
                Data = updateSymbolMasterRequestDto.Data,
                UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove,
                UpdatedDateTime = System.DateTime.UtcNow,
                isExistingImage= updateSymbolMasterRequestDto.isExistingImage
            };

            var response = symbolMasterRepository.UpdateSymbolMaster(cModel);

            return new UpdateSymbolMasterResponseDto();
        }
    }
}


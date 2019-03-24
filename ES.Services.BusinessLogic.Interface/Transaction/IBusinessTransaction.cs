using ES.Services.DataTransferObjects.Request.Transaction;
using ES.Services.DataTransferObjects.Response.Transaction;

namespace ES.Services.BusinessLogic.Interface.Transaction
{
    public interface IBusinessTransaction
    {
        POResponseDto AddPurchaseOrder(PORequestDto PoRequestDto);

        POResponseDto UpdatePurchaseOrder(UpdatePORequestDto UpdatePORequestDto);

        DeletePOResponseDto DeletePurchaseOrder(DeletePORequestDto DeletePORequestDto);
    }
}

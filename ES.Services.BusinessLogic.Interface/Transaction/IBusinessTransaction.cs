using ES.Services.DataTransferObjects.Request.Transaction;
using ES.Services.DataTransferObjects.Response.Transaction;

namespace ES.Services.BusinessLogic.Interface.Transaction
{
    public interface IBusinessTransaction
    {
        POResponseDto AddPurchaseOrder(PORequestDto PoRequestDto);

        POResponseDto UpdatePurchaseOrder(UpdatePORequestDto UpdatePORequestDto);

        DeletePOResponseDto DeletePurchaseOrder(DeletePORequestDto DeletePORequestDto);

        AddGRNMasterResponseDto AddGRNMasterAndDetails(AddGRNMasterRequestDto addGRNMasterRequestDto);

        UpdateGRNMasterResponseDto UpdateGRNMasterAndDetails(UpdateGRNMasterRequestDto updateGRNMasterRequestDto);

        DeleteGRNResponseDto DeleteGRNMasterAndDetails(DeleteGRNRequestDto DeleteGRNRequestDto);

        AddIssueMasterResponseDto AddIssueMasterAndDetails(AddIssueMasterRequestDto addIssueMasterRequestDto);

        UpdateIssueMasterResponseDto UpdateIssueMasterAndDetails(UpdateIssueMasterRequestDto updateIssueMasterRequestDto);

        DeleteIssueResponseDto DeleteIssueMasterAndDetails(DeleteIssueRequestDto DeleteIssueRequestDto);
    }
}

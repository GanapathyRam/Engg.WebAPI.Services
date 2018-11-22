using ES.Services.DataAccess.Model.CommandModel.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;

namespace ES.Services.DataAccess.Interface.Production
{
    public interface IProcessCardRepository
    {
        void AddProcessCard(AddProcessCardCM addProcessCardCM);

        GetSequenceNumberQM GetSequenceNumber(decimal PartCode);

        GetProcessCardQM GetProcessCard(string vendorCode);

        void UpdateProcessCard(UpdateProcessCardCM updateProcessCardCM);

        void DeleteProcessCard(DeleteProcessCardCM deleteProcessCardCM);

        GetProcesssCardCopyQM GetProcessCardCopy();

        void AddProcessCardCopy(decimal FromPartCode, decimal ToPartCode);
    }
}

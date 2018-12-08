using ES.Services.DataTransferObjects.Request.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;

namespace ES.Services.ReportLogic.Interface.Authentication
{
    public interface IReportAuthentication
    {
        AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequest);
        RoleResponseDto GetRoles();
        UsersResponseDto GetUsers();
    }
}

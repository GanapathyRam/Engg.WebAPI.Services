
namespace ES.ExceptionAttributes
{
    public class ExceptionCodes
    {
        public const int ServiceResponseStatusFailure = 0;
        public const int ActivationMailFailure = 2000;
        public const int InvalidDamResponse = 2001;
        public const int InvalidDamStatus = 2002;
        public const int InvalidEmailPattern = 2002;
        public const int InvalidColumnCount = 2100;
        public const int InvalidColumnSequenceAndName = 2101;
        public const int UserAlreadyExists = 2051;

        public const int BadRequest = 400;
        public const int DataNotFound = 601;
        public const int Forbidden = 403;
        public const int InconsistentData = 605;
        public const int InternalServerError = 500;
        public const int InvalidConfigEntry = 602;
        public const int InvalidInput = 603;
        public const int OperationTimedOut = 604;
        public const int RequestedUrlNotFound = 404;
        public const int RequestTimeout = 408;

        public const int InconsistentDataError = 908;
        public const int InvalidAuthentication = 1000;
        public const int InvalidConfirmPassword = 1001;
        public const int InvalidPolicyPassword = 1002;
        public const int InvalidOldPassword = 1003;
        public const int InvalidNewPassword = 1004;
        public const int CreateTokenUrlFailed = 1005;
        public const int SecurityQuestionExists = 1006;
        public const int InvalidUser = 1007;
        public const int FirstTimeLogin = 1008;
        public const int AccountLocked = 1010;
        public const int IncorrectSecurityAnswer = 1011;
        public const int ResetPasswordUrlExpired = 1012;
        public const int InvalidResetPasswordUrl = 1013;
        public const int SecurityQuestionNotConfigured = 1014;
        public const int InvalidSecurityQuestion = 1015;
        public const int UserNameAlreadyExists = 1016;
        public const int PasswordExpired = 1017;
        public const int InvalidApplicationId = 1018;
        public const int InvalidRequest = 1019;
        public const int AuthorizedRolesNotExist = 1020;
        public const int AuthorizedDataNotExist = 1021;
        public const int UserIsNotAuthorized = 1022;
        public const int InvalidResetPasswordToken = 1023;
        public const int ChangePasswordNotConfigured = 1024;
        public const int InvalidActivationToken = 1025;
        public const int ActivationTokenExpired = 1026;
        public const int UserActivationTokenVerified = 1027;
        public const int UserDeletion = 1028;
        public const int UserInActive = 1029;
        public const int InvalidResetPasswordFlow = 1030;
        public const int RegenerateResetPassword = 1031;
        public const int ResetPasswordTokenUsed = 1032;
        public const int InvalidEmailFormat = 1033;
        public const int InvalidUserName = 1034;
        public const int InvalidPhoneNumber = 1035;
        public const int MandatoryFieldsMissing = 1036;
        public const int InvalidUserOnBoardingType = 1037;
        public const int InvalidUserFirstName = 1038;
        public const int InvalidUserLastName = 1039;
        public const int RegisterMailFailure = 1040;
        public const int InActiveUser = 1041;
        public const int InActiveUserAndTokenNotVerified = 1042;
        public const int NonCustomUser = 1043;
        public const int UserExists = 1044;
        public const int UserNotHaveApplicationAccess = 1045;
        public const int RoleNotExists = 1046;
        public const int RoleMappingEarlier = 1047;
        public const int ChangeSecurityQuestionsNotAllowed = 1048;
        public const int InvalidPassword = 1049;
        public const int InavalidUserAuthority = 1050;
        public const int UserEmailVerificationTokenNotRequired = 1051;
        public const int RegenarateResetPassword = 1031;
        public const int UserIsAlreadyAuthorized = 1052;
        public const int UserNameNotExists = 1053;
        public const int InvalidPasswordEntered = 1054;
        public const int InvalidRegisteredUser = 1055;
        public const int RegisteredUserNotMappedToAppplication = 1056;
    }
}

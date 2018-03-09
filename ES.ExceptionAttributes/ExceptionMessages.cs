
namespace ES.ExceptionAttributes
{
    public class ExceptionMessages
    {
        public const string ActivationMailFailure = "Activation Email has not been triggered ! Please contact your administrator";
        public const string InvalidDamResponse = "Invalid response from Digital Asset Management server";
        public const string InvalidDamStatus = "Invalid Digital Management server status ";
        public const string InvalidEmailPattern = "Invalid email address";
        public const string InvalidColumnCount = "Invalid column count";
        public const string InvalidColumnSequenceAndName = "Invalid column sequence and name";
        public const string UserAlreadyExists = "User already exists.";

        public const string DataNotFound = "Data not found";
        public const string InconsistentData = "InconsistentData";
        public const string InvalidConfigEntry = "Not able to get config entry";
        public const string InvalidInput = "Invalid input";
        public const string OperationTimedOut = "Operation tmed out";

        public const string InvalidAuthentication = "Invalid credentials";
        public const string AccountLocked = "Account Locked! Login attempts exceeded. Please contact Support or click \'Forgot Password\' to unlock your account.";
        public const string IncorrectSecurityAnswer = "Incorrect answer/s!";
        public const string ResetPasswordUrlExpired = "This URL has expired";
        public const string InvalidResetPasswordUrl = "Invalid reset password URL";
        public const string SecurityQuestionNotConfigured = "Security questions are not configured";
        public const string InconsistentDataError = "Inconsistent data error";
        public const string ChangePasswordNotConfigured = "User needs to change the password to set security questions and answers";
        public const string PasswordExpired = "Your password has expired. Please change your password.";
        public const string AuthorizedRolesNotExist = "User is not linked to this role";
        public const string AuthorizedDataNotExist = "Authorized modules and functions are not available";
        public const string UserIsNotAuthorized = "User/Application is not registered";
        public const string InvalidResetPasswordToken = "This URL has expired";
        public const string InActiveUser = "Your account is inactive. Please contact Support for more information.";
        public const string InActiveUserAndTokenNotVerified = "Account not yet activated";
        public const string InvalidConfirmPassword = "Confirm password is not matching with new password";
        public const string InvalidPolicyPassword = "Password does not follow the password policy rules";
        public const string InvalidOldPassword = "Invalid old password";
        public const string InvalidNewPassword = "This password was already used in the past. Please give a different password.";
        public const string CreateTokenUrlFailed = "Unable to create temporary token url";
        public const string SecurityQuestionExists = "Security questions already configured by the user";
        public const string InvalidUser = "Invalid User";
        public const string FirstTimeLogin = "You can not change your password, because security questions are not configured";
        public const string InvalidApplicationId = " Invalid Application ID";
        public const string UserNameAlreadyExists = "User already exists in the system";
        public const string InvalidPasswordPolicy = "Provided password does not follow the password policy rules";
        public const string InvalidPassword = "Password should be of 8-30 character length and must follow atleast 3 of the following 4 rules - 1. Must contain atleast one upper case letter, 2. Must contain atleast one lower case letter, 3. Must contain atleast one digit, 4. Must contain atleast one special character @,#,%,* etc";
        public const string InvalidSecurityQuestion = "Invalid security question/s";
        public const string InvalidRequest = "Invalid request";
        public const string InvalidActivationToken = "Invalid Activation Token";
        public const string ActivationTokenExpired = "Activation Token expired";
        public const string UserActivationTokenVerified = "User email verification token verified earlier";
        public const string UserDeletion = "User account deleted due to invalid attempts";
        public const string InvalidResetPasswordFlow = "We are sorry. This link has expired. Kindly click \'Forgot Password\' again to reset your password.";
        public const string RegenarateResetPassword = "Security question validation has failed, please re-generate token to proceed with reset password";
        public const string ResetPasswordTokenUsed = "Generated token has already been used to reset password";
        public const string InvalidEmailFormat = "Invalid email address";
        public const string InvalidUserName = "Invalid username";
        public const string InvalidUserFirstName = "Invalid user first name";
        public const string InvalidUserLastName = "Invalid user last name";
        public const string InvalidPhoneNumber = "Invalid phone number";
        public const string NonCustomUser = "You are not custom user";
        public const string UserInActive = "Your account is inactive. Please contact Support for more information.";
        public const string UserExists = "User account is not activated, Please activate";
        public const string UserNotHaveApplicationAccess = "User and application are not associated";
        public const string RoleNotExists = "Role does not exist";
        public const string RoleMappingEarlier = "User is mapped with the role earlier";
        public const string ChangeSecurityQuestionsNotAllowed = "Please change your password before changing security questions";
        public const string InavalidUserAuthority = "You are not authorized to perform this action";
        public const string UserEmailVerificationTokenNotRequired = "User email verification not required";
        public const string UserIsAlreadyAuthorized = "User already have application access.";
        public const string UserNameNotExists = "User does not exist in the system.";
        public const string RegisteredUserNotMappedToAppplication = "User does not exists for this application";
    }
}

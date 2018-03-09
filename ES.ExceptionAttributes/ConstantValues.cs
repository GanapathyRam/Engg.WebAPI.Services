using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ExceptionAttributes
{
    public static class ConstantValues
    {
        #region "General"

        /// <summary>
        /// The token user data.
        /// </summary>
        public const string TokenUserData = "User Authenticated";

        /// <summary>
        /// The ticket expiry time.
        /// </summary>
        public const int TicketExpieryTime = 30;

        /// <summary>
        /// The ticket version.
        /// </summary>
        public const int TicketVersion = 1;

        /// <summary>
        /// The ticket is persistent.
        /// </summary>
        public const bool TicketIsPersistent = false;

        /// <summary>
        /// The is role assignment complete.
        /// </summary>
        public const bool IsRoleAssignmentComplete = true;

        #endregion

        /// <summary>
        /// The output bytes length.
        /// </summary>
        public const int OutputBytesLength = 32;

        /// <summary>
        /// The iteration count.
        /// </summary>
        public const int IterationCount = 1000;

        /// <summary>
        /// The question to answer.
        /// </summary>
        public const int QuestionToAnswer = 5;

        /// <summary>
        /// The password min length.
        /// </summary>
        public const int PasswordMinLength = 8;

        /// <summary>
        /// The password max length.
        /// </summary>
        public const int PasswordMaxLength = 30;

        /// <summary>
        /// The phone number.
        /// </summary>
        public const string PhoneNumber = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";

        /// <summary>
        /// The space.
        /// </summary>
        public const string Space = " ";

        /// <summary>
        /// The db exception.
        /// </summary>
        public const int DbExceptionCode = 950;

        /// <summary>
        /// The invalid authentication.
        /// </summary>
        public const string DbExceptionCodeMessage = "Some internal error occurred, please try again later";

        /// <summary>
        /// The custom exception.
        /// </summary>
        public const int CustomException = 951;

        /// <summary>
        /// The solution star star exception code.
        /// </summary>
        public const int SsExceptionCode = 953;

        /// <summary>
        /// The controls type.
        /// </summary>
        public enum UserRole
        {
            /// <summary>
            /// The vendor.
            /// </summary>
            None = 0,

            /// <summary>
            /// The vendor.
            /// </summary>
            Vendor = 101,

            /// <summary>
            /// The reviewer.
            /// </summary>
            Reviewer = 102,

            /// <summary>
            /// The service manager.
            /// </summary>
            ServiceManager = 103,

            /// <summary>
            /// The approver.
            /// </summary>
            Approver = 104,

            /// <summary>
            /// The vendor manager.
            /// </summary>
            VendorManager = 105,

            /// <summary>
            /// The vendor manager.
            /// </summary>
            ReCascadeAdmin = 10104,
        }
    }
}

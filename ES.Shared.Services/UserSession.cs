using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ES.Shared.Services
{
    public class UserSession
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user global unique identifier.
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Gets or sets the user role id.
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the vendor id.
        /// </summary>
        public long VendorId { get; set; }

        /// <summary>
        /// Gets or sets the user name email.
        /// </summary>
        public string UserNameEmail { get; set; }

        /// <summary>
        /// Gets or sets the vendor name email.
        /// </summary>
        public string VendorNameEmail { get; set; }

        /// <summary>
        /// Gets or sets the user type like Custom user = 2  or AD user = 1.
        /// </summary>
        public short UserType { get; set; }

        /// <summary>
        /// Gets or sets the IsFirstTimeLogin like 1 first time login
        /// </summary>
        public short AccountSettingView { get; set; }

        /// <summary>
        /// Gets or sets the service id.
        /// </summary>
        public short ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the user on boarding category.
        /// </summary>
        public short OnBoardingCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is security question answer required.
        /// </summary>
        public bool IsSecurityQuestionAnswerRequired { get; set; }
    }
}
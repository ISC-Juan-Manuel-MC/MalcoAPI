using MalcoCorporateFramawork.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalcoCorporateAPI.Controllers
{
    public class Constants
    {
        #region Email configuration
        public const string EMAIL_SERVER = "EmailServer";
        public const string EMAIL_PORT = "EmailPort";
        public const string EMAIL_SECURE_CONNECTION = "EmailSecureConnection";
        public const string EMAIL = "Email";
        public const string EMAIL_PASSWORD = "EmailPassword";
        #endregion

        #region Emails options
        public const string EMAIL_ALIAS_EMISOR = "MalCo Corporate";
        public const string EMAIL_ALIAS_RECEPTOR = "Associate";
        #endregion


        public static Email.Configuration GetNewEmailConfiguration()
        {
            return new Email.Configuration(Environment.GetEnvironmentVariables()[Constants.EMAIL_SERVER].ToString(),
                                        Int32.Parse(Environment.GetEnvironmentVariables()[Constants.EMAIL_PORT].ToString()),
                                        Boolean.Parse(Environment.GetEnvironmentVariables()[Constants.EMAIL_SECURE_CONNECTION].ToString()),
                                        Environment.GetEnvironmentVariables()[Constants.EMAIL].ToString(),
                                        Environment.GetEnvironmentVariables()[Constants.EMAIL_PASSWORD].ToString(),
                                        Constants.EMAIL_ALIAS_EMISOR
                                        );
        }
    }
}

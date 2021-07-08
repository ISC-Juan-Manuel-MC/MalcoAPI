using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules.Errors
{
    public class ListOfErrorsLogin
    {
        public static ErrorCatched LOGIN_INCORRECT = new ErrorCatched(
                    "Login-0001",
                    "Security - Login",
                    "User try to use a incorrect credential",
                    "Verify credentials and try again");
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules.Errors
{
    public class ListOfErrorsProfile
    {
        public static ErrorCatched PERSON_NOT_FOUND = new ErrorCatched(
                    "Profile-0001",
                    "General - Profile",
                    "The person assined to profile not found",
                    "Please try to login again");

        public static ErrorCatched PROFILE_NOT_FOUND = new ErrorCatched(
                    "Profile-0002",
                    "General - Profile",
                    "Profile not found",
                    "Please try to login again");
    }
}

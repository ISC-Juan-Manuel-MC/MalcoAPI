using APIModels.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules.General
{
    public class Password : BusinessRules<Profile>
    {

        public DateTime RecoverStep1(string Email)
        {

            return DateTime.Now.ToUniversalTime();
        }

    }
}

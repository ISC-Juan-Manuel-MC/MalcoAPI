using MalcoCorporateFramawork.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules
{
    public interface IBusinessRules
    {
        void LoadDefaultRules();
        bool IsValid();
    }
}

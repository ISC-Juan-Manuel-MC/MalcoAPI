using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateFramawork.Validations
{
    public class ValidationRule
    {
        public Func<bool> Conditions { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsOptional { get; set; }

        public ValidationRule(Func<bool> condition, string errorMessage)
        {
            this.Conditions = condition;
            this.ErrorMessage = errorMessage;
            this.IsOptional = false;
        }

        public bool ExecuteRule()
        {
            return this.Conditions.Invoke();
        }

        public string EvaluateRule()
        {
            if (!this.ExecuteRule())
                return this.ErrorMessage;

            return String.Empty;
        }

    }
}

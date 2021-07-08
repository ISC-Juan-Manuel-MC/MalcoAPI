using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace MalcoCorporateFramawork.Validations
{
    public class Validator
    {
        const bool POSITIVE_RESULT = true;

        public static bool IsValid(List<ValidationRule> Rules)
        {
            return (EvaluateEntity(Rules).Count == 0);
        }

        public static List<ValidationRule> EvaluateEntity(List<ValidationRule> Rules)
        {
            List<ValidationRule> RulesNoPassed = new List<ValidationRule>();

            foreach (ValidationRule rule in Rules)
            {
                if (rule.ExecuteRule())
                {
                    RulesNoPassed.Add(rule);
                }
            }

            return RulesNoPassed;
        }

        private static string GetGenericMessage(string PropertyName)
        {
            string KeyPropertyName = "PropertyName";
            string Statement = "El campo @"+ KeyPropertyName + " es requerido";

            return Statement.Replace("@"+ KeyPropertyName, PropertyName);
        }

        public static ValidationRule GetRuleStringRequired(String Property, string PropertyName)
        {
            return new ValidationRule(() =>  Property.Trim().Equals(String.Empty),
                                      GetGenericMessage(PropertyName));
        }

        public static ValidationRule GetRuleStringNotNull(String Property, string PropertyName)
        {
            return new ValidationRule(() => Property == null,
                                      GetGenericMessage(PropertyName));
        }

        public static ValidationRule GetRulePercentage(decimal Property, string PropertyName)
        {
            return new ValidationRule(() => !(Property>=0 && Property <=100),
                                      GetGenericMessage(PropertyName));
        }

        public static ValidationRule GetRuleNotIsAdult(DateTime Property)
        {
            return new ValidationRule(() => NotIsAdult(Property),
                                      "No se tiene la edad minima requerida");
        }

        private static bool NotIsAdult(DateTime Birthday)
        {
            if (Birthday.Year >= DateTime.Now.Year)
                return true;

            return (DateTime.Now.AddYears(-Birthday.Year).Year < 18);
        }


    }
}

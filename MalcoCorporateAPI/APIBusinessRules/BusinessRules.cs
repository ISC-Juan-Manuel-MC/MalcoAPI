using APIModels;
using MalcoCorporateFramawork.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules
{
    public class BusinessRules<T>: IBusinessRules
    {
        protected List<ValidationRule> Rules = null;
        protected List<ValidationRule> RulesWithError = null;
        protected DAO<T> DAOEntity = null;

        public BusinessRules()
        {
            DAOEntity = new DAO<T>();
            CreateList();
        }

        private void CreateList()
        {
            this.Rules = new List<ValidationRule>();
            this.RulesWithError = new List<ValidationRule>();
        }

        public virtual void LoadDefaultRules()
        {

        }

        public bool IsValid()
        {
            LoadRulesIfHaveErrors();
            return this.RulesWithError.Count == 0;
        }

        private void LoadRulesIfHaveErrors()
        {
            this.RulesWithError = Validator.EvaluateEntity(this.Rules);
        }

        public List<ValidationRule> GetListOfErrors()
        {
            return this.RulesWithError;
        }

        public string GetErrors()
        {
            string Errors = String.Empty;

            foreach(ValidationRule Rule in this.RulesWithError)
            {
                Errors += (Errors.Equals(String.Empty) ? String.Empty : Environment.NewLine) + Rule.ErrorMessage;
            }

            return Errors;
        }

    }
}

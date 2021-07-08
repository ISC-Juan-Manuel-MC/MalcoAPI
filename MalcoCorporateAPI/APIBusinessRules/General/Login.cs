using APIModels.General;
using MalcoCorporateAPIBusinessRules.Errors;
using MalcoCorporateFramawork.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MalcoCorporateAPIBusinessRules.General
{
    public class Login : BusinessRules<Profile>
    {
        private const bool TRUE_FLAG = true;
        private Profile UserProfile = null;

        public Login()
        {
            this.UserProfile = new Profile();
            LoadDefaultRules();
        }

        public override void LoadDefaultRules()
        {
            this.Rules.Add(Validator.GetRuleStringNotNull(this.UserProfile.Email,
                                                          "Correo electrónico"));
            this.Rules.Add(Validator.GetRuleStringRequired(this.UserProfile.Email,
                                                           "Correo electrónico"));

            this.Rules.Add(Validator.GetRuleStringNotNull(this.UserProfile.Password,
                                                          "Contraseña"));
            this.Rules.Add(Validator.GetRuleStringRequired(this.UserProfile.Password,
                                                           "Contraseña"));
        }

        public bool UserCanDoLogin(string UserID,string Password)
        {
            SetValuesForValidation(UserID,Password);

            if (!this.IsValid())
                throw new Exception(this.GetErrors());

            if (UserIsAuthenticated(UserID))
                if (UserIsAuthorized(Password))
                    return TRUE_FLAG;

            this.RulesWithError.Add(new ValidationRule(() => { return !TRUE_FLAG; }, ListOfErrorsLogin.LOGIN_INCORRECT.GetJson()));

            return !TRUE_FLAG;
        }

        private void SetValuesForValidation(string UserID, string Password)
        {
            this.UserProfile = new Profile();
            this.UserProfile.Email = UserID;
            this.UserProfile.Password = Password;
        }

        private bool UserIsAuthorized(string UserID)
        {
            this.UserProfile = this.DAOEntity.GetByIds(new Object[] { UserID });

            return UserProfile != null;
        }

        private bool UserIsAuthenticated(string Password)
        {
            if (UserProfile != null)
            {
                //Start encrypt process ************************************************** Pending
                string EncryptedPassword = Password;
                //End   encrypt process ************************************************** Pending

                if (this.UserProfile.Password.Equals(EncryptedPassword))
                    return TRUE_FLAG;
            }
            return !TRUE_FLAG;
        }
    }
}

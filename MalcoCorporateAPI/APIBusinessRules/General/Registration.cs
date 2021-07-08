using APIModels.General;
using MalcoCorporateAPIBusinessRules;
using MalcoCorporateAPIBusinessRules.General;
using MalcoCorporateAPIModels;
using MalcoCorporateFramawork.Validations;
using System;

namespace APIBusinessRules.General
{
    public class Registration: BusinessRules<Profile>
    {
        private Profile UserProfile = null;

        public Registration(Profile Profile):base()
        {
            this.UserProfile = Profile;
            LoadDefaultRules();
            this.DAOEntity = new DAOProfile();
        }

        public override void LoadDefaultRules()
        {
            this.LoadDefaultRulesForPerson();
            this.LoadDefaultRulesForProfile();
        }

        private void LoadDefaultRulesForProfile()
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

        private void LoadDefaultRulesForPerson()
        {
            this.Rules.Add(Validator.GetRuleStringNotNull(this.UserProfile.Person.FullName,
                                                          "Nombre completo"));

            this.Rules.Add(Validator.GetRuleStringRequired(this.UserProfile.Person.FullName, 
                                                           "Nombre completo"));

            this.Rules.Add(Validator.GetRuleStringNotNull(this.UserProfile.Person.Cellphone,
                                                           "Numero de celular"));
            this.Rules.Add(Validator.GetRuleStringRequired(this.UserProfile.Person.Cellphone,
                                                           "Numero de celular"));

            this.Rules.Add(Validator.GetRuleNotIsAdult(this.UserProfile.Person.Birthday));
        }

        public Profile Save()
        {
            return this.DAOEntity.Save(this.UserProfile);
        }

        public Profile Update()
        {
            return this.DAOEntity.Update(this.UserProfile);
        }

        public bool DisableProfile()
        {
            return this.DAOEntity.Delete(this.UserProfile);
        }

        public Profile GetUserProfileAnalized()
        {
            return this.UserProfile;
        }
    }
}

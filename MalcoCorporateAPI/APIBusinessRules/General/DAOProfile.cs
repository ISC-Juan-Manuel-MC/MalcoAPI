using APIModels.General;
using MalcoCorporateAPIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MalcoCorporateAPIBusinessRules.Errors;
using MalcoCorporateFramawork.Generics;

namespace MalcoCorporateAPIBusinessRules.General
{
    public class DAOProfile : DAO<Profile>
    {

        public override List<Profile> Get()
        {
            return this.DBContext.Profiles.ToList();
        }

        public override List<Profile> Get(params object[] Ids)
        {
            int FirstElement = 0;
            string Email = (string)Ids.ElementAt(FirstElement);

            return this.DBContext.Profiles.Where(Entity => Entity.Email == Email).ToList();
        }

        public override Profile GetByIds(params object[] Ids)
        {
            int FirstElement = 0;
            string Email = (string)Ids.ElementAt(FirstElement);

            return this.DBContext.Profiles.Where(Entity => Entity.Email == Email).FirstOrDefault();
        }

        public override Profile Save(Profile Entity)
        {
            TransactionalProcess(() => {
                LogChangesModel LogChanges = LogChangesModel.GetModelForCreation(Entity.Email);

                //Fill log fields
                PrepareEntity(ref Entity, LogChanges);

                //add entities
                this.DBContext.Persons.Add(Entity.Person);
                this.DBContext.Profiles.Add(Entity);

                //apply the changes
                this.DBContext.SaveChanges();
            });
            return Entity;
        }

        public override Profile Update(Profile Entity)
        {
            TransactionalProcess(() => {
                LogChangesModel LogChanges = LogChangesModel.GetModelForUpdate(Entity.Email);

                //Load Current entities
                Person CurrentPerson = this.DBContext.Persons.Where(item => item.ID == Entity.Person.ID).FirstOrDefault();
                if (CurrentPerson == null)
                    throw new Exception(ListOfErrorsProfile.PERSON_NOT_FOUND.GetJson());

                Profile CurrentProfile = this.DBContext.Profiles.Where(item => item.Email == Entity.Email).FirstOrDefault();
                if (CurrentProfile == null)
                    throw new Exception(ListOfErrorsProfile.PROFILE_NOT_FOUND.GetJson());

                //Fill log fields
                PrepareEntity(ref Entity, LogChanges,(!CurrentProfile.Password.Equals(Entity.Password)));

                //Populate changes
                this.DBContext.Entry(CurrentPerson).CurrentValues.SetValues(Entity.Person);
                this.DBContext.Entry(Entity.Person).State = EntityState.Modified;

                this.DBContext.Entry(CurrentProfile).CurrentValues.SetValues(Entity.Person);
                this.DBContext.Entry(Entity).State = EntityState.Modified;

                //apply the changes
                this.DBContext.SaveChanges();
            });

            return Entity;
        }

        private void PrepareEntity(ref Profile Entity, LogChangesModel LogChanges, bool EncryptPassword = true)
        {
            if (LogChanges.IsCreationModel)
            {
                Entity.Person.ID = GenericFunctions.GetNewUUID();
                Entity.PersonID = Entity.Person.ID;
            }


            if (EncryptPassword)
            {
                //Start encrypt process ************************************************** Pending
                string EncryptedPassword = Entity.Password;
                Entity.Password = EncryptedPassword;
                //End   encrypt process ************************************************** Pending
            }


            Entity.Person.StorageDate = LogChanges.StorageDate;
            Entity.Person.StorageProfile = LogChanges.StorageProfile;
            Entity.Person.UpdatedDate = LogChanges.UpdatedDate;
            Entity.Person.UpdatedProfile = LogChanges.UpdatedProfile;


            Entity.StorageDate = LogChanges.StorageDate;
            Entity.StorageProfile = LogChanges.StorageProfile;
            Entity.UpdatedDate = LogChanges.UpdatedDate;
            Entity.UpdatedProfile = LogChanges.UpdatedProfile;
        }

        public override bool Delete(Profile Entity)
        {
            bool UnsuccessfulProcess = false;

            TransactionalProcess(() => {
                LogChangesModel LogChanges = LogChangesModel.GetModelForUpdate(Entity.Email);

                Profile CurrentProfile = this.DBContext.Profiles.Where(item => item.Email == Entity.Email).FirstOrDefault();
                if (CurrentProfile == null)
                    throw new Exception(ListOfErrorsProfile.PROFILE_NOT_FOUND.GetJson());

                //Fill log fields
                bool NotEncryptPassword = false;
                PrepareEntity(ref Entity, LogChanges, NotEncryptPassword);
                Entity.Status = (int)Profile.STATUS.DISABLED;

                //Populate changes
                this.DBContext.Entry(CurrentProfile).CurrentValues.SetValues(Entity.Person);
                this.DBContext.Entry(Entity).State = EntityState.Modified;

                //apply the changes
                this.DBContext.SaveChanges();

                UnsuccessfulProcess = !UnsuccessfulProcess;

            });

            return UnsuccessfulProcess;
        }
    }
}

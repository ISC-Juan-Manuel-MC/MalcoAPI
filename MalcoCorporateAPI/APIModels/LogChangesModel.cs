using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIModels
{
    public class LogChangesModel
    {
        public bool IsCreationModel { get; set; }
        public DateTime StorageDate { get; set; }
        public string StorageProfile { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public String UpdatedProfile { get; set; }


        public static LogChangesModel GetModelForCreation(string Profile) {
            LogChangesModel Model = new LogChangesModel
            {
                IsCreationModel = true,
                StorageDate = DateTime.Now,
                StorageProfile = Profile,
                UpdatedDate = null,
                UpdatedProfile = null
            };

            return Model;    
        }

        public static LogChangesModel GetModelForUpdate(string Profile)
        {
            LogChangesModel Model = new LogChangesModel
            {
                IsCreationModel = false,
                StorageDate = DateTime.Now,
                StorageProfile = Profile,
                UpdatedDate = DateTime.Now,
                UpdatedProfile = Profile
            };

            return Model;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Text;

namespace MalcoCorporateFramawork.Generics
{
    public class GenericFunctions
    {

        public static Object TryCatchProcess(Func<Object> Process, Func<Exception,Object> ProblemResult)
        {
            try
            {
                return Process.Invoke();
            }
            catch (Exception ex)
            {

                return ProblemResult.Invoke(ex);
            }
        }

        public static string ConvertToJson(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }

        public static T ConvertJsonToObject<T>(string JSON)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(JSON);
        }

        public static string GetNewUUID()
        {
            return Guid.NewGuid().ToString();
        }
    
        public static string GetStringFromFile(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllText(FilePath);
        }

        public static string ReplaceText(string Text, string OldText, string NewText)
        {
            return Text.Replace(OldText, NewText);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    }
}

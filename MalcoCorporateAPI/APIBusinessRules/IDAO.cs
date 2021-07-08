using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules
{
    public interface IDAO<T>
    {
        T Save(T Entity);
        T Update(T Entity);
        List<T> Get();
        List<T> Get(params object[] Ids);
        T GetByIds(params object[] Ids);
        bool Delete(T Entity);
    }
}

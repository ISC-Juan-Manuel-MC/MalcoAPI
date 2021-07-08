using APIModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace MalcoCorporateAPIBusinessRules
{
    public class DAO<T>:IDAO<T>
    {
        protected DBConnection DBContext = null;

        public DAO()
        {
            this.DBContext = new DBConnection();
        }

        public DAO(DBConnection Connection)
        {
            this.DBContext = Connection;
        }
        public void TransactionalProcess(Action Process)
        {
            using (var tran = this.DBContext.Database.BeginTransaction())
            {
                try
                {
                    Process.Invoke();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        public virtual T Save(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> Get()
        {
            throw new NotImplementedException();
        }

        public virtual List<T> Get(params object[] Ids)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual T GetByIds(params object[] Ids)
        {
            throw new NotImplementedException();
        }
    }
}

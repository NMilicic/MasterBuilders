using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Data
{
    public class Repository<T> : IRepository<T>, IDisposable
    {
        protected ISession _session = null;
        protected ITransaction _transaction = null;
        public Repository()
        {
            _session = Database.OpenSession();
        }
        public Repository(ISession session)
        {
            _session = session;
        }

        #region Transaction and Session Management Methods
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _transaction.Commit();
            CloseTransaction();
        }
        public void RollbackTransaction()
        {
            _transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }
        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }
        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
        #endregion

        #region IRepository Members
        public virtual void Save(T obj)
        {
            _session.SaveOrUpdate(obj);
            _session.Flush();
        }
        public virtual void Delete(T obj)
        {
            _session.Delete(obj);
        }
        public virtual T GetById(object Id)
        {
            return _session.Get<T>(Id);
        }
        public virtual IQueryable<T> Query()
        {
            return _session.Query<T>();
        }
        #endregion


        #region IDisposable Members
        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                CommitTransaction();
            }
            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }
        #endregion
    }
}

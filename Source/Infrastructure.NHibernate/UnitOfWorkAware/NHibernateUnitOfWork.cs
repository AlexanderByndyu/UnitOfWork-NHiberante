using System;
using System.Data;
using NHibernate;
using NHibernate.Context;
using OS.Infrastructure.Domain.UnitOfWork;

namespace OS.Infrastructure.NHibernate.UnitOfWorkAware
{
    internal class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private ITransaction transaction;

        public NHibernateUnitOfWork(ISession session, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            CurrentSessionContext.Bind(session);

            this.session = session;
            transaction = session.BeginTransaction(isolationLevel);
        }

        #region IUnitOfWork Members

        public void Dispose()
        {
            if (!transaction.WasCommitted && !transaction.WasRolledBack)
            {
                transaction.Rollback();
            }
            transaction.Dispose();
            transaction = null;

            CurrentSessionContext.Unbind(session.SessionFactory);
            session.Dispose();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        #endregion
    }
}
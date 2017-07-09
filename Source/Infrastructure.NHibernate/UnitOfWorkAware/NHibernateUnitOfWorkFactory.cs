using System.Data;
using OS.Infrastructure.Domain.UnitOfWork;

namespace OS.Infrastructure.NHibernate.UnitOfWorkAware
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        #region IUnitOfWorkFactory Members

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new NHibernateUnitOfWork(NHibernateHelper.SessionFactory.OpenSession(), isolationLevel);
        }

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        #endregion
    }
}
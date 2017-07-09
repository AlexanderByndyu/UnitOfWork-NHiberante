using NHibernate;
using OS.Infrastructure.NHibernate.UnitOfWorkAware;

namespace OS.Infrastructure.NHibernate
{
    ///<summary>
    ///</summary>
    public class SessionProvider : ISessionProvider
    {
        #region ISessionProvider Members

        public ISession CurrentSession
        {
            get { return NHibernateHelper.GetSession(); }
        }

        #endregion
    }
}
using System.Linq;
using NHibernate.Linq;
using NHibernate.Transform;
using OS.Infrastructure.Domain;

namespace OS.Infrastructure.NHibernate.Linq
{
    public class NHibernateLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider sessionProvider;

        public NHibernateLinqProvider(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        #region ILinqProvider Members

        public IQueryable<T> Query<T>()
        {
            INHibernateQueryable<T> queryable = sessionProvider.CurrentSession.Linq<T>();
            queryable.QueryOptions.RegisterCustomAction(x => x.SetResultTransformer(Transformers.DistinctRootEntity));
            return queryable;
        }

        #endregion
    }
}
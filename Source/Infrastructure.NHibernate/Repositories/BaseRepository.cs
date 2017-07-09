using System;
using System.Linq;
using NHibernate;
using OS.Infrastructure.Domain;

namespace OS.Infrastructure.NHibernate.Repositories
{
    ///<summary>
    ///</summary>
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ILinqProvider linqProvider;
        private readonly ISessionProvider sessionProvider;

        ///<summary>
        ///</summary>
        ///<param name="sessionProvider"></param>
        ///<param name="linqProvider"></param>
        /// <exception cref="ArgumentNullException"><c>sessionProvider</c> is null.</exception>
        protected BaseRepository(ISessionProvider sessionProvider, ILinqProvider linqProvider)
        {
            if (sessionProvider == null)
                throw new ArgumentNullException("sessionProvider");

            this.sessionProvider = sessionProvider;
            this.linqProvider = linqProvider;
        }

        protected ISession Session
        {
            get { return sessionProvider.CurrentSession; }
        }

        #region IRepository<TEntity> Members

        public virtual TEntity Get(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Load(int id)
        {
            return Session.Load<TEntity>(id);
        }

        public virtual void Save(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        #endregion

        /// <summary>
        /// Safe method to call linqProvider.Query{TEntity}()
        /// </summary>
        /// <returns></returns>
        protected IQueryable<TEntity> Query()
        {
            return linqProvider.Query<TEntity>();
        }
    }
}
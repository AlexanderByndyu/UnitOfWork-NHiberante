using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using OS.Infrastructure.Common;

namespace OS.Infrastructure.NHibernate.UnitOfWorkAware
{
    internal static class NHibernateHelper
    {
        private static readonly object lockObject = new object();
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (lockObject)
                    {
                        if (sessionFactory == null)
                            sessionFactory = Configuration.BuildSessionFactory();
                    }
                }

                return sessionFactory;
            }
        }

        private static Configuration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    lock (lockObject)
                    {
                        if (configuration == null)
                            configuration = IoC.Resolve<INHibernateInitializer>().GetConfiguration();
                    }
                }

                return configuration;
            }
        }

        public static ISession GetSession()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
                return SessionFactory.GetCurrentSession();

            throw new InvalidOperationException("Database access logic cannot be used, if session not opened. Implicitly session usage not allowed now. Please open session explicitly through UnitOfWorkFactory.StartLongConversation method");
        }
    }
}
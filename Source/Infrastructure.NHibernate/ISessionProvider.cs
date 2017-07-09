using NHibernate;

namespace OS.Infrastructure.NHibernate
{
    ///<summary>
    ///</summary>
    public interface ISessionProvider
    {
        ///<summary>
        ///</summary>
        ///<returns></returns>
        ISession CurrentSession { get; }
    }
}
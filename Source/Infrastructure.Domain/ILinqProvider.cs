using System.Linq;

namespace OS.Infrastructure.Domain
{
    public interface ILinqProvider
    {
        /// <summary>
        /// Query object for concrete <see cref="IEntity"/>
        /// </summary>
        /// <typeparam name="T"><see cref="IEntity"/></typeparam>
        /// <returns><see cref="IQueryable{T}"/> object for type of T</returns>
        IQueryable<T> Query<T>();
    }
}
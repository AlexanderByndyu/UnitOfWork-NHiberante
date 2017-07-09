using FluentNHibernate.Mapping;
using OS.Infrastructure.Domain;

namespace OS.Infrastructure.NHibernate.Mappings
{
    public class BaseMap<TEntity> : ClassMap<TEntity>
        where TEntity : class, IEntity
    {
        protected BaseMap()
        {
// ReSharper disable DoNotCallOverridableMethodsInConstructor
            Id(x => x.Id);
// ReSharper restore DoNotCallOverridableMethodsInConstructor

            DynamicInsert();
            DynamicUpdate();
        }
    }
}
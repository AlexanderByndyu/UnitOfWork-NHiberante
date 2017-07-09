namespace OS.Infrastructure.Domain
{
    ///<summary>
    /// Интерфейс репозитория
    ///</summary>
    ///<typeparam name="TEntity">Тип сущности доменной модели</typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        ///<summary>
        /// Получить сущность по идентификатору. В ряде случаев использование Load более предпочтительно.
        ///</summary>
        ///<param name="id"></param>
        ///<returns>Сущность с указанным Id, если существует. Иначе - null.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Получить сущность по идентификатору. Активно использует lazy-loading
        /// Создается объект-прокси, который удобно использовать, если необходимо только выставить reference у объекта,
        /// так как это не влечет за собой select-запрос к базе.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Сущность с указанным Id, если существует. Иначе - бросает исключение.</returns>
        TEntity Load(int id);

        ///<summary>
        /// Сохранить сущность
        ///</summary>
        ///<param name="entity"></param>
        void Save(TEntity entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
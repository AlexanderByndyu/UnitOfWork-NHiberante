namespace OS.Infrastructure.Domain
{
    ///<summary>
    /// ��������� �����������
    ///</summary>
    ///<typeparam name="TEntity">��� �������� �������� ������</typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        ///<summary>
        /// �������� �������� �� ��������������. � ���� ������� ������������� Load ����� ���������������.
        ///</summary>
        ///<param name="id"></param>
        ///<returns>�������� � ��������� Id, ���� ����������. ����� - null.</returns>
        TEntity Get(int id);

        /// <summary>
        /// �������� �������� �� ��������������. ������� ���������� lazy-loading
        /// ��������� ������-������, ������� ������ ������������, ���� ���������� ������ ��������� reference � �������,
        /// ��� ��� ��� �� ������ �� ����� select-������ � ����.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>�������� � ��������� Id, ���� ����������. ����� - ������� ����������.</returns>
        TEntity Load(int id);

        ///<summary>
        /// ��������� ��������
        ///</summary>
        ///<param name="entity"></param>
        void Save(TEntity entity);

        /// <summary>
        /// ������� ��������
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
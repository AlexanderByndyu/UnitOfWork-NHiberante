using System;

namespace OS.Infrastructure.Domain.UnitOfWork
{
    ///<summary>
    /// ������� ������
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {
        ///<summary>
        /// ��������� ��������� � ����
        ///</summary>
        void Commit();
    }
}
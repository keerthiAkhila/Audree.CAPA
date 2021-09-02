using System;

namespace Audree.CAPA.Core.Contracts.IUnitOfWork
{
   public  interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}

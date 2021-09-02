using Audree.CAPA.Core.Contracts.IUnitOfWork;
using Audree.CAPA.Infrastructure.Data;
using System;

namespace Audree.CAPA.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CAPAContext _databaseContext;
        private bool _disposed = false;

        public UnitOfWork(CAPAContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            _databaseContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _databaseContext != null)
            {
                _databaseContext.Dispose();
            }
            _disposed = true;
        }
    }
}

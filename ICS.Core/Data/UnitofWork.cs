using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Core.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbContext _context;

        private bool _disposed;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _context.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }
    }
}

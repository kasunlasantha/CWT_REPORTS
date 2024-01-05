using CashieringReports.Core.DomainServices;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly DBContextCore context;
        private bool _disposed = false;

        public UnitOfWork(DBContextCore ctx)
        {
            context = ctx;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public async Task SaveChanges()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && context != null)
            {
                context.Dispose();
            }

            _disposed = true;
        }
    }
}

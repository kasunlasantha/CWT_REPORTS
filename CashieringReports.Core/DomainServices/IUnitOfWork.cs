using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
namespace CashieringReports.Core.DomainServices
{
    public interface IUnitOfWork: IDisposable
    {
        IDbContextTransaction BeginTransaction();

        Task SaveChanges();
    }
}

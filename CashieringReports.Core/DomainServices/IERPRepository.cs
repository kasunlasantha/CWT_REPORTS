using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface IERPRepository: IDisposable
    {
        Task<IEnumerable<ERPRECEIPT>> GetERPReceipt(string Receiptno);

    }
}

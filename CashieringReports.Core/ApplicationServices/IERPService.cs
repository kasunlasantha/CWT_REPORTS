using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices
{
    public interface IERPService
    {
        Task<IEnumerable<ERPRECEIPT>> GetERPReceipt(string Receiptno, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress);
    }
}

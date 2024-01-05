using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices
{
    public interface ISLTService
    {
        Task<IEnumerable<SLTRECEIPT>> GetSLTReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress);
        Task<IEnumerable<SLTRECEIPT>> GetMobitelReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress);
        Task<IEnumerable<SLTRECEIPT>> GetPrePaidReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress);
    }
}

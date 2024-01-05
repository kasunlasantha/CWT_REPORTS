using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface ISLTRepository
    {
        Task<IEnumerable<SLTRECEIPT>> GetSLTReceipt(string Receiptno, string date);
        Task<IEnumerable<SLTRECEIPT>> GetMobitelReceipt(string Receiptno, string date);
        Task<IEnumerable<SLTRECEIPT>> GetPrePaidReceipt(string Receiptno, string date);
    }
}

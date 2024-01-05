using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface ICRMRepository
    {
        Task<IEnumerable<RPTCRMRECEIPT>> GetCRMReceipt(string reciptno);
    }
}

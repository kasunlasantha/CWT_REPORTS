using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices
{
    public interface ICRMService
    {
        Task<IEnumerable<RPTCRMRECEIPT>> GetCRMReceipt(string reciptno, string serviceID, string Centercode,string ISSUED_REPRINT, string ipAddress);
    }
}

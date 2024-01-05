using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface IGlobalRepository
    {
        void InsertOperationsLogsAsync(string userid, string CentreCode, string Division, string Operation,string Description);
        void CreateRequestResponseLogs(string IPAddress, string Description, string CentreCode, object Req,object Res);
        Task<string> InsertReportApproveData(REPORT_APPROVAL apprData);
        Task<IEnumerable<APPROVAL_SELECT>> CheckReportStatus(string in_RPT_CFG_ID, string in_RPT_CENTER);
    }
}

using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices
{
    public interface IReportdataService: IDisposable
    {
        Task<IEnumerable<RPTpurposeofuse>> getPurposeofuseReportData(string DATEFROM_PARA, string DATETO_PARA, string CENTRE_PARA, string PURPOSEOFUSE_PARA, string TRANSACTIONTYPE_PARA);
        Task<string> ReportFirstApproval(string CENTER, string CFG_ID, string GENERATED_DATE, string SERVICE_ID, string STATUS, string DESCRIPTION);
        Task<IEnumerable<REPORT_APPROVAL>> AllFirstApprovalReports(string in_RPT_CENTER);
        Task<string> DiscardReport(int RPTID);
    }
}

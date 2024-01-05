using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices
{
    public interface IMISCService : IDisposable
    {
        Task<IEnumerable<RPTMISCPAYMENTSUMMARY>> getMiscSummaryReportData(string PaymentDate, string Counter, string Cashier, string Center);

        Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getAllCounterReportdata(string PaymentDate, string Center);

        Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getVATdetailReportData(string PaymentDate, string Center);
        Task<IEnumerable<RPTMISCVATSUMMARY>> getVATSummaryReportData(string PaymentDate, string Center);
        Task<IEnumerable<RPTMISCVATSUMMARY>> getCounterSummaryReportData(string PaymentDate, string Center);
        Task<IEnumerable<RPTMISCCANCELLED>> getCancelledReportData(string PaymentDateFrom, string PaymentDateTo, string Center);
        Task<IEnumerable<RPTMISCPAYMENT>> getMiscPaymentReportData(string PaymentDate, string Counter, string pay_mode, string Center);
        Task<IEnumerable<RPTMISCACCWISEPAYMENT>> getMiscAccWicePaymentReportData(string PaymentDate, string Counter, string ACUpper, string ACLower, string Center);
        Task<IEnumerable<RPTMISCTransSummary>> getTransSummaryReportData(string PaymentDateFrom, string PaymentDateTo, string Center);
        Task<IEnumerable<RPTMISCTransDetailed>> getTransDetailedReportData(string PaymentDateFrom, string PaymentDateTo, string Center);
        Task<IEnumerable<RPTMISCPaymentCategory>> getPaymentCategoryReportData(string PaymentDate, int PaymentType, string Center);
        Task<IEnumerable<RPTMISCPAYFORRECIPT>> GetMISCReceipt(string SERIALNO, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress);
    }
}

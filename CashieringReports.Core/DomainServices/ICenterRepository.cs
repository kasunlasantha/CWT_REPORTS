using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface ICenterRepository : IDisposable
    {
        Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCenterSummaryReportData(string PaymentDate, int billtype, string center);
        Task<IEnumerable<RPTCENTERDETAIL>> getCenterDetailReportData(string PaymentDate, string Center, int billtype);
        Task<IEnumerable<RPTCenterCheqShedule>> getCenterScheduleReportData(string PaymentDate, int billtype, string Center);
        Task<IEnumerable<RPTCancelledBillData>> getReportCancelledBillData(string PaymentDateFrom, string PaymentDateTo, int billtype, string Center);
        Task<IEnumerable<RPTBankDepositEntryDT>> getReportBankDepositEntryDetails(string PaymentDateFrom, string PaymentDateTo, string Center);

        Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCenterCombinedSummary(string Payment_Date, string center_name);
        Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCenterCombinedCancelSummary(string Payment_Date, string center_name);

        Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCashierCombinedSummary(string Payment_Date, string center_name, string counter, string cashier);
        Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCashierCombinedCancelSummary(string Payment_Date, string center_name, string counter, string cashier);

        Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCounterSummaryReportData(string PaymentDate, int billtype, string center, string Counter, string Cashier);
        Task<IEnumerable<RPTCOUNTERDETAIL>> getCounterDetailedReportData(string PaymentDate, string center_code, string P_Cashier_Id, string P_Counter, int P_BILLTYPE, string P_Mode);

        Task<string> doBeginingoftheday(string admin, string Center);
        Task<string> doEndoftheday(string admin, string Center);
        Task<IEnumerable<GETEODRET>> getdoEndofthedayData(string Center);
        Task<IEnumerable<CASHIER>> getInvoUsers(string Center);
        Task<IEnumerable<CASHIER>> getCashierUsers(string Center);
        Task<int> logoutInvoUser(int code);
        Task<int> logoutCashiUser(int code);
        Task<CWT_COUNTER> getCounters(string Center);
        Task<IEnumerable<CWT_MISCCASHIERINFO>> getCWT_MISCCASHIERINFO(string Center);
        Task<int> FinalizeCounter(string U_NAME, string U_COUNTER, int Cashi_ID);
        Task<IEnumerable<CWT_CA_SERVICEID>> getServiceIDs(string Center);


    }
}

using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.DomainServices
{
    public interface IInvoiceRepository: IDisposable
    {
        Task<IEnumerable<RPTCENTERSTOCKLVL>> getCenterStockLvlReportData(string center);
        Task<IEnumerable<RPTSALESDATA>> GetReportSalesData(string DateFrom, string DateTo, string center, int reportType);
        Task<IEnumerable<RPTLastGRNdetails>> GetLastGRNReportData(string center, int maxGrn);
        Task<IEnumerable<RPTStockAdjustment>> GetStockAdjustmentReportData(string center, string fromdate, string todate);
        Task<List<TransactionType>> GetTransactionType();

        Task<List<erp_purposeofuse>> GetPurposeOfUse();
        Task<List<GRNDetail>> GenerateLastGRNReport(string BCCODE);
    }
}

using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class InvoiceService : IInvoiceService
    {
        readonly IInvoiceRepository _InvoiceRepository;
        readonly IUnitOfWork _uow;

        public InvoiceService(IInvoiceRepository InvoiceRepository, IUnitOfWork uow)
        {
            _InvoiceRepository = InvoiceRepository;
            _uow = uow;


        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<RPTCENTERSTOCKLVL>> getCenterStockLvlReportData(string center)
        {
            return await _InvoiceRepository.getCenterStockLvlReportData(center);
        }

        public async Task<IEnumerable<RPTLastGRNdetails>> GetLastGRNReportData(string center, int maxGrn)
        {
            return await _InvoiceRepository.GetLastGRNReportData( center, maxGrn);
        }

        public async Task<IEnumerable<RPTSALESDATA>> GetReportSalesData(string DateFrom, string DateTo, string center, int reportType)
        {
            return await _InvoiceRepository.GetReportSalesData(DateFrom, DateTo, center, reportType);
        }

        public async Task<IEnumerable<RPTStockAdjustment>> GetStockAdjustmentReportData(string center, string fromdate, string todate)
        {
            return await _InvoiceRepository.GetStockAdjustmentReportData(center, fromdate, todate);
        }

        public async Task<List<TransactionType>> GetTransactionType()
        {
            return await _InvoiceRepository.GetTransactionType();
        }

        public async Task<List<erp_purposeofuse>> GetPurposeOfUse()
        {
            return await _InvoiceRepository.GetPurposeOfUse();
        }

        public async Task<List<GRNDetail>> GenerateLastGRNReport(string BCCODE)
        {
            return await _InvoiceRepository.GenerateLastGRNReport(BCCODE);
        }
    }
}

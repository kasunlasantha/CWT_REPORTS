using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class MISCService : IMISCService
    {
        readonly IMISCRepository _miscRepository;
        readonly IUnitOfWork _uow;
        public readonly IGlobalRepository _globalunit;
        public MISCService(IMISCRepository miscRepository, IUnitOfWork uow, IGlobalRepository globalUnitOfWork)
        {
            _miscRepository = miscRepository;
            _uow = uow;
            _globalunit = globalUnitOfWork;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public async Task<IEnumerable<RPTMISCPAYMENTSUMMARY>> getMiscSummaryReportData(string PaymentDate, string Counter, string Cashier, string Center)
        {
                return await _miscRepository.getMiscSummaryReportData( PaymentDate,  Counter, Cashier, Center);
        }

        public async Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getAllCounterReportdata(string PaymentDate, string Center)
        {
            return await _miscRepository.getAllCounterReportdata(PaymentDate, Center);
        }

        public async Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getVATdetailReportData(string PaymentDate, string Center)
        {
            return await _miscRepository.getVATdetailReportData(PaymentDate, Center);
        }

        public async Task<IEnumerable<RPTMISCVATSUMMARY>> getVATSummaryReportData(string PaymentDate, string Center)
        {
            return await _miscRepository.getVATSummaryReportData(PaymentDate, Center);
        }

        public async Task<IEnumerable<RPTMISCVATSUMMARY>> getCounterSummaryReportData(string PaymentDate, string Center)
        {
            return await _miscRepository.getCounterSummaryReportData(PaymentDate, Center);
        }

        public async Task<IEnumerable<RPTMISCCANCELLED>> getCancelledReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
        {
            return await _miscRepository.getCancelledReportData(PaymentDateFrom, PaymentDateTo, Center);
        }

        public async Task<IEnumerable<RPTMISCPAYMENT>> getMiscPaymentReportData(string PaymentDate, string Counter, string pay_mode, string Center)
        {
            return await _miscRepository.getMiscPaymentReportData(PaymentDate, Counter, pay_mode, Center);
        }

        public async Task<IEnumerable<RPTMISCACCWISEPAYMENT>> getMiscAccWicePaymentReportData(string PaymentDate, string Counter, string ACUpper, string ACLower, string Center)
        {
            return await _miscRepository.getMiscAccWicePaymentReportData(PaymentDate, Counter, ACUpper, ACLower, Center);
        }

        public async Task<IEnumerable<RPTMISCTransSummary>> getTransSummaryReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
        {
            return await _miscRepository.getTransSummaryReportData(PaymentDateFrom, PaymentDateTo, Center);
        }

        public async Task<IEnumerable<RPTMISCTransDetailed>> getTransDetailedReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
        {
            return await _miscRepository.getTransDetailedReportData(PaymentDateFrom, PaymentDateTo, Center);
        }

        public async Task<IEnumerable<RPTMISCPaymentCategory>> getPaymentCategoryReportData(string PaymentDate, int PaymentType, string Center)
        {
            return await _miscRepository.getPaymentCategoryReportData(PaymentDate, PaymentType, Center);
        }

        public async Task<IEnumerable<RPTMISCPAYFORRECIPT>> GetMISCReceipt(string SERIALNO, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {

                    var ret = await _miscRepository.GetMISCReceipt(SERIALNO);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + SERIALNO + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "MISCReceipt",
                            ISSUED_REPRINT, strDec);
                    }
                    await _uow.SaveChanges();
                    await transaction.CommitAsync();
                    return ret;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

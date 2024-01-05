using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class CenterService : ICenterService
    {

        readonly ICenterRepository _centerRepository;
        readonly IUnitOfWork _uow;
        public readonly IGlobalRepository _globalunit;
        public CenterService(ICenterRepository centerRepository, IUnitOfWork uow, IGlobalRepository globalUnitOfWork)
        {
            _centerRepository = centerRepository;
            _uow = uow;
            _globalunit = globalUnitOfWork;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        public async Task<IEnumerable<RPTCENTERDETAIL>> getCenterDetailReportData(string PaymentDate, string Center, int billtype, string serviceID, string rpt_Cfg_ID)
        {
           // return await _centerRepository.getCenterDetailReportData(PaymentDate, Center, billtype);

            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {
                    var ret = await _centerRepository.getCenterDetailReportData(PaymentDate, Center, billtype);
                    if (ret.Any())
                    {

                        var exist = await _globalunit.CheckReportStatus(rpt_Cfg_ID, Center);
                        if(!exist.Any())
                        {
                            REPORT_APPROVAL rEPORT_APPROVAL = new REPORT_APPROVAL
                            {
                                RPT_CFG_ID = rpt_Cfg_ID,
                                RPT_CENTER = Center,
                                RPT_GENERATED_SERVICE_ID = serviceID,
                                RPT_GENERATED_DATE = DateTime.Now,
                                RPT_PARAMETERS = Center + "," + "" + "," + "" + "," + billtype + "," + "" + "," + PaymentDate +","+ "" +","+ ""//Center, Counter, Cashier, billtype, paymode, PaymentDate, PaymentDateFrom, PaymentDateTo
                                //RPT_PARAMETERS = Center + "," + serviceID + "," + billtype + "," + PaymentDate
                            };

                            // Insert Report Approve Data
                            await _globalunit.InsertReportApproveData(rEPORT_APPROVAL);

                            await _uow.SaveChanges();
                            await transaction.CommitAsync();

                        }

                    }

                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }

        public async Task<IEnumerable<RPTCenterCheqShedule>> getCenterScheduleReportData(string PaymentDate, int billtype, string Center, string serviceID, string rpt_Cfg_ID)
        {
            //return await _centerRepository.getCenterScheduleReportData(PaymentDate, billtype, Center);

            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {
                    var ret = await _centerRepository.getCenterScheduleReportData(PaymentDate, billtype, Center);
                    if (ret.Any())
                    {

                        var exist = await _globalunit.CheckReportStatus(rpt_Cfg_ID, Center);
                        if (!exist.Any())
                        {
                            REPORT_APPROVAL rEPORT_APPROVAL = new REPORT_APPROVAL
                            {
                                RPT_CFG_ID = rpt_Cfg_ID,
                                RPT_CENTER = Center,
                                RPT_GENERATED_SERVICE_ID = serviceID,
                                RPT_GENERATED_DATE = DateTime.Now,
                                //RPT_PARAMETERS = Center + "," + "" + "," + "" + "," + billtype + "," + "" + "," + PaymentDate +","+ "" +","+ ""//Center, Counter, Cashier, billtype, paymode, PaymentDate, PaymentDateFrom, PaymentDateTo
                                RPT_PARAMETERS = Center + "," + serviceID + "," + billtype + "," + PaymentDate
                            };

                            // Insert Report Approve Data
                            await _globalunit.InsertReportApproveData(rEPORT_APPROVAL);

                            await _uow.SaveChanges();
                            await transaction.CommitAsync();

                        }

                    }

                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCenterSummaryReportData(string PaymentDate, int billtype, string center, string serviceID, string rpt_Cfg_ID)
        {
            return await _centerRepository.getCenterSummaryReportData( PaymentDate,  billtype, center);
        }

        public async Task<IEnumerable<RPTCancelledBillData>> getReportCancelledBillData(string PaymentDateFrom, string PaymentDateTo, int billtype, string Center, string serviceID, string rpt_Cfg_ID)
        {
            return await _centerRepository.getReportCancelledBillData(PaymentDateFrom, PaymentDateTo, billtype, Center);
        }
        public async Task<IEnumerable<RPTBankDepositEntryDT>> getReportBankDepositEntryDetails(string PaymentDateFrom, string PaymentDateTo, string Center, string serviceID, string rpt_Cfg_ID)
        {
            return await _centerRepository.getReportBankDepositEntryDetails(PaymentDateFrom, PaymentDateTo, Center);
        }

        public async Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCounterSummaryReportData(string PaymentDate, int billtype, string center, string Counter, string Cashier, string rpt_Cfg_ID)
        {
            return await _centerRepository.getCounterSummaryReportData(PaymentDate, billtype, center, Counter, Cashier);
        }

        public async Task<IEnumerable<RPTCOUNTERDETAIL>> getCounterDetailedReportData(string PaymentDate, string center_code, string P_Cashier_Id, string P_Counter, int P_BILLTYPE, string P_Mode, string rpt_Cfg_ID)
        {
            return await _centerRepository.getCounterDetailedReportData(PaymentDate, center_code, P_Cashier_Id, P_Counter, P_BILLTYPE, P_Mode);
        }




        public async Task<string> doBeginingoftheday(string admin, string Center)
        {
            return await _centerRepository.doBeginingoftheday(admin,Center);
        }

        public async Task<string> doEndoftheday(string admin, string Center)
        {
            return await _centerRepository.doEndoftheday(admin, Center);
        }

        public async Task<IEnumerable<GETEODRET>> getdoEndofthedayData(string Center)
        {
            return await _centerRepository.getdoEndofthedayData(Center);
        }

        public async Task<IEnumerable<CASHIER>> getInvoUsers(string Center)
        {
            return await _centerRepository.getInvoUsers(Center);
        }

        public async Task<IEnumerable<CASHIER>> getCashierUsers(string Center)
        {
            return await _centerRepository.getCashierUsers(Center);
        }

        public async Task<int> logoutInvoUser(int code)
        {
            return await _centerRepository.logoutInvoUser(code);
        }

        public async Task<int> logoutCashiUser(int code)
        {
            return await _centerRepository.logoutCashiUser(code);
        }

        public async Task<CWT_COUNTER> getCounters(string Center)
        {
            return await _centerRepository.getCounters(Center);
        }

        public async Task<IEnumerable<CWT_MISCCASHIERINFO>> getCWT_MISCCASHIERINFO(string Center)
        {
            return await _centerRepository.getCWT_MISCCASHIERINFO(Center);
        }

        public async Task<int> FinalizeCounter(string U_NAME, string U_COUNTER, int Cashi_ID)
        {
            return await _centerRepository.FinalizeCounter(U_NAME, U_COUNTER, Cashi_ID);
        }

        public async Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCenterCombinedSummary(string Payment_Date, string center_name, string serviceID, string rpt_Cfg_ID)
        {
            return await _centerRepository.GenerateCenterCombinedSummary(Payment_Date, center_name);
        }

        public async Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCenterCombinedCancelSummary(string Payment_Date, string center_name, string serviceID, string rpt_Cfg_ID)
        {
            return await _centerRepository.GenerateCenterCombinedCancelSummary(Payment_Date, center_name);
        }

        public async Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCashierCombinedSummary(string Payment_Date, string center_name, string counter, string cashier, string rpt_Cfg_ID)
        {
            return await _centerRepository.GenerateCashierCombinedSummary(Payment_Date, center_name, counter, cashier);
        }

        public async Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCashierCombinedCancelSummary(string Payment_Date, string center_name, string counter, string cashier, string rpt_Cfg_ID)
        {
            return await _centerRepository.GenerateCashierCombinedCancelSummary(Payment_Date, center_name, counter, cashier);
        }

        public async Task<IEnumerable<CWT_CA_SERVICEID>> getServiceIDs(string Center)
        {
            return await _centerRepository.getServiceIDs(Center);
        }
    }
}

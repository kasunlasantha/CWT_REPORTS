using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Infrastructure.Repositories
{
    public class CenterRepository: ICenterRepository
    {
        readonly DBContextCore _ctx;
        public CenterRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        //Center reports summary
        public async Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCenterSummaryReportData(string PaymentDate, int billtype, string center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = billtype;
                param[2].Value = center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_GETCENTERSUMARYRPT(:Payment_Date,:P_BILLTYPE,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCenterPaymentCounterSumrys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Center report Detailed
        public async Task<IEnumerable<RPTCENTERDETAIL>> getCenterDetailReportData(string PaymentDate, string Center, int billtype)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("PaymentDate", OracleDbType.Varchar2),
                    new OracleParameter("center_code", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Center;
                param[2].Value = billtype;

                //using (_ctx)
                //{
                    var sql = "BEGIN CWT_CASHIAD_RPTCENTERDETAIL(:PaymentDate,:center_code,:P_BILLTYPE,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCENTERDETAILs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                //}

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //Center report ScheduleReport
        public async Task<IEnumerable<RPTCenterCheqShedule>> getCenterScheduleReportData(string PaymentDate, int billtype, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = billtype;
                param[2].Value = Center;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_RPTGETCHEQSCHEDULE(:Payment_Date,:P_BILLTYPE,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCenterCheqShedules.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Cancelled bill data report
        public async Task<IEnumerable<RPTCancelledBillData>> getReportCancelledBillData(string PaymentDateFrom, string PaymentDateTo, int billtype, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_DateFrom", OracleDbType.Varchar2),
                    new OracleParameter("Payment_DateTo", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDateFrom;
                param[1].Value = PaymentDateTo;
                param[2].Value = billtype;
                param[3].Value = Center;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_RPTGETCANCELLEDBILL(:Payment_DateFrom,:Payment_DateTo,:P_BILLTYPE,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCancelledBillDatas.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        //BankDepositEntryDetails report
        public async Task<IEnumerable<RPTBankDepositEntryDT>> getReportBankDepositEntryDetails(string PaymentDateFrom, string PaymentDateTo, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_DateFrom", OracleDbType.Varchar2),
                    new OracleParameter("Payment_DateTo", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDateFrom;
                param[1].Value = PaymentDateTo;
                param[2].Value = Center;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_RPTDEPSITENTRYDTAIL(:Payment_DateFrom,:Payment_DateTo,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTBankDepositEntryDTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        ////CenterCombinedSummary report
        //public async Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCenterCombinedSummary(string Payment_Date, string center_name)
        //{
        //    //call SP
        //    try
        //    {
        //        OracleParameter[] param = {
        //            new OracleParameter("Payment_Date", OracleDbType.Varchar2),
        //            new OracleParameter("center_name", OracleDbType.Varchar2),

        //            new OracleParameter("Recordset_CC", OracleDbType.RefCursor, ParameterDirection.Output),
        //            new OracleParameter("Recordset_CA", OracleDbType.RefCursor, ParameterDirection.Output),
        //            new OracleParameter("Recordset_MO", OracleDbType.RefCursor, ParameterDirection.Output),
        //            new OracleParameter("Recordset_BD", OracleDbType.RefCursor, ParameterDirection.Output),
        //            new OracleParameter("Recordset_CH", OracleDbType.RefCursor, ParameterDirection.Output),
        //            new OracleParameter("Recordset_DT", OracleDbType.RefCursor, ParameterDirection.Output)

        //        };

        //        param[0].Value = Payment_Date;
        //        param[1].Value = center_name;



        //        using (_ctx)
        //        {
        //            var sql = "BEGIN CWT_CAD_INITCNTRCOLECTNSMRYRPT(:Payment_Date,:center_name,:Recordset_CC,:Recordset_CA,:Recordset_MO,:Recordset_BD,:Recordset_CH,:Recordset_DT); END;";
        //            //var reportdataset = await _ctx.Set<RPTCenterCombinedSummary>().FromSqlRaw(sql, param).ToListAsync();
        //            var reportdataset = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
        //            var asd = param[2].Value;
        //            List<RPTCenterCombinedSummary> retList = new List<RPTCenterCombinedSummary>() { };

        //            RPTCenterCombinedSummary retCC = (RPTCenterCombinedSummary)param[2].Value;
        //            RPTCenterCombinedSummary retCA = (RPTCenterCombinedSummary)param[3].Value;
        //            RPTCenterCombinedSummary retMO = (RPTCenterCombinedSummary)param[4].Value;
        //            RPTCenterCombinedSummary retBD = (RPTCenterCombinedSummary)param[5].Value;
        //            RPTCenterCombinedSummary retCH = (RPTCenterCombinedSummary)param[6].Value;
        //            RPTCenterCombinedSummary retDT = (RPTCenterCombinedSummary)param[7].Value;

        //            retList.Add(retCC);
        //            retList.Add(retCA);
        //            retList.Add(retMO);
        //            retList.Add(retBD);
        //            retList.Add(retCH);
        //            retList.Add(retDT);



        //            return retList;
        //        }

        //    }
        //    catch (Exception er)
        //    {

        //        throw er;
        //    }
        //}



        //CenterCombinedSummary report
        public async Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCenterCombinedSummary(string Payment_Date, string center_name)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("center_name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Payment_Date;
                param[1].Value = center_name;



                using (_ctx)
                {
                    var sql = "BEGIN CWT_CAD_INITCNTRCOLECTNSMRY_1(:Payment_Date,:center_name,:Recordset); END;";
                    //var reportdataset = await _ctx.Set<RPTCenterCombinedSummary>().FromSqlRaw(sql, param).ToListAsync();
                    var reportdataset = await _ctx.RPTCenterCombinedSummarys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //CenterCombinedCancelSummary report
        public async Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCenterCombinedCancelSummary(string Payment_Date, string center_name)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("center_name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Payment_Date;
                param[1].Value = center_name;



                using (_ctx)
                {
                    var sql = "BEGIN CWT_CAD_INITCNTRCOLECTNSMRY_C(:Payment_Date,:center_name,:Recordset); END;";
                    //var reportdataset = await _ctx.Set<RPTCenterCombinedSummary>().FromSqlRaw(sql, param).ToListAsync();
                    var reportdataset = await _ctx.RPTCenterCombinedCancelSummarys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //CashhierCombinedSummary report
        public async Task<IEnumerable<RPTCenterCombinedSummary>> GenerateCashierCombinedSummary(string Payment_Date, string center_name, string counter, string cashier)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("center_name", OracleDbType.Varchar2),
                    new OracleParameter("counter_in", OracleDbType.Varchar2),
                    new OracleParameter("cashier_in", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Payment_Date;
                param[1].Value = center_name;
                param[2].Value = counter;
                param[3].Value = cashier;



                using (_ctx)
                {
                    var sql = "BEGIN CWT_CAD_INITCASHICOLLETSMRY(:Payment_Date,:center_name,:counter_in,:cashier_in,:Recordset); END;";
                    //var reportdataset = await _ctx.Set<RPTCenterCombinedSummary>().FromSqlRaw(sql, param).ToListAsync();
                    var reportdataset = await _ctx.RPTCenterCombinedSummarys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        //CashhierCombinedCancelSummary report
        public async Task<IEnumerable<RPTCenterCombinedCancelSummary>> GenerateCashierCombinedCancelSummary(string Payment_Date, string center_name, string counter, string cashier)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("center_name", OracleDbType.Varchar2),
                    new OracleParameter("counter_in", OracleDbType.Varchar2),
                    new OracleParameter("cashier_in", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Payment_Date;
                param[1].Value = center_name;
                param[2].Value = counter;
                param[3].Value = cashier;



                using (_ctx)
                {
                    var sql = "BEGIN CWT_CAD_INITCASHICOLLETSMRY_C(:Payment_Date,:center_name,:counter_in,:cashier_in,:Recordset); END;";
                    //var reportdataset = await _ctx.Set<RPTCenterCombinedSummary>().FromSqlRaw(sql, param).ToListAsync();
                    var reportdataset = await _ctx.RPTCenterCombinedCancelSummarys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        // Counter reports
        //Counter Summary report
        public async Task<IEnumerable<RPTCenterPaymentCounterSumry>> getCounterSummaryReportData(string PaymentDate, int billtype, string center, string Counter, string Cashier)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("P_Cashier_Id", OracleDbType.Varchar2),
                    new OracleParameter("P_Counter", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Cashier;
                param[2].Value = Counter;
                param[3].Value = billtype;
                param[4].Value = center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_RPTPAYMTCOUNTERSMRY(:Payment_Date,:P_Cashier_Id,:P_Counter,:P_BILLTYPE,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCenterPaymentCounterSumrys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        // Counter Detailed report
        public async Task<IEnumerable<RPTCOUNTERDETAIL>> getCounterDetailedReportData(string PaymentDate, string center_code, string P_Cashier_Id, string P_Counter, int P_BILLTYPE, string P_Mode)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("center_code", OracleDbType.Varchar2),
                    new OracleParameter("P_Cashier_Id", OracleDbType.Varchar2),
                    new OracleParameter("P_Counter", OracleDbType.Varchar2),
                    new OracleParameter("P_BILLTYPE", OracleDbType.Int32),
                    new OracleParameter("P_Mode", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = center_code;
                param[2].Value = P_Cashier_Id;
                param[3].Value = P_Counter;
                param[4].Value = P_BILLTYPE;
                param[5].Value = P_Mode;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_TESTCOUNTERDETAILED(:Payment_Date,:center_code,:P_Cashier_Id,:P_Counter,:P_BILLTYPE,:P_Mode,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTCOUNTERDETAILs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }







//Admin functions

        public async Task<string> doBeginingoftheday(string admin, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),
                    new OracleParameter("adminName", OracleDbType.Varchar2),

                    new OracleParameter("statu", OracleDbType.Int32, ParameterDirection.Output)

                };

                param[0].Value = Center;
                param[1].Value = admin;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIADMIN_BOD(:in_center_code,:adminName,:statu); END;";

                    var dataset = await _ctx.Database.ExecuteSqlRawAsync(sql, param);

                    return param[2].Value.ToString();
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<string> doEndoftheday(string admin, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),
                    new OracleParameter("adminName", OracleDbType.Varchar2),

                    new OracleParameter("statu", OracleDbType.Int32, ParameterDirection.Output)

                };

                param[0].Value = Center;
                param[1].Value = admin;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIADMIN_EOD(:in_center_code,:adminName,:statu); END;";

                    var dataset = await _ctx.Database.ExecuteSqlRawAsync(sql, param);

                    return param[2].Value.ToString();
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        public async Task<IEnumerable<GETEODRET>> getdoEndofthedayData(string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Center;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIADMIN_GETEOD(:in_center_code,:Recordset); END;";
                    var dataset = await _ctx.GETEODRETs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return dataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<CASHIER>> getInvoUsers(string Center)
        {
            //call SP
            try
            {
                using (_ctx)
                {
                    var dataset = await _ctx.CASHIERs
                        .FromSqlRaw("Select * from CASHIER where CASHIER.STATUS =1 AND CASHIER.BC_CODE = {0} ", Center).AsNoTracking().ToListAsync();

                    return dataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<CASHIER>> getCashierUsers(string Center)
        {
            //call SP
            try
            {
                using (_ctx)
                {
                    var dataset = await _ctx.CASHIERs
                        .FromSqlRaw("Select * from CASHIER where CASHIER.CA_STA_CLOSED =1 AND CASHIER.BC_CODE = {0} ", Center).AsNoTracking().ToListAsync();

                    return dataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }
        


        public async Task<int> logoutInvoUser(int code)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),
                    new OracleParameter("cashi_id", OracleDbType.Int32),

                    new OracleParameter("statu", OracleDbType.Int32, ParameterDirection.Output)

                };
                param[0].Value = "";
                param[1].Value = code;

                param[2].Direction = ParameterDirection.Output;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_UPDTFORCELOGOUTINVO(:in_center_code,:cashi_id,:statu); END;";
                    var payments = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
                    //_ctx.SaveChanges();

                    var retPayment_Id = param[2].Value.ToString();
                    return int.Parse(retPayment_Id);
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        public async Task<int> logoutCashiUser(int code)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),
                    new OracleParameter("cashi_id", OracleDbType.Int32),

                    new OracleParameter("statu", OracleDbType.Int32, ParameterDirection.Output)

                };
                param[0].Value = "";
                param[1].Value = code;

                param[2].Direction = ParameterDirection.Output;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHAD_UPDTFORCELOGOUT(:in_center_code,:cashi_id,:statu); END;";
                    var payments = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
                    //_ctx.SaveChanges();

                    var retPayment_Id = param[2].Value.ToString();
                    return int.Parse(retPayment_Id);
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<CWT_COUNTER> getCounters(string Center)
        {
            //call select
            try
            {
                using (_ctx)
                {
                    var dataset = await _ctx.CWT_COUNTERs
                        .FromSqlRaw("Select * from CWT_COUNTER where CWT_COUNTER.CENTERCODE = {0} ", Center).AsNoTracking().FirstOrDefaultAsync();

                    return dataset;
                }



            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<CWT_MISCCASHIERINFO>> getCWT_MISCCASHIERINFO(string Center)
        {
            //call select
            try
            {

                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };
                param[0].Value = Center;

                param[1].Direction = ParameterDirection.Output;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIADMIN_GETCOUNTERCLOSE(:in_center_code,:Recordset); END;";
                    var recordset = await _ctx.CWT_MISCCASHIERINFOs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return recordset;
                }



            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<int> FinalizeCounter(string U_NAME, string U_COUNTER, int Cashi_ID)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("U_NAME", OracleDbType.Varchar2),
                    new OracleParameter("U_COUNTER", OracleDbType.Varchar2),
                    new OracleParameter("Cashi_ID", OracleDbType.Int32),

                    new OracleParameter("statu", OracleDbType.Int32, ParameterDirection.Output)

                };
                param[0].Value = U_NAME;
                param[1].Value = U_COUNTER;
                param[2].Value = Cashi_ID;

                param[3].Direction = ParameterDirection.Output;


                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_FINALIZECOUNTERCLO(:U_NAME,:U_COUNTER,:Cashi_ID,:statu); END;";
                    var payments = await _ctx.Database.ExecuteSqlRawAsync(sql, param);

                    var status = param[3].Value.ToString();
                    return int.Parse(status);
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<CWT_CA_SERVICEID>> getServiceIDs(string Center)
        {
            try
            {
                using (_ctx)
                {
                    var dataset = await _ctx.CWT_CA_SERVICEIDs.FromSqlRaw("Select CA_SERVICEID from CASHIER where CASHIER.status!=11 AND CASHIER.status!=12 AND CASHIER.BC_CODE = {0} ", Center).ToListAsync();

                    return dataset;

                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


    }
}

using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Infrastructure.Repositories
{
    public class MISCRepository: IMISCRepository
    {

        readonly DBContextCore _ctx;
        public MISCRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }


        //Misc Counter reports (used for both summary and dtailed reports)
        public async Task<IEnumerable<RPTMISCPAYMENTSUMMARY>> getMiscSummaryReportData(string PaymentDate,string Counter, string Cashier, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("in_Counter", OracleDbType.Varchar2),
                    new OracleParameter("in_Cashier", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("MISC_Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Counter;
                param[2].Value = Cashier;
                param[3].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_RPTGETMISCPAYMENTS(:in_Payment_Date,:in_Counter,:in_Cashier,:Center_Name,:MISC_Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCPAYMENTSUMMARYs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Misc all counter report
        public async Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getAllCounterReportdata(string PaymentDate,string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("PaymentDate", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_GETALLCOUNTERRPT(:PaymentDate,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCALLCOUNTERDETAILs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //Misc all counter report
        public async Task<IEnumerable<RPTMISCALLCOUNTERDETAIL>> getVATdetailReportData(string PaymentDate, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("PaymentDate", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_GETCODAVATDETLRPT(:PaymentDate,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCALLCOUNTERDETAILs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Misc all counter report
        public async Task<IEnumerable<RPTMISCVATSUMMARY>> getVATSummaryReportData(string PaymentDate, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("PaymentDate", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_GETCODAVATSMARYRPT(:PaymentDate,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCVATSUMMARYs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //Misc all counter report
        public async Task<IEnumerable<RPTMISCVATSUMMARY>> getCounterSummaryReportData(string PaymentDate, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("PaymentDate", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_MISCCOUNTRSMARYRPT(:PaymentDate,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCVATSUMMARYs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Misc all counter report
        public async Task<IEnumerable<RPTMISCCANCELLED>> getCancelledReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
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
                    var sql = "BEGIN CWT_CASHIAD_GETMISCCANCELLED(:Payment_DateFrom,:Payment_DateTo,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCCANCELLEDs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        // Misc daily payment shedules report
        public async Task<IEnumerable<RPTMISCPAYMENT>> getMiscPaymentReportData(string PaymentDate, string Counter, string pay_mode, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("in_Counter", OracleDbType.Varchar2),
                    new OracleParameter("pay_mode", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Counter;
                param[2].Value = pay_mode;
                param[3].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_RPTGETMISCCASH(:Payment_Date,:in_Counter,:pay_mode,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCPAYMENTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        // Misc daily payment shedules report accwise 
        public async Task<IEnumerable<RPTMISCACCWISEPAYMENT>> getMiscAccWicePaymentReportData(string PaymentDate, string Counter, string ACUpper, string ACLower, string Center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("Counter", OracleDbType.Varchar2),
                    new OracleParameter("ACUpper", OracleDbType.Varchar2),
                    new OracleParameter("ACLower", OracleDbType.Varchar2),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = Counter;
                param[2].Value = ACUpper;
                param[3].Value = ACLower;
                param[4].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CASHIAD_RPTGETMISACCWISE(:Payment_Date,:Counter,:ACUpper,:ACLower,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCACCWISEPAYMENTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }
        
        //Misc transactional reports, devisional
        public async Task<IEnumerable<RPTMISCTransSummary>> getTransSummaryReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
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
                    var sql = "BEGIN CWT_CASHIAD_RPTGETTRANSSUMMARY(:Payment_DateFrom,:Payment_DateTo,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCTransSummarys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Misc transactional reports, devisional
        public async Task<IEnumerable<RPTMISCTransDetailed>> getTransDetailedReportData(string PaymentDateFrom, string PaymentDateTo, string Center)
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
                    var sql = "BEGIN CWT_CASHIAD_RPTGETTRANSDTAILED(:Payment_DateFrom,:Payment_DateTo,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCTransDetaileds.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Misc payment Category Report
        public async Task<IEnumerable<RPTMISCPaymentCategory>> getPaymentCategoryReportData(string PaymentDate, int PaymentType, string Center)
        {
            string SP_Name = "";
            if (PaymentType == 0){
                SP_Name = "CWT_CASHIAD_MISCPAYMENTPAYCAT2";
            }
            else
            {
                SP_Name = "CWT_CASHIAD_MISCPAYMENTPAYCAT1";
            }
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("Payment_Date", OracleDbType.Varchar2),
                    new OracleParameter("P_Cat", OracleDbType.Int32),
                    new OracleParameter("Center_Name", OracleDbType.Varchar2),

                    new OracleParameter("Recordset_forRpt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = PaymentDate;
                param[1].Value = PaymentType;
                param[2].Value = Center;

                using (_ctx)
                {
                    var sql = "BEGIN " + SP_Name + " (:Payment_Date,:P_Cat,:Center_Name,:Recordset_forRpt); END;";
                    var reportdataset = await _ctx.RPTMISCPaymentCategorys.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }





        public async Task<IEnumerable<RPTMISCPAYFORRECIPT>> GetMISCReceipt(string SERIALNO)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Serial_no", OracleDbType.Varchar2),

                    new OracleParameter("MISC_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = SERIALNO;


                    var sql = "BEGIN CWT_CASHI_GETMISCPAYFORRECIPT(:P_Serial_no,:MISC_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.RPTMISCPAYFORRECIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;

            }
            catch (Exception er)
            {

                throw er;
            }
        }



    }
}

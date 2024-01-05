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
    public class SLTRepository: ISLTRepository
    {
        readonly DBContextCore _ctx;
        public SLTRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task<IEnumerable<SLTRECEIPT>> GetSLTReceipt(string Receiptno, string date)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Recept_no", OracleDbType.Varchar2),
                    new OracleParameter("P_Date_Cashier", OracleDbType.Varchar2),
                    new OracleParameter("SLT_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Receiptno;
                param[1].Value = date;


                    var sql = "BEGIN CWT_CASHI_GETPAYMENTDATA(:P_Recept_no,:P_Date_Cashier,:SLT_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.SLTRECEIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;


            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<SLTRECEIPT>> GetMobitelReceipt(string Receiptno, string date)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Recept_no", OracleDbType.Varchar2),
                    new OracleParameter("P_Date_Cashier", OracleDbType.Varchar2),
                    new OracleParameter("SLT_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Receiptno;
                param[1].Value = date;


                    var sql = "BEGIN CWT_CASHI_GETMOBIPAYMENTDATA(:P_Recept_no,:P_Date_Cashier,:SLT_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.SLTRECEIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        public async Task<IEnumerable<SLTRECEIPT>> GetPrePaidReceipt(string Receiptno, string date)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Recept_no", OracleDbType.Varchar2),
                    new OracleParameter("P_Date_Cashier", OracleDbType.Varchar2),
                    new OracleParameter("SLT_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Receiptno;
                param[1].Value = date;


                    var sql = "BEGIN CWT_CASHI_GETPREPAYDATA(:P_Recept_no,:P_Date_Cashier,:SLT_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.SLTRECEIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;

            }
            catch (Exception er)
            {

                throw er;
            }
        }



    }
}

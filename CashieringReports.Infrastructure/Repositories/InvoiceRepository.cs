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
    public class InvoiceRepository : IInvoiceRepository
    {
        readonly DBContextCore _ctx;
        public InvoiceRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }


        //getCenterStockLvlReportData
        public async Task<IEnumerable<RPTCENTERSTOCKLVL>> getCenterStockLvlReportData(string center)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("CenterCode", OracleDbType.Varchar2),

                    new OracleParameter("RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = center;

                using (_ctx)
                {
                    var sql = "BEGIN CashAdmin_RptGetCentreStckLvl(:CenterCode,:RET_Recordset); END;";
                    var reportdataset = await _ctx.RPTCENTERSTOCKLVLs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //GetReportSalesData
        public async Task<IEnumerable<RPTSALESDATA>> GetReportSalesData(string DateFrom, string DateTo, string center, int reportType)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("CenterCode", OracleDbType.Varchar2),
                    new OracleParameter("P_fromDate", OracleDbType.Varchar2),
                    new OracleParameter("P_toDate", OracleDbType.Varchar2),

                    new OracleParameter("RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = center;
                param[1].Value = DateFrom;//01/07/2019 MM/dd/yyyy
                param[2].Value = DateTo;

                var sql = "";

                if (reportType == 0) //equipment wise
                {
                    sql = "BEGIN CashAdmin_RptGetSalesEquipwise(:CenterCode,:P_fromDate,:P_toDate,:RET_Recordset); END;";
                }
                else if (reportType == 1) //supplier wise
                {
                    sql = "BEGIN CashAdmin_RptGetSalesSupplwise(:CenterCode,:P_fromDate,:P_toDate,:RET_Recordset); END;";
                }
                else                //vendor wise
                {
                    sql = "BEGIN CashAdmin_RptGetSalesVendwise(:CenterCode,:P_fromDate,:P_toDate,:RET_Recordset); END;";
                }


                using (_ctx)
                {
                    // var sql = "BEGIN CashAdmin_RptGetCentreStckLvl(:CenterCode,:P_fromDate,:P_toDate,:RET_Recordset); END;";
                    var reportdataset = await _ctx.RPTSALESDATAs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }





        //GetLastGRNReportData
        public async Task<IEnumerable<RPTLastGRNdetails>> GetLastGRNReportData(string center, int maxGrn)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_centerCode", OracleDbType.Varchar2),
                    new OracleParameter("P_maxGrn", OracleDbType.Int16),

                    new OracleParameter("RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = center;
                param[1].Value = maxGrn;

                using (_ctx)
                {
                    var sql = "BEGIN CashiAdmin_GetLastGRNdetails(:P_centerCode,:P_maxGrn,:RET_Recordset); END;";
                    var reportdataset = await _ctx.RPTLastGRNdetailss.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }


        //GetStockAdjustmentReportData
        public async Task<IEnumerable<RPTStockAdjustment>> GetStockAdjustmentReportData(string center, string fromdate, string todate)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_CenterCode", OracleDbType.Varchar2),
                    new OracleParameter("P_fromDate", OracleDbType.Varchar2),
                    new OracleParameter("P_toDate", OracleDbType.Varchar2),

                    new OracleParameter("RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = center;
                param[1].Value = fromdate;
                param[2].Value = todate;

                using (_ctx)
                {
                    var sql = "BEGIN CashiAdmin_StockAdjustment(:P_centerCode,:P_fromDate,:P_toDate,:RET_Recordset); END;";
                    var reportdataset = await _ctx.RPTStockAdjustments.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        //GetPurposeOfUse
        public async Task<List<erp_purposeofuse>> GetPurposeOfUse()
        {
            //call SP
            try
            {
                OracleParameter[] param = {

                    new OracleParameter("cur", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                using (_ctx)
                {
                    var sql = "BEGIN CWT_TA_getPurposeOfUse(:cur); END;";
                    var reportdataset = await _ctx.erp_purposeofuses.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;

            }
        }


        //GetTransactionType
        public async Task<List<TransactionType>> GetTransactionType()
        {
            //call SP
            try
            {
                OracleParameter[] param = {

                    new OracleParameter("cur", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                using (_ctx)
                {
                    var sql = "BEGIN CWT_TA_getTransactionType(:cur); END;";
                    var reportdataset = await _ctx.TransactionTypes.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;

            }
        }

        //GenerateLastGRNReport
        public async Task<List<GRNDetail>> GenerateLastGRNReport(string BCCODE)
        {
            //call SP
            try
            {
                var MaxGRN = getMaxGRN(BCCODE).Result;

                OracleParameter[] param = {
                    new OracleParameter("P_centerCode", OracleDbType.Varchar2),
                    new OracleParameter("P_maxGrn", OracleDbType.Int32),
                    new OracleParameter("RET_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };
                param[0].Value = BCCODE;
                param[1].Value = MaxGRN;


                using (_ctx)
                {
                    var sql = "BEGIN CashiAdmin_GetLastGRNdetails(:P_centerCode,:P_maxGrn,:RET_Recordset); END;";
                    var reportdataset = await _ctx.GRNDetails.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;

            }
        }

        //getMaxGRN
        public async Task<int> getMaxGRN(string BCCODE)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("BCCODE", OracleDbType.Varchar2),
                    new OracleParameter("E_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };
                param[0].Value = BCCODE;
                //using (_ctx)
                //{
                    var sql = "BEGIN CashiAdmin_GetLastGRN(:BCCODE,:E_Recordset); END;";
                    var reportdataset = await _ctx.MAXGRNs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    var ret_Id = reportdataset[0].MSEQ.GetValueOrDefault();
                    return ret_Id;
                //}

            }
            catch (Exception er)
            {

                throw er;

            }
        }




    }
}
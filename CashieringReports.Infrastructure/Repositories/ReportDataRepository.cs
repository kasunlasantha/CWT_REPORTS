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
    public class ReportDataRepository : IReportDataRepository
    {
        readonly DBContextCore _ctx;
        public ReportDataRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<RPTpurposeofuse>> getPurposeofuseReportData(string DATEFROM_PARA, string DATETO_PARA, string CENTRE_PARA, string PURPOSEOFUSE_PARA, string TRANSACTIONTYPE_PARA)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("DATEFROM_PARA", OracleDbType.Varchar2),
                    new OracleParameter("DATETO_PARA", OracleDbType.Varchar2),
                    new OracleParameter("CENTRE_PARA", OracleDbType.Varchar2),
                    new OracleParameter("PURPOSEOFUSE_PARA", OracleDbType.Varchar2),
                    new OracleParameter("TRANSACTIONTYPE_PARA", OracleDbType.Varchar2),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = DATEFROM_PARA;
                param[1].Value = DATETO_PARA;
                param[2].Value = CENTRE_PARA;
                param[3].Value = PURPOSEOFUSE_PARA;
                param[4].Value = TRANSACTIONTYPE_PARA;

                using (_ctx)
                {
                    var sql = "BEGIN CashiAdmin_PurposeOfUseBC_Rpt(:DATEFROM_PARA,:DATETO_PARA,:CENTRE_PARA,:PURPOSEOFUSE_PARA,:TRANSACTIONTYPE_PARA,:Recordset); END;";
                    var reportdataset = await _ctx.RPTpurposeofuses.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }
        


        public async Task<string> ReportFirstApproval(string CENTER, string CFG_ID, string GENERATED_DATE, string SERVICE_ID, string STATUS, string DESCRIPTION)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_CFG_ID", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_GENERATED_DATE", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_FIRST_APPR_SERVICE_ID", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_FIRST_APPR_DATE", OracleDbType.Date),
                    new OracleParameter("in_RPT_FIRST_APPR_STATUS", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_FIRST_APPR_DESCRIPTION", OracleDbType.Varchar2),

                    new OracleParameter("statu", OracleDbType.Int16)

                };

                param[0].Value = CENTER;
                param[1].Value = CFG_ID;
                param[2].Value = GENERATED_DATE;
                param[3].Value = SERVICE_ID;
                param[4].Value = DateTime.Now;
                param[5].Value = STATUS;
                param[6].Value = DESCRIPTION;

                param[7].Direction = ParameterDirection.Output;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CR1_FIRST_APPROVAL(:in_center_code,:in_RPT_CFG_ID,:in_RPT_GENERATED_DATE,:in_RPT_FIRST_APPR_SERVICE_ID,:in_RPT_FIRST_APPR_DATE,:in_RPT_FIRST_APPR_STATUS,:in_RPT_FIRST_APPR_DESCRIPTION,:statu); END;";
                    var reportdataset = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
                    _ctx.SaveChanges();
                    var retReport_Id = param[7].Value.ToString();
                    return retReport_Id;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public async Task<IEnumerable<REPORT_APPROVAL>> AllFirstApprovalReports(string in_RPT_CENTER)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_center_code", OracleDbType.Varchar2),

                    new OracleParameter("E_Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = in_RPT_CENTER;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CR1_GET_FIRST_APPROVALRPTS(:in_center_code,:E_Recordset); END;";
                    var reportdataset = await _ctx.REPORT_APPROVALs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }

        }
        public async Task<string> DiscardReport(int RPTID)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_RPT_ID", OracleDbType.Int16),

                    new OracleParameter("statu", OracleDbType.Int16)

                };

                param[0].Value = RPTID;

                param[1].Direction = ParameterDirection.Output;

                using (_ctx)
                {
                    var sql = "BEGIN CWT_CR1_DISCARD_REPORT(:in_RPT_ID,:statu); END;";
                    var reportdataset = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
                    _ctx.SaveChanges();
                    var retReport_Id = param[1].Value.ToString();
                    return retReport_Id;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public List<RPTCURRENTSTOCKLEVEL> getReportData(string id)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("centerNo", OracleDbType.Varchar2),

                    new OracleParameter("RET_Currentstock", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = id;

                using (_ctx)
                {
                    var sql = "BEGIN CASHINV_GETCURRENTSTOCK(:centerNo,:RET_Currentstock); END;";
                    var reportdataset =  _ctx.RPTCURRENTSTOCKLEVELs.FromSqlRaw(sql, param).AsNoTracking().ToList();

                    return reportdataset;
                }

            }
            catch (Exception er)
            {

                throw er;
            }
        }
    }
}

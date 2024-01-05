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
    public class CRMRepository: ICRMRepository
    {

        readonly DBContextCore _ctx;
        public CRMRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }


        //public List<RPTCRMRECEIPT> GetCRMReceipt(string reciptno)
        //{
        //    try
        //    {
        //        //string sql = "select USERNAME from paybillview_users where USERNAME='008954'";
        //        //string sql = @"select * from paybillview_users where username='008954'";

        //        using (var connection = new OracleConnection(constr))
        //        {
        //            //var cashiers = connection.Query<PAYBILLVIEW_USERS>(sql).FirstOrDefault();
        //            //string var = cashiers.USERNAME.ToString();
        //            //return var;

        //            //OracleParameter param1 = new OracleParameter("@P_Recept_no", OracleDbType.Varchar2);
        //            //OracleParameter param2 = new OracleParameter("@CRM_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output);


        //            //param1.Value = reciptno;


        //            //var sql = "BEGIN CWT_CASHI_GETCRMDATAFORRECEIPT(:param1,:param2); END;";
        //            //var rptInv = _ctx.Database.SqlQuery<RPTINVOICE>(sql, param1, param2).ToList();
        //            //var sqltax = "BEGIN RPT_GetInvoiceDetailTAX(:param1,:param2); END;";
        //            //var rptInvTAX = _ctx.Database.SqlQuery<RPTINVOICETAX>(sqltax, param1, param2).ToList();
        //            //dsInv.Tables.Add(conv.ConvertToDataTable(rptInv));
        //            //dsInv.Tables.Add(conv.ConvertToDataTable(rptInvTAX));


        //            //var affectedRows = connection.Execute(sql,
        //            //    new { Kind = InvoiceKind.WebInvoice, Code = "CWT_CASHI_GETCRMDATAFORRECEIPT" },
        //            //    commandType: CommandType.StoredProcedure);

        //            OracleDynamicParameters p = new OracleDynamicParameters();
        //            p.Add("@P_Recept_no", reciptno);
        //            p.Add("@CRM_Recordset_forReceipt", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);


        //            var procedure = "CWT_CASHI_GETCRMDATAFORRECEIPT";
        //            //var values = new { P_Recept_no = reciptno, CRM_Recordset_forReceipt = OracleDbType.RefCursor, ParameterDirection.Output };
        //            var results = connection.Query<RPTCRMRECEIPT>(procedure, p, commandType: CommandType.StoredProcedure).ToList();

        //            return results;

        //        }
        //        //var cashiers = _ctx.CASHIERs.Select(x => x.CA_NAME).FirstOrDefault();
        //        //return cashiers;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}





        public async Task<IEnumerable<RPTCRMRECEIPT>> GetCRMReceipt(string reciptno)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Recept_no", OracleDbType.Varchar2),

                    new OracleParameter("CRM_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = reciptno;

                    var sql = "BEGIN CWT_CASHI_GETCRMDATAFORRECEIPT(:P_Recept_no,:CRM_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.RPTCRMRECEIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;

            }
            catch (Exception er)
            {

                throw er;
            }
        }







    }
}

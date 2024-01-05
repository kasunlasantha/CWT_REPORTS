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
    public class ERPRepository : IERPRepository
    {
        readonly DBContextCore _ctx;
        public ERPRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }



        public async Task<IEnumerable<ERPRECEIPT>> GetERPReceipt(string Receiptno)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("P_Recept_no", OracleDbType.Varchar2),

                    new OracleParameter("ERP_Recordset_forReceipt", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = Receiptno;

                    var sql = "BEGIN CWT_CASHI_GETERPDATAFORRECEIPT(:P_Recept_no,:ERP_Recordset_forReceipt); END;";
                    var reportdataset = await _ctx.ERPRECEIPTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;

            }
            catch (Exception er)
            {

                throw er;
            }
        }



    }
}

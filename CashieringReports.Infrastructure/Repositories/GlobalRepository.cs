using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Infrastructure.Repositories
{
    public class GlobalRepository : IGlobalRepository
    {
        readonly DBContextCore _ctx;

        public GlobalRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            GC.SuppressFinalize(this);
        }
        public void CreateRequestResponseLogs(string IPAddress, string Description, string CentreCode, object Req, object Res)
        {
            try
            {
                string docPath = AppDomain.CurrentDomain.BaseDirectory;

                string PathToData = Path.GetFullPath(Path.Combine(docPath, "Request and Response Log"));
                if (!Directory.Exists(PathToData))
                {
                    Directory.CreateDirectory(PathToData);
                }

                string path = Path.Combine(PathToData, DateTime.Now.ToString("dd-MM-yy") + ".txt");
                // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
                StreamWriter outputFile = new StreamWriter(path, true);
                outputFile.Close();
                StreamReader sreader = new StreamReader(path);
                string fileContent = sreader.ReadToEnd();
                if (fileContent.Length <= 0)
                {
                    sreader.Close();
                    using (StreamWriter wr = new StreamWriter(path, true))
                    {
                         wr.Write(
                            "---------------------------------------------------------------------------------- \n" +
                            "CWT Request Reponse log Info File.(c)Copyright 2022 EPIC Lanka Technologies \n" +
                            "This File was Generated for Developers Purposes, Please DO NOT DELETE! \n" +
                            "Log Generated On : " + DateTime.Now + "\n" +
                            "---------------------------------------------------------------------------------- \n" +
                            "Date & time - " + DateTime.Now + "\n"
                            + "IP          - " + IPAddress + "\n"
                            + "Description - " + Description + "\n"
                            + "Center code - " + CentreCode + "\n"
                            + "Request     - " + ParseReqReponse(Req) + "\n"
                            + "Response    - " + ParseReqReponse(Res) + "\n"
                            + "------------------------------------------------------------------------------- end \n\n");
                    }
                }
                else
                {
                    sreader.Close();
                    using (StreamWriter wr = new StreamWriter(path, true))
                    {
                        List<ERPPAY_CUTOMERTYPE> w = new List<ERPPAY_CUTOMERTYPE>();
                         wr.Write(
                            "Date & time - " + DateTime.Now + "\n"
                            + "IP          - " + IPAddress + "\n"
                            + "Description - " + Description + "\n"
                            + "Center code - " + CentreCode + "\n"
                            + "Request     - " + ParseReqReponse(Req) + "\n"
                            + "Response    - " + ParseReqReponse(Res) + "\n"
                            + "------------------------------------------------------------------------------- end \n\n");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertOperationsLogsAsync(string userid, string CentreCode, string Division, string Operation, string Description)
        {
            try
            {
                //   | 5 / 28 / 2020 | 2:54:13 PM | c073313 | Payment | Issued | 016EF8993468 |
                //CREATE THE SIGNTEXT STRING
                string SignText;
                string time = DateTime.Now.ToString("HH:mm:ss:tt");
                string date = (DateTime.Now.ToString("d")).ToString();
                SignText = date + "|" + time + "|" + userid + "|" + Division + "|" + Operation + "|" + CentreCode;
                //

                OracleParameter[] parameters =
                {
                    new OracleParameter("EventDateA", OracleDbType.Date), //1
                    new OracleParameter("EventTimeA", OracleDbType.TimeStamp), //2
                    new OracleParameter("LoginNameA", OracleDbType.Varchar2), //3
                    new OracleParameter("DivisionA", OracleDbType.Varchar2), //4
                    new OracleParameter("OperationA", OracleDbType.Varchar2), //5
                    new OracleParameter("DescriptionA", OracleDbType.Varchar2), //6
                    new OracleParameter("SignTextA", OracleDbType.Varchar2), //7
                    new OracleParameter("CentreCodeA", OracleDbType.Varchar2), //9
                };

                parameters[0].Value = DateTime.Now.ToString("d"); //1
                parameters[1].Value = DateTime.Now;
                parameters[2].Value = userid; //3
                parameters[3].Value = Division;
                parameters[4].Value = Operation;
                parameters[5].Value = Description;
                parameters[6].Value = SignText; //7
                parameters[7].Value = CentreCode; //9

                var sql =
                    "BEGIN CWT_INSERTOPERATIONLOG(:EventDateA,:EventTimeA,:LoginNameA,:DivisionA, :OperationA, :DescriptionA, :SignTextA,:CentreCodeA ); END;";
                var payments = _ctx.Database.ExecuteSqlRaw(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //check report status before insert
        public async Task<IEnumerable<APPROVAL_SELECT>> CheckReportStatus(string in_RPT_CFG_ID, string in_RPT_CENTER)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_RPT_CFG_ID", OracleDbType.Varchar2),
                    new OracleParameter("in_RPT_CENTER", OracleDbType.Varchar2),
                    new OracleParameter("Current_date", OracleDbType.Date),

                    new OracleParameter("Recordset", OracleDbType.RefCursor, ParameterDirection.Output)

                };

                param[0].Value = in_RPT_CFG_ID;
                param[1].Value = in_RPT_CENTER;
                param[2].Value = DateTime.Now;

                //using (_ctx)
                //{
                    var sql = "BEGIN CWT_CR1_REPORT_APPROVAL_SELECT(:in_RPT_CFG_ID,:in_RPT_CENTER,:Current_date,:Recordset); END;";
                    var reportdataset = await _ctx.APPROVAL_SELECTs.FromSqlRaw(sql, param).AsNoTracking().ToListAsync();

                    return reportdataset;
                //}

            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //Insert report approve data
        public async Task<string> InsertReportApproveData(REPORT_APPROVAL apprData)
        {
            //call SP
            try
            {
                OracleParameter[] param = {
                    new OracleParameter("in_RPT_CFG_ID", OracleDbType.Varchar2),//0
                    new OracleParameter("in_RPT_CENTER", OracleDbType.Varchar2),//1
                    new OracleParameter("in_RPT_GENERATED_SERVICE_ID", OracleDbType.Varchar2),//2
                    new OracleParameter("in_RPT_GENERATED_DATE", OracleDbType.Date),//3
                    new OracleParameter("in_RPT_PARAMETERS", OracleDbType.Varchar2),//4

                    new OracleParameter("rpt_Id_out", OracleDbType.Int16)//5
                };

                param[0].Value = apprData.RPT_CFG_ID;
                param[1].Value = apprData.RPT_CENTER;
                param[2].Value = apprData.RPT_GENERATED_SERVICE_ID;
                param[3].Value = apprData.RPT_GENERATED_DATE;
                param[4].Value = apprData.RPT_PARAMETERS;

                param[5].Direction = ParameterDirection.Output;

                //using (_ctx)
                //{
                    var sql = "BEGIN CWT_CR1_REPORT_APPROVAL_INSERT(:in_RPT_CFG_ID,:in_RPT_CENTER,:in_RPT_GENERATED_SERVICE_ID,:in_RPT_GENERATED_DATE,:in_RPT_PARAMETERS,:rpt_Id_out); END;";

                    var payments = await _ctx.Database.ExecuteSqlRawAsync(sql, param);
                    _ctx.SaveChanges();
                    var retReport_Id = param[5].Value.ToString();
                    return retReport_Id;

                //}

            }
            catch (Exception er)
            {

                throw er;
            }
        }



        private static string ParseReqReponse(object parameter)
        {
            Type type = parameter.GetType();

            if (type.Name == "String" || type.Name == "Int32")
            {
                return parameter.ToString();
            }

            else if (type.Name.Substring(0, 4) == "List")
            {
                string data = "";
                foreach (var item in (IList)parameter)
                {
                    foreach (var property in item.GetType().GetProperties())
                    {
                        data += property.Name + ":" + property.GetValue(item, null) + " ||";
                    }
                }

                return data;
            }
            else
            {
                PropertyInfo[] props = type.GetProperties();

                string properties = "";

                foreach (PropertyInfo p in props)
                {
                    string name = p.Name;
                    object value = p.GetValue(parameter, null);
                    properties += name + ":" + value + " || ";
                }

                return properties;
            }
        }




    }
}

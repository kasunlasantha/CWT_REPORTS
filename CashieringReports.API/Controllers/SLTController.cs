//using AspNetCore.Reporting;
using CashieringReports.API.DTOs;
using CashieringReports.API.Helpers;
using CashieringReports.Core.ApplicationServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.NETCore;

namespace CashieringReports.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    public class SLTController : Controller
    {
        private readonly ISLTService _sltService;
        private readonly IGlobalService _globalervice;
        public SLTController(ISLTService sltService, IGlobalService globalervice)
        {
            _sltService = sltService;
            _globalervice = globalervice;
        }

        public IActionResult About()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            ViewData["Message"] = "Version: " + version;
            return View("Views/About.cshtml");
        }


        [Route("GetSLTReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetSLTReceipt([FromBody] SLTReqDTO req)
        {
            try
            {

                //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "SLTReceipt");
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Encoding.GetEncoding("windows-1252");
                //LocalReport report = new LocalReport(rdlcFilePath);

                //var returnPayments = await _sltService.GetSLTReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, this.ipAddress());
                ////Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
                ////var cusName = _custService.GetCutomerByID(id);
                //CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                //if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                //if (returnPayments.Count() == 0) { return BadRequest("No Payment found for that receipt number"); }
                //var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                //var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));

                //parameters.Add("Center", req.CENTER);
                //parameters.Add("BillType", req.BILLTYPE);
                //parameters.Add("AmtInWords", amtInWords);
                //parameters.Add("CusName", req.CusName);
                //parameters.Add("CusTele", req.CusTele);
                //parameters.Add("IsOnline", req.IsOnline);

                //report.AddDataSource("SLTds", returnPayments);

                //int ext = (int)(DateTime.Now.Ticks >> 10);

                //var result = report.Execute(GetRenderType("pdf"), ext, parameters);
                ////return result.MainStream;

                //FileContentResult returnFile = File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet, "SLTReceipt" + ".pdf");


                var returnPayments = await _sltService.GetSLTReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER,req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "SLTReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("SLTds", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper()),
                    new ReportParameter("CusName", req.CusName.ToUpper()),
                    new ReportParameter("CusTele", req.CusTele),
                    new ReportParameter("IsOnline", req.IsOnline)
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "SLTReceipt." + "pdf");



                if (returnFile != null)
                {
                    //_logger.LogInfo("Method: getReport(success), Return:" + id);
                    var response = "SLT Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "SLT Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Receipt "+req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                    //return BadRequest("Method: getReport(error)");
                }

            }
            catch (Exception ex)
            {

                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);
                return NotFound(ex.Message);

            }


        }


        [Route("GetSLTCanceledReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetSLTCanceledReceipt([FromBody] SLTReqDTO req)
        {
            try
            {
                //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "SLTCanceledReceipt");
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Encoding.GetEncoding("windows-1252");
                //LocalReport report = new LocalReport(rdlcFilePath);

                //var returnPayments = await _sltService.GetSLTReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, this.ipAddress());
                //if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                ////Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
                ////var cusName = _custService.GetCutomerByID(id);
                //CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                //if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                //var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                //var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));

                //parameters.Add("Center", req.CENTER);
                //parameters.Add("BillType", req.BILLTYPE);
                //parameters.Add("AmtInWords", amtInWords);
                //parameters.Add("CusName", req.CusName);
                //parameters.Add("CusTele", req.CusTele);
                //parameters.Add("IsOnline", req.IsOnline);

                //report.AddDataSource("SLTds", returnPayments);

                //int ext = (int)(DateTime.Now.Ticks >> 10);

                //var result = report.Execute(GetRenderType("pdf"), ext, parameters);
                ////return result.MainStream;

                //FileContentResult returnFile = File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet, "SLTCanceledReceipt" + ".pdf");


                var returnPayments = await _sltService.GetSLTReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, req.ISSUED_REPRINT,this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "SLTCanceledReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("SLTds", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper()),
                    new ReportParameter("CusName", req.CusName.ToUpper()),
                    new ReportParameter("CusTele", req.CusTele),
                    new ReportParameter("IsOnline", req.IsOnline)
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "SLTCanceledReceipt." + "pdf");



                if (returnFile != null)
                {
                    var response = "SLT Cancel Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Cancel Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "SLT Cancel Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Cancel Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);

                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "SLT Cancel Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);
                return NotFound(ex.Message);
            }

        }



        [Route("GetMobitelReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetMobitelReceipt([FromBody] SLTReqDTO req)
        {
            try
            {


                var returnPayments = await _sltService.GetMobitelReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "MobitelReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("SLTds", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper()),
                    //new ReportParameter("CusName", req.CusName.ToUpper()),
                    //new ReportParameter("CusTele", req.CusTele),
                    new ReportParameter("IsOnline", req.IsOnline)
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "MobitelReceipt." + "pdf");

                if (returnFile != null)
                {
                    var response = "Mobitel Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "Mobitel Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                }

            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt "+req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);
                return NotFound(ex.Message);
            }


        }


        [Route("GetMobitelCanceledReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetMobitelCanceledReceipt([FromBody] SLTReqDTO req)
        {
            try
            {


                var returnPayments = await _sltService.GetMobitelReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "MobitelCanceledReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("SLTds", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper()),
                    //new ReportParameter("CusName", req.CusName.ToUpper()),
                    //new ReportParameter("CusTele", req.CusTele),
                    new ReportParameter("IsOnline", req.IsOnline)
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "MobitelCanceledReceipt." + "pdf");

                if (returnFile != null)
                {
                    var response = "Mobitel Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt " + req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "Mobitel Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt " + req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                }

            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Mobitel Receipt " + req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);
                return NotFound(ex.Message);
            }


        }


        [Route("GetPrepaidReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetPrepaidReceipt([FromBody] SLTReqDTO req)
        {
            try
            {

                //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "PripaidReceipt");
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Encoding.GetEncoding("windows-1252");
                //LocalReport report = new LocalReport(rdlcFilePath);

                //var returnPayments = await _sltService.GetPrePaidReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, this.ipAddress());
                ////Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
                ////var cusName = _custService.GetCutomerByID(id);
                //CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                //if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                //var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                //var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));

                //parameters.Add("Center", req.CENTER);
                //parameters.Add("BillType", req.BILLTYPE);
                //parameters.Add("AmtInWords", amtInWords);
                ////parameters.Add("CusName", req.CusName);
                ////parameters.Add("CusTele", req.CusTele);
                //parameters.Add("IsOnline", req.IsOnline);

                //report.AddDataSource("SLTds", returnPayments);

                //int ext = (int)(DateTime.Now.Ticks >> 10);

                //var result = report.Execute(GetRenderType("pdf"), ext, parameters);
                ////return result.MainStream;

                //FileContentResult returnFile = File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet, "PrepaidReceipt" + ".pdf");


                var returnPayments = await _sltService.GetPrePaidReceipt(req.RECEIPTNUMBER, req.DATE, req.ServiceID, req.CENTER, req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().PAYMENTAMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "PrepaidReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("SLTds", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper()),
                    //new ReportParameter("CusName", req.CusName.ToUpper()),
                    //new ReportParameter("CusTele", req.CusTele),
                    new ReportParameter("IsOnline", req.IsOnline)
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "PrepaidReceipt." + "pdf");


                if (returnFile != null)
                {
                    var response = "Prepaid Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Prepaid Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "Prepaid Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Prepaid Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                }

            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "Prepaid Receipt "+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);
                return NotFound(ex);
            }


        }


        // helper methods

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        //private RenderType GetRenderType(string reportType)
        //{
        //    var renderType = RenderType.Pdf;
        //    switch (reportType.ToLower())
        //    {
        //        default:
        //        case "pdf":
        //            renderType = RenderType.Pdf;
        //            break;
        //        case "word":
        //            renderType = RenderType.Word;
        //            break;
        //        case "excel":
        //            renderType = RenderType.Excel;
        //            break;
        //    }

        //    return renderType;
        //}


    }
}

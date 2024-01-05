using Microsoft.Reporting.NETCore;
using CashieringReports.API.DTOs;
using CashieringReports.API.Helpers;
using CashieringReports.Core.ApplicationServices;
using CashieringReports.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CashieringReports.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : Controller
    {

        private readonly IMISCService _miscService;
        private readonly IGlobalService _globalervice;

        public MiscController(IMISCService miscService, IGlobalService globalervice)
        {
            _miscService = miscService;
            _globalervice = globalervice;
        }


        [Route("getMiscSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getMiscSummaryReportData([FromBody] MiscSummaryRptReqDTO reqdt)
        {
            //string[] formats = { "M/dd/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "M/d/yyyy hh:mm:ss tt", "MM/d/yyyy hh:mm:ss tt" };
            ////string[] formats = { "mm/dd/yyyy hh:mm: ss am/pm" };
            //DateTime expectedDate;
            //if (!DateTime.TryParseExact(reqdt.PaymentDate, formats, System.Globalization.CultureInfo.InvariantCulture,
            //                            DateTimeStyles.None, out expectedDate))
            //{
            //    throw new AuthenticationException("Error - Invalid Date format");
            //}
            try
            {
                var reportdata = await _miscService.getMiscSummaryReportData(reqdt.PaymentDate, reqdt.Counter, reqdt.Cashier, reqdt.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscSummaryReportData ", reqdt.Center, reqdt, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getMiscSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscSummaryReportData", reqdt.Center, reqdt, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscSummaryReportData", reqdt.Center, reqdt, ex.Message);

                throw ex;
            }
        }

        [Route("getAllCounterReportdata")]
        [HttpPost]
        public async Task<IActionResult> getAllCounterReportdata([FromBody] MiscPaymentCategoryRptReqDTO reqdt)
        {
            try
            {

                var reportdata = await _miscService.getAllCounterReportdata(reqdt.PaymentDate, reqdt.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getAllCounterReportdata ", reqdt.Center, reqdt, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getAllCounterReportdata no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getAllCounterReportdata", reqdt.Center, reqdt, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getAllCounterReportdata", reqdt.Center, reqdt, ex.Message);

                throw ex;
            }
        }


        [Route("getVATdetailReportData")]
        [HttpPost]
        public async Task<IActionResult> getVATdetailReportData([FromBody] MiscPaymentCategoryRptReqDTO reqdt)
        {
            try
            {
                var reportdata = await _miscService.getVATdetailReportData(reqdt.PaymentDate, reqdt.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATdetailReportData ", reqdt.Center, reqdt, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getVATSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATdetailReportData", reqdt.Center, reqdt, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATdetailReportData", reqdt.Center, reqdt, ex.Message);
                throw ex;
            }

        }

        [Route("getVATSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getVATSummaryReportData([FromBody] MiscPaymentCategoryRptReqDTO reqdt)
        {
            try
            {
                var reportdata = await _miscService.getVATSummaryReportData(reqdt.PaymentDate, reqdt.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATSummaryReportData ", reqdt.Center, reqdt, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getVATSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATSummaryReportData", reqdt.Center, reqdt, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getVATSummaryReportData", reqdt.Center, reqdt, ex.Message);

                throw ex;
            }

        }

        [Route("getCounterSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getCounterSummaryReportData([FromBody] MiscPaymentCategoryRptReqDTO reqdt)
        {
            try
            {
                var reportdata = await _miscService.getCounterSummaryReportData(reqdt.PaymentDate, reqdt.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData ", reqdt.Center, reqdt, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCounterSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData", reqdt.Center, reqdt, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData", reqdt.Center, reqdt, ex.Message);

                throw ex;
            }

        }

        [Route("getCancelledReportData")]
        [HttpPost]
        public async Task<IActionResult> getCancelledReportData([FromBody] MiscCancelledReportReqDTO req)
        {

            try
            {

                var reportdata = await _miscService.getCancelledReportData(req.PaymentDateFrom, req.PaymentDateTo, req.center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCancelledReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCancelledReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCancelledReportData", req.center, req, response);
                    return Ok(reportdata);
                }

            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCancelledReportData", req.center, req, ex.Message);

                throw ex;
            }

        }

        [Route("getMiscPaymentReportData")]
        [HttpPost]
        public async Task<IActionResult> getMiscPaymentReportData([FromBody] MiscPaymentRptReqDTO req)
        {
            try
            {
                var reportdata = await _miscService.getMiscPaymentReportData(req.PaymentDate, req.Counter, req.paymode, req.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscPaymentReportData ", req.Center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getMiscPaymentReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscPaymentReportData", req.Center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscPaymentReportData", req.Center, req, ex.Message);

                throw ex;
            }

        }

        [Route("getMiscAccWicePaymentReportData")]
        [HttpPost]
        public async Task<IActionResult> getMiscAccWicePaymentReportData([FromBody] MiscAccWicePaymentRptReqDTO req)
        {
            try
            {

                var reportdata = await _miscService.getMiscAccWicePaymentReportData(req.PaymentDate, req.Counter, req.ACUpper, req.ACLower, req.Center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscAccWicePaymentReportData ", req.Center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getMiscAccWicePaymentReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscAccWicePaymentReportData", req.Center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getMiscAccWicePaymentReportData", req.Center, req, ex.Message);

                throw ex;
            }

        }

        [Route("getTransSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getTransSummaryReportData([FromBody] MiscCancelledReportReqDTO req)
        {
            try
            {
                var reportdata = await _miscService.getTransSummaryReportData(req.PaymentDateFrom, req.PaymentDateTo, req.center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransSummaryReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getTransSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransSummaryReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransSummaryReportData", req.center, req, ex.Message);

                throw ex;
            }


}

        [Route("getTransDetailedReportData")]
        [HttpPost]
        public async Task<IActionResult> getTransDetailedReportData([FromBody] MiscCancelledReportReqDTO req)
        {
            try { 

                var reportdata = await _miscService.getTransDetailedReportData(req.PaymentDateFrom, req.PaymentDateTo, req.center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransDetailedReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getTransDetailedReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransDetailedReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransDetailedReportData", req.center, req, ex.Message);

                throw ex;
            }

}

        [Route("getPaymentCategoryReportData")]
        [HttpPost]
        public async Task<IActionResult> getPaymentCategoryReportData([FromBody] MiscPaymentCategoryRptReqDTO req)
        {
            try{

                var reportdata = await _miscService.getPaymentCategoryReportData(req.PaymentDate, req.Paycat, req.Center);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPaymentCategoryReportData ", req.Center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getPaymentCategoryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPaymentCategoryReportData", req.Center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPaymentCategoryReportData", req.Center, req, ex.Message);

                throw ex;
            }
        }


        [Route("GetMISCReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetMISCReceipt([FromBody] CRMReceiptDTO req)
        {
            try
            {

                //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "MiscReceipt");
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Encoding.GetEncoding("windows-1252");
                //LocalReport report = new LocalReport(rdlcFilePath);

                //var returnPayments = await _miscService.GetMISCReceipt(req.RECEIPTNUMBER, req.ServiceID, req.CENTER, this.ipAddress());
                ////Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
                ////var cusName = _custService.GetCutomerByID(id);
                //CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                //var retAmt = returnPayments.First().AMOUNT.ToString();
                //var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));

                //parameters.Add("Center", req.CENTER);
                //parameters.Add("BillType", req.BILLTYPE);
                //parameters.Add("AmtInWords", amtInWords);

                //report.AddDataSource("MiscDS", returnPayments);

                //int ext = (int)(DateTime.Now.Ticks >> 10);

                //var result = report.Execute(GetRenderType("pdf"), ext, parameters);
                ////return result.MainStream;

                //FileContentResult returnFile = File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet, "MiscReceipt" + ".pdf");

                var returnPayments = await _miscService.GetMISCReceipt(req.RECEIPTNUMBER, req.ServiceID, req.CENTER, req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().AMOUNT.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "MiscReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("MiscDS", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper())
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "MiscReceipt." + "pdf");




                if (returnFile != null)
                {
                    var response = "MISC Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "MISC Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "MISC Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "MISC Receipt"+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "MISC Receipt"+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex.Message);
                return NotFound(ex.Message);
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

        public IActionResult Index()
        {
            return View();
        }
    }
}

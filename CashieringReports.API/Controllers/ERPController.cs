using Microsoft.Reporting.NETCore;
using CashieringReports.API.DTOs;
using CashieringReports.API.Helpers;
using CashieringReports.Core.ApplicationServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CashieringReports.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class ERPController : Controller
    {
        private readonly IERPService _erpService;
        private readonly IGlobalService _globalervice;
        public ERPController(IERPService erpService, IGlobalService globalervice)
        {
            _erpService = erpService;
            _globalervice = globalervice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("GetERPReceipt")]
        [HttpPost]
        public async Task<IActionResult> GetERPReceiptAsync([FromBody] CRMReceiptDTO req)
        {
            try
            {

                //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "ERPReceipt");
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Encoding.GetEncoding("windows-1252");
                //LocalReport report = new LocalReport(rdlcFilePath);

                //var returnPayments = await _erpService.GetERPReceipt(req.RECEIPTNUMBER, req.ServiceID, req.CENTER, this.ipAddress());
                ////Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
                ////var cusName = _custService.GetCutomerByID(id);

                //CurrencytoWords _CurrencytoWords = new CurrencytoWords();
                //var retAmt = returnPayments.First().AMOUNT.ToString();
                //var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));

                //parameters.Add("Center", req.CENTER);
                //parameters.Add("BillType", req.BILLTYPE);
                //parameters.Add("AmtInWords", amtInWords);

                //report.AddDataSource("ERPDataSet", returnPayments);

                //int ext = (int)(DateTime.Now.Ticks >> 10);

                //var result = report.Execute(GetRenderType("pdf"), ext, parameters);
                ////return result.MainStream;

                //FileContentResult returnFile = File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet, "ERPReceipt" + ".pdf");


                var returnPayments = await _erpService.GetERPReceipt(req.RECEIPTNUMBER, req.ServiceID, req.CENTER, req.ISSUED_REPRINT, this.ipAddress());

                CurrencytoWords _CurrencytoWords = new CurrencytoWords();

                if (returnPayments == null) { return BadRequest("No Payment found for that receipt number"); }
                var retAmt = returnPayments.First().TOTALPAID.ToString();
                var amtInWords = _CurrencytoWords.CurrencyConvertToWords(Convert.ToDecimal(retAmt));


                string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CashieringReports.API.dll", string.Empty);
                string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "ERPReceipt");
                using var fs = new FileStream(rdlcFilePath, FileMode.Open, FileAccess.Read);
                Stream reportDefinition = fs; // your RDLC from file or resource
                IEnumerable dataSource = returnPayments; // your datasource for the report

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("ERPDataSet", dataSource));
                report.SetParameters(new[] {
                    new ReportParameter("Center", req.BC_DESC.ToUpper()),
                    new ReportParameter("BillType", req.BILLTYPE),
                    new ReportParameter("AmtInWords", amtInWords.ToUpper())
                });
                byte[] pdf = report.Render("PDF");
                FileContentResult returnFile = File(pdf, "application/pdf", "ERPReceipt." + "pdf");



                if (returnFile != null)
                {
                    var response = "ERP Receipt print success";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ERP Receipt "+ req.ISSUED_REPRINT, req.CENTER, req, response);

                    return returnFile;
                }
                else
                {
                    var response = "ERP Receipt print error";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ERP Receipt"+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, response);
                    return NotFound(response);
                }
            }
            catch(Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ERP Receipt"+ req.ISSUED_REPRINT, req.CENTER, req.RECEIPTNUMBER, ex);

                throw ex;
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

    }
}

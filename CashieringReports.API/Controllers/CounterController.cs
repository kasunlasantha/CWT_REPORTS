using CashieringReports.API.DTOs;
using CashieringReports.Core.ApplicationServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : Controller
    {

        private readonly ICenterService _centerService;
        private readonly IGlobalService _globalervice;

        public CounterController(ICenterService centerService, IGlobalService globalervice)
        {
            _centerService = centerService;
            _globalervice = globalervice;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("getCounterSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getCounterSummaryReportData([FromBody] CenterSummaryRptReqDTO req)
        {


            try
            {

                var reportdata = await _centerService.getCounterSummaryReportData(req.PaymentDate, req.billtype, req.center, req.Counter, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCounterSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterSummaryReportData", req.center, req, ex);

                throw ex;
            }

        }


        [Route("getCounterDetailedReportData")]
        [HttpPost]
        public async Task<IActionResult> getCounterDetailedReportData([FromBody] CenterSummaryRptReqDTO req)
        {


            try
            {
                if (req.paymode == "ALL") { req.paymode = "%"; }

                var reportdata = await _centerService.getCounterDetailedReportData(req.PaymentDate, req.center, req.Cashier, req.Counter, req.billtype, req.paymode, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterDetailedReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCounterDetailedReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterDetailedReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCounterDetailedReportData", req.center, req, ex);

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

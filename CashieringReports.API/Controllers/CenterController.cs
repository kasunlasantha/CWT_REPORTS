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
    public class CenterController : Controller
    {

        private readonly ICenterService _centerService;
        private readonly IGlobalService _globalervice;

        public CenterController(ICenterService centerService, IGlobalService globalervice)
        {
            _centerService = centerService;
            _globalervice = globalervice;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("getCenterSummaryReportData")]
        [HttpPost]
        public async Task<IActionResult> getCenterSummaryReportData([FromBody] CenterSummaryRptReqDTO req)
        {

          try
            {

                var reportdata = await _centerService.getCenterSummaryReportData(req.PaymentDate, req.billtype, req.center, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterSummaryReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCenterSummaryReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterSummaryReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterSummaryReportData", req.center, req, ex);

                throw ex;
            }

        }

        [Route("getCenterDetailReportData")]
        [HttpPost]
        public async Task<IActionResult> getCenterDetailReportData([FromBody] CenterSummaryRptReqDTO req)
        {


            try
            {

                var reportdata = await _centerService.getCenterDetailReportData(req.PaymentDate, req.center, req.billtype, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterDetailReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCenterDetailReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterDetailReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterDetailReportData", req.center, req, ex);

                throw ex;
            }

        }

        [Route("getCenterScheduleReportData")]
        [HttpPost]
        public async Task<IActionResult> getCenterScheduleReportData([FromBody] CenterSummaryRptReqDTO req)
        {


            try
            {

                var reportdata = await _centerService.getCenterScheduleReportData(req.PaymentDate, req.billtype, req.center, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterScheduleReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getCenterScheduleReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterScheduleReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterScheduleReportData", req.center, req, ex);

                throw ex;
            }

        }


        [Route("getReportCancelledBillData")]
        [HttpPost]
        public async Task<IActionResult> getReportCancelledBillData([FromBody] MiscCancelledReportReqDTO req)
        {


            try
            {
                var reportdata = await _centerService.getReportCancelledBillData(req.PaymentDateFrom, req.PaymentDateTo, req.billtype, req.center, req.Cashier, req.rpt_Cfg_ID);


                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportCancelledBillData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getReportCancelledBillData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportCancelledBillData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportCancelledBillData", req.center, req, ex);

                throw ex;
            }

        }

        [Route("getReportBankDepositEntryDetails")]
        [HttpPost]
        public async Task<IActionResult> getReportBankDepositEntryDetails([FromBody] MiscCancelledReportReqDTO req)
        {


            try
            {
                var reportdata = await _centerService.getReportBankDepositEntryDetails(req.PaymentDateFrom, req.PaymentDateTo, req.center, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportBankDepositEntryDetails ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getReportBankDepositEntryDetails no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportBankDepositEntryDetails", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getReportBankDepositEntryDetails", req.center, req, ex);

                throw ex;
            }

        }


        [Route("GenerateCenterCombinedSummary")]
        [HttpPost]
        public async Task<IActionResult> GenerateCenterCombinedSummary([FromBody] MiscCancelledReportReqDTO req)
        {


            try
            {
                var reportdata = await _centerService.GenerateCenterCombinedSummary(req.PaymentDateFrom, req.center, req.Cashier, req.rpt_Cfg_ID);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedSummary ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GenerateCenterCombinedSummary no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedSummary", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedSummary", req.center, req, ex);

                throw ex;
            }

        }

        [Route("GenerateCenterCombinedCancelSummary")]
        [HttpPost]
        public async Task<IActionResult> GenerateCenterCombinedCancelSummary([FromBody] MiscCancelledReportReqDTO req)
        {

        try
            {
                var reportdata = await _centerService.GenerateCenterCombinedCancelSummary(req.PaymentDateFrom, req.center, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedCancelSummary", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GenerateCenterCombinedCancelSummary no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedCancelSummary", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCenterCombinedCancelSummary", req.center, req, ex);

                throw ex;
            }

        }

        [Route("GenerateCashierCombinedSummary")]
        [HttpPost]
        public async Task<IActionResult> GenerateCashierCombinedSummary([FromBody] CenterSummaryRptReqDTO req)
        {

            try
            {
                var reportdata = await _centerService.GenerateCashierCombinedSummary(req.PaymentDate, req.center, req.Counter, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedSummary", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GenerateCashierCombinedSummary no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedSummary", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedSummary", req.center, req, ex);

                throw ex;
            }

        }

        [Route("GenerateCashierCombinedCancelSummary")]
        [HttpPost]
        public async Task<IActionResult> GenerateCashierCombinedCancelSummary([FromBody] CenterSummaryRptReqDTO req)
        {


            try
            {
                var reportdata = await _centerService.GenerateCashierCombinedCancelSummary(req.PaymentDate, req.center, req.Counter, req.Cashier, req.rpt_Cfg_ID);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedCancelSummary", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GenerateCashierCombinedCancelSummary no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedCancelSummary", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateCashierCombinedCancelSummary", req.center, req, ex);

                throw ex;
            }

        }

        [Route("getServiceIDs")]
        [HttpPost]
        public async Task<IActionResult> getServiceIDs([FromBody] string center)
        {


            try
            {
                var reportdata = await _centerService.getServiceIDs(center);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getServiceIDs", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getServiceIDs no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getServiceIDs", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getServiceIDs", center, center, ex);

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

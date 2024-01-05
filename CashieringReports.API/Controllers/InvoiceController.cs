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
    public class InvoiceController : Controller
    {

        private readonly IInvoiceService _InvoiceService;
        private readonly IGlobalService _globalervice;

        public InvoiceController(IInvoiceService InvoiceService, IGlobalService globalervice)
        {
            _InvoiceService = InvoiceService;
            _globalervice = globalervice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("getCenterStockLvlReportData")]
        [HttpPost]
        public async Task<IActionResult> getCenterStockLvlReportData([FromBody] string center)
        {

            try
            {

                var reportdata = await _InvoiceService.getCenterStockLvlReportData(center);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getCenterStockLvlReportData ", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getTransDetailedReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransDetailedReportData", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getTransDetailedReportData", center, center, ex);

                throw ex;
            }

        }

        [Route("GetReportSalesData")]
        [HttpPost]
        public async Task<IActionResult> GetReportSalesData([FromBody] ReportSalesDataDTO req)
        {


            try
            {

                var reportdata = await _InvoiceService.GetReportSalesData(req.dateFrom, req.dateTo, req.center, req.reportType);

                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetReportSalesData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GetReportSalesData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetReportSalesData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetReportSalesData", req.center, req, ex);

                throw ex;
            }

        }


        [Route("GetLastGRNReportData")]
        [HttpPost]
        public async Task<IActionResult> GetLastGRNReportData([FromBody] ReportSalesDataDTO req)
        {



            try
            {

                var reportdata = await _InvoiceService.GetLastGRNReportData(req.center, req.reportType);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetLastGRNReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GetLastGRNReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetLastGRNReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetLastGRNReportData", req.center, req, ex);

                throw ex;
            }

        }


        [Route("GetStockAdjustmentReportData")]
        [HttpPost]
        public async Task<IActionResult> GetStockAdjustmentReportData([FromBody] ReportSalesDataDTO req)
        {


            try
            {

                var reportdata = await _InvoiceService.GetStockAdjustmentReportData(req.center, req.dateFrom, req.dateTo);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetStockAdjustmentReportData ", req.center, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GetStockAdjustmentReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetStockAdjustmentReportData", req.center, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetStockAdjustmentReportData", req.center, req, ex);

                throw ex;
            }

        }


        [Route("GetPurposeOfUse")]
        [HttpPost]
        public async Task<IActionResult> GetPurposeOfUse([FromBody] string center)
        {

            try
            {

                var reportdata = await _InvoiceService.GetPurposeOfUse();
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetPurposeOfUse ", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GetPurposeOfUse no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetPurposeOfUse", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetPurposeOfUse", center, center, ex);

                throw ex;
            }

        }



        [Route("GetTransactionType")]
        [HttpPost]
        public async Task<IActionResult> GetTransactionType([FromBody] string center)
        {

            try
            {

                var reportdata = await _InvoiceService.GetTransactionType();
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetTransactionType ", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GetTransactionType no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetTransactionType", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GetTransactionType", center, center, ex);

                throw ex;
            }

        }


        [Route("GenerateLastGRNReport")]
        [HttpPost]
        public async Task<IActionResult> GenerateLastGRNReport([FromBody] string center)
        {

            try
            {

                var reportdata = await _InvoiceService.GenerateLastGRNReport(center);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateLastGRNReport ", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "GenerateLastGRNReport no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateLastGRNReport", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "GenerateLastGRNReport", center, center, ex);

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

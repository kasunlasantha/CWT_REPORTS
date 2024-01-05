using CashieringReports.API.DTOs;
using CashieringReports.Core.ApplicationServices;
using CashieringReports.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/Reportdata")]
    [ApiController]
    public class ReportdataController : Controller
    {
        private readonly IReportdataService _reportdataService;
        private readonly IGlobalService _globalervice;

        public ReportdataController(IReportdataService reportdataService, IGlobalService globalervice)
        {
            _reportdataService = reportdataService;
            _globalervice = globalervice;
        }

        //[Route("getReportData")]
        //[HttpPost]
        //public List<RPTCURRENTSTOCKLEVEL> getReportData([FromBody] string id)
        //{

        //  //  List<RPTCURRENTSTOCKLEVEL> reportdata =  _reportdataService.getReportData(id);

        //    //return reportdata;

        //}

        [Route("getPurposeofuseReportData")]
        [HttpPost]
        public async Task<IActionResult> getPurposeofuseReportData([FromBody] PurposeofuseDTO req)
        {
            try
            {
                if(req.PURPOSEOFUSE_PARA == "All")
                {
                    req.PURPOSEOFUSE_PARA = "%";
                }
                if (req.TRANSACTIONTYPE_PARA == "All")
                {
                    req.TRANSACTIONTYPE_PARA = "%";
                }

                var reportdata = await _reportdataService.getPurposeofuseReportData(req.DATEFROM_PARA, req.DATETO_PARA, req.CENTRE_PARA, req.PURPOSEOFUSE_PARA, req.TRANSACTIONTYPE_PARA);
                if (reportdata.Count() != 0)
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPurposeofuseReportData ", req.CENTRE_PARA, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "getPurposeofuseReportData no data";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPurposeofuseReportData", req.CENTRE_PARA, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "getPurposeofuseReportData", req.CENTRE_PARA, req, ex.Message);

                throw ex;
            }
        }

        [Route("ReportFirstApproval")]
        [HttpPost]
        public async Task<IActionResult> ReportFirstApproval([FromBody] ReportApprovalDTO req)
        {
            try
            {
                var reportdata = await _reportdataService.ReportFirstApproval(req.CENTER, req.CFG_ID, req.GENERATED_DATE, req.SERVICE_ID, req.STATUS, req.DESCRIPTION);
                if (reportdata == "1")
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ReportFirstApproval", req.CENTER, req, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "ReportFirstApproval Failed";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ReportFirstApproval", req.CENTER, req, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "ReportFirstApproval", req.CENTER, req, ex.Message);

                throw ex;
            }
        }
        

        [Route("AllFirstApprovalReports")]
        [HttpGet]
        public async Task<IActionResult> AllFirstApprovalReports(string center)
        {
            try
            {
                var reportdata = await _reportdataService.AllFirstApprovalReports(center);
                if (reportdata.Any())
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "AllFirstApprovalReports", center, center, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "AllFirstApprovalReports Failed";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "AllFirstApprovalReports", center, center, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "AllFirstApprovalReports", center, center, ex.Message);

                throw ex;
            }
        }

        [Route("DiscardReport")]
        [HttpPut]
        public async Task<IActionResult> DiscardReport(int rPT_ID, string centerCode)
        {
            string reportID = rPT_ID.ToString();
            try
            {
                var reportdata = await _reportdataService.DiscardReport(rPT_ID);
                if (reportdata == "1")
                {
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "DiscardReport", centerCode, reportID, reportdata);

                    return Ok(reportdata);
                }
                else
                {
                    var response = "DiscardReport Failed";
                    _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "DiscardReport", centerCode, reportID, response);
                    return Ok(reportdata);
                }
            }
            catch (Exception ex)
            {
                _globalervice.CreateRequestResponseLogsAsync(ipAddress(), "DiscardReport", centerCode, reportID, ex.Message);

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

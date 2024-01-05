using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class ReportdataService : IReportdataService
    {

        readonly IReportDataRepository _reportDataRepository;
        readonly IUnitOfWork _uow;

        public ReportdataService(IReportDataRepository reportDataRepository, IUnitOfWork uow)
        {
            _reportDataRepository = reportDataRepository;
            _uow = uow;


        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<RPTpurposeofuse>> getPurposeofuseReportData(string DATEFROM_PARA, string DATETO_PARA, string CENTRE_PARA, string PURPOSEOFUSE_PARA, string TRANSACTIONTYPE_PARA)
        {
            return _reportDataRepository.getPurposeofuseReportData( DATEFROM_PARA,  DATETO_PARA,  CENTRE_PARA,  PURPOSEOFUSE_PARA,  TRANSACTIONTYPE_PARA);
        }
        public Task<string> ReportFirstApproval(string CENTER, string CFG_ID, string GENERATED_DATE, string SERVICE_ID, string STATUS, string DESCRIPTION)
        {
            return _reportDataRepository.ReportFirstApproval(CENTER, CFG_ID, GENERATED_DATE, SERVICE_ID, STATUS, DESCRIPTION);
        }

        public Task<IEnumerable<REPORT_APPROVAL>> AllFirstApprovalReports(string in_RPT_CENTER)
        {
            return _reportDataRepository.AllFirstApprovalReports(in_RPT_CENTER);
        }
        public Task<string> DiscardReport(int RPTID)
        {
            return _reportDataRepository.DiscardReport(RPTID);
        }

        public List<RPTCURRENTSTOCKLEVEL> getReportData(string id)
        {
            return  _reportDataRepository.getReportData(id);
        }
    }
}

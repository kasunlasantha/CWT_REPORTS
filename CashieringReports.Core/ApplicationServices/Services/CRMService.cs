using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class CRMService : ICRMService
    {

        readonly ICRMRepository _crmRepository;
        readonly IUnitOfWork _uow;
        public readonly IGlobalRepository _globalunit;
        public CRMService(ICRMRepository crmRepository, IUnitOfWork uow, IGlobalRepository globalUnitOfWork)
        {
            _crmRepository = crmRepository;
            _uow = uow;
            _globalunit = globalUnitOfWork;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        public async Task<IEnumerable<RPTCRMRECEIPT>> GetCRMReceipt(string reciptno, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {
                    var ret = await _crmRepository.GetCRMReceipt(reciptno);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + reciptno + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "CRMReceipt",
                            ISSUED_REPRINT, strDec);
                    }
                    await _uow.SaveChanges();
                    await transaction.CommitAsync();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

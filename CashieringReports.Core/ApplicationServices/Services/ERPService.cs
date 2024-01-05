using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class ERPService : IERPService
    {
        readonly IERPRepository _erpRepository;
        readonly IUnitOfWork _uow;
        public readonly IGlobalRepository _globalunit;
        public ERPService(IERPRepository erpRepository, IUnitOfWork uow, IGlobalRepository globalUnitOfWork)
        {
            _erpRepository = erpRepository;
            _uow = uow;
            _globalunit = globalUnitOfWork;
        }

        public async Task<IEnumerable<ERPRECEIPT>> GetERPReceipt(string Receiptno, string serviceID, string Centercode, string ISSUED_REPRINT , string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {
                    var ret = await _erpRepository.GetERPReceipt(Receiptno);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + Receiptno + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "ERPReceipt",
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

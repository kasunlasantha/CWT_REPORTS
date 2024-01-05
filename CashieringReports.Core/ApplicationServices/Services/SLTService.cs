using CashieringReports.Core.DomainServices;
using CashieringReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class SLTService : ISLTService
    {
        readonly ISLTRepository _sltRepository;
        readonly IUnitOfWork _uow;
        public readonly IGlobalRepository _globalunit;

        public SLTService(ISLTRepository sltRepository, IUnitOfWork uow, IGlobalRepository globalUnitOfWork)
        {
            _sltRepository = sltRepository;
            _uow = uow;
            _globalunit = globalUnitOfWork;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<SLTRECEIPT>> GetMobitelReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {

                    var ret = await _sltRepository.GetMobitelReceipt(Receiptno, date);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + Receiptno + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "MobitelReceipt",
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

        public async Task<IEnumerable<SLTRECEIPT>> GetPrePaidReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {

                    var ret = await _sltRepository.GetPrePaidReceipt(Receiptno, date);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + Receiptno + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "PrePaidReceipt",
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

        public async Task<IEnumerable<SLTRECEIPT>> GetSLTReceipt(string Receiptno, string date, string serviceID, string Centercode, string ISSUED_REPRINT, string ipAddress)
        {
            using (_uow)
            {
                var transaction = _uow.BeginTransaction();
                try
                {
                    var ret = await _sltRepository.GetSLTReceipt(Receiptno, date);
                    if (ret != null)
                    {
                        // OPERATION LOG
                        string strDec = "Printed receipt No: " + Receiptno + " from IP: " + ipAddress;
                        _globalunit.InsertOperationsLogsAsync(serviceID, Centercode, "SLTReceipt",
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

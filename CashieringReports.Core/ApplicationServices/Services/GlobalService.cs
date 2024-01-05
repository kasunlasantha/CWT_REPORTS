using CashieringReports.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.ApplicationServices.Services
{
    public class GlobalService : IGlobalService
    {
        public readonly IGlobalRepository _globalunit;
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public GlobalService(IGlobalRepository globalunit)
        {
            _globalunit = globalunit;


        }
        public void CreateRequestResponseLogsAsync(string IPAddress, string Description, string CentreCode, object Req, object Res)
        {
            try
            {
                _globalunit.CreateRequestResponseLogs(IPAddress, Description, CentreCode, Req, Res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.ApplicationServices
{
    public interface IGlobalService
    {
        //void InsertOperationsLogsAsync(string userid, string CentreCode, string Division, string Operation, string Description);
        void CreateRequestResponseLogsAsync(string IPAddress, string Description, string CentreCode, object Req, object Res);
    }
}

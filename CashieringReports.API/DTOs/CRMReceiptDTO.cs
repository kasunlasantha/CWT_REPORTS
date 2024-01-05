using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class CRMReceiptDTO
    {
        public string RECEIPTNUMBER { get; set; }
        public string CENTER { get; set; }
        public string BILLTYPE { get; set; }
        public string ServiceID { get; set; }
        public string BC_DESC { get; set; }
        public string ISSUED_REPRINT { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class MiscSummaryRptReqDTO
    {
        public string PaymentDate { get; set; }
        public string Counter { get; set; }
        public string Cashier { get; set; }
        public string Center { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class MiscPaymentRptReqDTO
    {
        public string PaymentDate { get; set; }
        public string Counter { get; set; }
        public string paymode { get; set; }
        public string Center { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class MiscPaymentCategoryRptReqDTO
    {
        public string PaymentDate { get; set; }
        public int Paycat { get; set; }
        public string Center { get; set; }
    }
}

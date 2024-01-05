using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCPAYMENT
    {
        public string COUNTER { get; set; }
        public string SERIALNO { get; set; }
        public string Reff { get; set; }
        public string PAYMODE { get; set; }
        public int STATUS { get; set; }
        public Decimal Amt { get; set; }

    }
}

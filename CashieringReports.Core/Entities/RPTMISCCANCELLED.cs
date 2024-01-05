using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCCANCELLED
    {
        public string SERIALNO { get; set; }
        public string COUNTER { get; set; }
        public string Cashier { get; set; }
        public string ACUpper { get; set; }
        public string ACLower { get; set; }
        public Decimal VAT { get; set; }
        public string Pay_Mode { get; set; }
        public Decimal AMOUNT { get; set; }
        public string PaymentDate { get; set; }

    }
}

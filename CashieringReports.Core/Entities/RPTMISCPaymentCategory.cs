using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCPaymentCategory
    {
        public string ACCOUNTNUMBER { get; set; }
        public string RECEIPTNUMBER { get; set; }
        public decimal PAYMENTAMOUNT { get; set; }
    }
}

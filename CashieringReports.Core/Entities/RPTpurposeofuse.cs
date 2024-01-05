using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTpurposeofuse
    {
        public string invoiceno { get; set; }
        public string invoicedate { get; set; }
        public string custname { get; set; }
        public string receiptdate { get; set; }
        public string TOTAL { get; set; }
        public string bccode { get; set; }
        public string purpose { get; set; }
        public string transaction_type { get; set; }
    }
}

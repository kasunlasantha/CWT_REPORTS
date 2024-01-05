using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCACCWISEPAYMENT
    {
        public string SERIALNO { get; set; }
        public string Reff { get; set; }
        public Decimal Amt { get; set; }
        public int STATUS { get; set; }
        public string ACCOUNTDESC { get; set; }
        
    }
}

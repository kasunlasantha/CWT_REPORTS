using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCTransSummary
    {
        public string Acc { get; set; }
        public int NOB { get; set; }
        public Decimal Amt { get; set; }
        public Decimal TOT { get; set; }
    }
}

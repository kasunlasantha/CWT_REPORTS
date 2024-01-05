using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCVATSUMMARY
    {
        public string COUNTER { get; set; }
        public int NOB { get; set; }
        public Decimal TOT { get; set; }
        
    }
}

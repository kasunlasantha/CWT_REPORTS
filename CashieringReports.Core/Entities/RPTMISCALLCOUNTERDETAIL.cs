using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{

    [Keyless]
    public class RPTMISCALLCOUNTERDETAIL
    {
        public string COUNTER { get; set; }
        public string SERIALNO { get; set; }
        public Decimal AMOUNT { get; set; }
        public Decimal VAT { get; set; }
        public int STATUS { get; set; }
        public string Pay_Mode { get; set; }
        
        
      
    }
}

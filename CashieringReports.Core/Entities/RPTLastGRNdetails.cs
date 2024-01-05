using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTLastGRNdetails
    {
        public string equcode { get; set; }

        public string Equname { get; set; }
        public int qty { get; set; }
        public double? unitprice { get; set; }
        public double? amount { get; set; }
        public string grndate { get; set; }
        
            
    }
}

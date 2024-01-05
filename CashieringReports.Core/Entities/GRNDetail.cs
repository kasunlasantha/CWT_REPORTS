using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class GRNDetail
    {
        public string equcode { get; set; }
        public string Equname { get; set; }
        public int? qty { get; set; }
        public decimal? unitprice { get; set; }
        public decimal? amount { get; set; }
        public DateTime grndate { get; set; }
        public int? GRNno { get; set; }
    }
}

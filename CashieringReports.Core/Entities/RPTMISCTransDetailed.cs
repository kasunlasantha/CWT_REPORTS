using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCTransDetailed
    {
        public string CentreName { get; set; }
        public string SN { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Ref4 { get; set; }
        public string Ref5 { get; set; }
        public string Ref6 { get; set; }
        public Decimal Amount { get; set; }
        public string CostCentre { get; set; }
        public string Acc { get; set; }
        public Decimal VAT { get; set; }



    }
}

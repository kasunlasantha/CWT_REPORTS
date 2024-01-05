using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTSALESDATA
    {
        public string ItemCode { get; set; }

        public string PropName { get; set; }
        public string QTY { get; set; }
        public double? Amount { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTStockAdjustment
    {
        public string DateAdjust { get; set; }

        public string EquCode { get; set; }
        public string Adjustas { get; set; }
        public string Reason { get; set; }
        public int QTY { get; set; }
        public string AdjustUser { get; set; }
    }
}

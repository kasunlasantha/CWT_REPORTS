using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCenterPaymentCounterSumry
    {
        public string P_Mode { get; set; }
        public int NoOf { get; set; }
        public decimal Total { get; set; }
        public string CAName { get; set; }
            
    }
}

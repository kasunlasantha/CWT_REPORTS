using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class CenterSummaryRptReqDTO
    {
        public string PaymentDate { get; set; }
        public string Counter { get; set; }
        public string Cashier { get; set; }
        public int billtype { get; set; }
        public string center { get; set; }
        public string paymode { get; set; }

        public string rpt_Cfg_ID { get; set; }
    }
}

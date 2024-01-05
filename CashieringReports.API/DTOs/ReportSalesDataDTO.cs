using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class ReportSalesDataDTO
    {
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string center { get; set; }
        public int reportType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class ReportApprovalDTO
    {
        public string CENTER { get; set; }
        public string CFG_ID { get; set; }
        public string GENERATED_DATE { get; set; }
        public string SERVICE_ID { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPTION { get; set; }
        
    }
}

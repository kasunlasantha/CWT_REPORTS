using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class REPORT_APPROVAL
    {
        public int RPT_ID { get; set; }
        public string RPT_CFG_ID { get; set; }
        public string RPT_CENTER { get; set; }
        public string RPT_GENERATED_SERVICE_ID { get; set; }
        public DateTime? RPT_GENERATED_DATE { get; set; }
        public string RPT_FIRST_APPR_SERVICE_ID { get; set; }
        public DateTime? RPT_FIRST_APPR_DATE { get; set; }
        public string RPT_FIRST_APPR_STATUS { get; set; }
        public string RPT_FIRST_APPR_DESCRIPTION { get; set; }
        public string RPT_SECOND_APPR_SERVICE_ID { get; set; }
        public DateTime? RPT_SECOND_APPR_DATE { get; set; }
        public string RPT_SECOND_APPR_STATUS { get; set; }
        public string RPT_SECOND_APPR_DESCRIPTION { get; set; }
        public int RPT_DISCARDED { get; set; }
        public string RPT_PARAMETERS { get; set; }

    }
}

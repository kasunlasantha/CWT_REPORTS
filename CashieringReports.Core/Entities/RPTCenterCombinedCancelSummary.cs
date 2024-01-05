using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCenterCombinedCancelSummary
    {
        public string PAYMODE { get; set; }


        public int? CMRecs { get; set; }
        public decimal? CMAmo { get; set; }
        public int? CBRecs { get; set; }
        public decimal? CBAmo { get; set; }
        public int? CMPRecs { get; set; }
        public decimal? CMPAmo { get; set; }
        public int? CSPRecs { get; set; }
        public decimal? CSPAmo { get; set; }
        public int? CEAcs { get; set; }
        public decimal? CEAmo { get; set; }
        public int? CCAcs { get; set; }
        public decimal? CCAmo { get; set; }

    }
}

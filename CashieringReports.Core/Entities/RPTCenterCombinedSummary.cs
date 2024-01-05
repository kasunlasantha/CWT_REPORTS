using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCenterCombinedSummary
    {
        public string PAYMODE { get; set; }

        public int? MRecs { get; set; }
        public decimal? MAmo { get; set; }
        public int? BRecs { get; set; }
        public decimal? BAmo { get; set; }
        public int? MPRecs { get; set; }
        public decimal? MPAmo { get; set; }
        public int? SPRecs { get; set; }
        public decimal? SPAmo { get; set; }
        public int? EAcs { get; set; }
        public decimal? EAmo { get; set; }
        public int? CAcs { get; set; }
        public decimal? CAmo { get; set; }
        //public string Center { get; set; }

    }
}

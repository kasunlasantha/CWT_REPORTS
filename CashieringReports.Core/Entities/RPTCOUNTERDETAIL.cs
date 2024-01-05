using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCOUNTERDETAIL
    {
        public string CA_NAME { get; set; }
        public string P_Mode { get; set; }
        public string P_Recept_No { get; set; }
        public string I_Inv_No { get; set; }
        public decimal? P_Total { get; set; }
        public string P_Payment_No { get; set; }
        
    }
}

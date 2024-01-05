using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCenterCheqShedule
    {
        public string P_Recept_No { get; set; }
        public string P_Mode { get; set; }
        public string P_Payment_No { get; set; }
        public int P_Total { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCHNAME { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCancelledBillData
    {
        public string P_Ca_Name { get; set; }
        public string P_Counter { get; set; }
        public string P_Recept_No { get; set; }
        public string P_Mode { get; set; }
        public Decimal P_Total { get; set; }
        public string P_Date_Proces { get; set; }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTBankDepositEntryDT
    {
        public string PayMode { get; set; }
        public string DEPOSTDATE { get; set; }
        public decimal? AMOUNT { get; set; }

        public string SLIPNUMBER { get; set; }

        public string BankCode { get; set; }
        public string DepositUser { get; set; }

    }
}

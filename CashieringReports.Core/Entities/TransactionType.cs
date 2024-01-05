using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class TransactionType
    {
        public string tran_type { get; set; }
        public int tran_id { get; set; }
    }
}

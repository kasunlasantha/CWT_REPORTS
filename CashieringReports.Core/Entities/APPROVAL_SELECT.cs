using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class APPROVAL_SELECT
    {
        public int RPT_ID { get; set; }
    }
}

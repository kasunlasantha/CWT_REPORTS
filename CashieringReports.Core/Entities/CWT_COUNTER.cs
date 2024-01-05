using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class CWT_COUNTER
    {
        public decimal COUNTERID { get; set; }

        public string CENTERCODE { get; set; }

        public string COUNTER { get; set; }

        public DateTime? LASTUPDATEDTIME { get; set; }
    }
}

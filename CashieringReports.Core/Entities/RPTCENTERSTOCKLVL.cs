using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCENTERSTOCKLVL
    {
        public string EquCode { get; set; }

        public string EquName { get; set; }
        public int QIH { get; set; }

        public int EQUTYPE { get; set; }
        

    }
}

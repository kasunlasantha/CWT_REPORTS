using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class CWT_MISCCASHIERINFO
    {

      
        public string CENTERCODE { get; set; }
        public string SERVICEID { get; set; }

        public decimal? BILLSEQ { get; set; }
        public decimal? BILLTOTCA { get; set; }
        public decimal? BILLTOTCH { get; set; }
        public decimal? BILLTOTCC { get; set; }
        public decimal? BILLTOTMO { get; set; }
        public decimal? BILLTOTBD { get; set; }
        public decimal? BILLTOTDT { get; set; }


        public decimal? MOBITOTCA { get; set; }
        public decimal? MOBITOTCH { get; set; }
        public decimal? MOBITOTCC { get; set; }
        public decimal? MOBITOTMO { get; set; }
        public decimal? MOBITOTBD { get; set; }
        public decimal? MOBITOTDT { get; set; }

        public decimal? PREPTOTCA { get; set; }
        public decimal? PREPTOTCH { get; set; }
        public decimal? PREPTOTCC { get; set; }
        public decimal? PREPTOTMO { get; set; }
        public decimal? PREPTOTBD { get; set; }
        public decimal? PREPTOTDT { get; set; }


        public decimal? MISCSEQ { get; set; }
        public decimal? MISCTOTCA { get; set; }
        public decimal? MISCTOTCH { get; set; }
        public decimal? MISCTOTCC { get; set; }
        public decimal? MISCTOTMO { get; set; }
        public decimal? MISCTOTBD { get; set; }
        public decimal? MISCTOTDT { get; set; }

        public decimal? ERPSEQ { get; set; }
        public decimal? ERPTOTCA { get; set; }
        public decimal? ERPTOTCH { get; set; }
        public decimal? ERPTOTCC { get; set; }
        public decimal? ERPTOTMO { get; set; }
        public decimal? ERPTOTBD { get; set; }
        public decimal? ERPTOTDT { get; set; }


        public decimal? CRMSEQ { get; set; }
        public decimal? CRMTOTCA { get; set; }
        public decimal? CRMTOTCH { get; set; }
        public decimal? CRMTOTCC { get; set; }
        public decimal? CRMTOTMO { get; set; }
        public decimal? CRMTOTBD { get; set; }
        public decimal? CRMTOTDT { get; set; }

        public string COUNTER { get; set; }
        


    }
}

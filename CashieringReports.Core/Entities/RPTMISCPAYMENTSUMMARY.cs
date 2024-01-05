using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCPAYMENTSUMMARY
    {
        //public RPTMISCPAYMENTSUMMARY()
        //{
        //    Pay_Mode = "";
        //    No_Bills = 0;
        //    TOT = 0;
        //    STATUS = 0;
        //    SERIALNO = "";
        //    AccountCode = "";
        //    CashName = "";
        //}

        public string Pay_Mode { get; set; }
        public int No_Bills { get; set; }
        public Decimal TOT { get; set; }
        public int STATUS { get; set; }
        public string SERIALNO { get; set; }
        public string AccountCode { get; set; }
        public string CashName { get; set; }

    }
}

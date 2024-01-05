using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class SLTRECEIPT
    {
        public string RECEIPTNUMBER { get; set; }
        public DateTime? PAYMENTDATE { get; set; }//DATE
        public decimal? PAYMENTAMOUNT { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCHNAME { get; set; }
        public string PAYMODENAME { get; set; }
        public string PAYMENTID { get; set; }
        public int STATUS { get; set; }
        public string ACCOUNTNUMBER { get; set; }
        public string CUSTOMERREF { get; set; }
        public string cusname { get; set; }
    }
}

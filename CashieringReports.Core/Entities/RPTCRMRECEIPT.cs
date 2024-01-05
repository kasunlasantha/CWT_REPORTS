using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCRMRECEIPT
    {
        public string RECEIPTNUMBER { get; set; }//VARCHAR2(20 BYTE)
        public string PAYMENTMODE { get; set; }//VARCHAR2(2 BYTE)
        public string BILLING_ACCOUNTNUMBER { get; set; }//VARCHAR2(10 BYTE)
        public DateTime? PAYMENTDATE { get; set; }//DATE
        public decimal? AMOUNT { get; set; }//NUMBER(18,2)
        public string ORDER_NUMBER { get; set; }//VARCHAR2(30)
        public string PAYMODENAME { get; set; }//VARCHAR2(25 BYTE)
        public string COMPNAME { get; set; }//VARCHAR2(50 BYTE)
        public string BRANCHNAME { get; set; }//VARCHAR2(50 BYTE)
        public string CRMPAYMENTID { get; set; }//NUMBER
        public string BILLING_ACC_NAME { get; set; }//VARCHAR2(100 BYTE)
    }
}

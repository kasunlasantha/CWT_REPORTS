using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTMISCPAYFORRECIPT
    {
        public string SERIALNO { get; set; }//VARCHAR2(32 BYTE)
        public DateTime PAYMENTDATE { get; set; }//DATE
        public string REFERENCE2 { get; set; }//VARCHAR2(64 BYTE)
        public string REFERENCE3 { get; set; }//VARCHAR2(64 BYTE)
        public decimal AMOUNT { get; set; }//NUMBER(15,2)
        public string Decp { get; set; }//VARCHAR2(18 BYTE)
        public string INVOICENO { get; set; }//char(18 BYTE)
        public string PAYMODENAME { get; set; }//VARCHAR2(25 BYTE)
        public string ACCOUNTDESC { get; set; }//VARCHAR2(128 BYTE)
        public string CH_MO_BD { get; set; }//VARCHAR2(32 BYTE)
        public string COMPNAME { get; set; }//VARCHAR2(50 BYTE)
        public string BRANCHNAME { get; set; }//VARCHAR2(50 BYTE)
        public string CENTERNAME { get; set; }//VARCHAR2(100 BYTE)
    }
}

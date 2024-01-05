using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class ERPRECEIPT
    {
        public string RECIPTNO { get; set; }//varchar 32
        public DateTime PAYMENTDATE { get; set; }//datetime
        public string PAYMODENAME { get; set; }
        public string COMPNAME { get; set; }
        public string BRANCHNAME { get; set; }
        public string PAYMENT_REFERNCE { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string ACCOUNTNO { get; set; }
        public decimal TOTALPAID { get; set; }
        public string INVOICENUMBER { get; set; }
        public string ADDRESS { get; set; }
        public string Inv_Type { get; set; }
        public string AMOUNT { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    public class MOBINVALS
    {
        public string mobileno { get; set; }
        public string CustomerName { get; set; }

        public string PaymentMode { get; set; }

        public string CCHCBDMOno { get; set; }

        public decimal? Paymentamount { get; set; }

        public decimal? Amounttendered { get; set; }

        public decimal? balance { get; set; }

        public string Remitteddate { get; set; }

        public string CENTERCODE { get; set; }

        public decimal? UserID { get; set; }
        
        public decimal? Counter { get; set; }

        public string CA_SERVICEID { get; set; }
        


    }
}

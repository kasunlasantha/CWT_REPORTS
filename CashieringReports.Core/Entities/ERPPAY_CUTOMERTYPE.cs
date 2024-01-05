using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class ERPPAY_CUTOMERTYPE
    {
        public string? InvoiceType { get; set; }

        public string? Cus_Name { get; set; }

        public string? ErpAccountNo { get; set; }

        public string? Address { get; set; }

        public string? InvoiceNo { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string? Currency { get; set; }

        public string? Related_Tran_No { get; set; }

        public string? Ispaid { get; set; }

        public string? Amount { get; set; }

        public decimal? TotalPaid { get; set; }

        public string? CustomerType { get; set; }

        public int? IsInstallment { get; set; }

        public string? InvoiceAmt { get; set; }
    }
}

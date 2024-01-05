using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Table("MOBITELPAYMENT")]
    public class MOBITELPAYMENT
    {
        [Key]
        public decimal PAYMENTID { get; set; }

        [Required]
        [StringLength(10)]
        public string TELEPHONENUMBER { get; set; }

        public DateTime PAYMENTDATE { get; set; }

        public decimal PAYMENTAMOUNT { get; set; }

        [StringLength(3)]
        public string CURRENCY { get; set; }

        public decimal? PAYMENTMETHOD { get; set; }

        [StringLength(200)]
        public string PAYMENTDESCRIPTION { get; set; }

        [StringLength(20)]
        public string PAYMENTREF { get; set; }

        [StringLength(200)]
        public string CUSTOMERNAME { get; set; }

        [StringLength(20)]
        public string RECEIPTNUMBER { get; set; }

        [StringLength(20)]
        public string CREDITCARDNUM { get; set; }

        [StringLength(20)]
        public string UPLOADMETHOD { get; set; }

        [Required]
        [StringLength(20)]
        public string CENTERCODE { get; set; }

        [StringLength(10)]
        public string ERRORCODE { get; set; }

        public decimal? STATUS { get; set; }

        public decimal? TRYCOUNT { get; set; }

        public decimal? CANCELSTATUS { get; set; }

        public decimal? PAYMENTIDORIGIN { get; set; }

        [StringLength(16)]
        public string LASTUPDATEDUSER { get; set; }

        public DateTime? LASTUPDATEDTIME { get; set; }

        public decimal? CODA_SEND { get; set; }

        [StringLength(2)]
        public string PAYMENTMODE { get; set; }

        public decimal? RETSTATUS { get; set; }

        public decimal? RETTRANSID { get; set; }

        [StringLength(18)]
        public string RETRECEIPTNUMBER { get; set; }

        [StringLength(10)]
        public string RETMERCHANTCODE { get; set; }


    }
}

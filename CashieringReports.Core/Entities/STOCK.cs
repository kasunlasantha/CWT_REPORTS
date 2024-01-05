using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Table("STOCK")]
    public class STOCK
    {

        public decimal STOCKID { get; set; }

        [Required]
        [StringLength(12)]
        public string EQUCODE { get; set; }

        [Required]
        [StringLength(4)]
        public string BC_CODE { get; set; }

        public decimal RECEIVEDQTY { get; set; }

        public decimal SOLDQTY { get; set; }

        public decimal RESERVEDQTY { get; set; }

        public decimal DEFECTEDQTY { get; set; }

        public decimal? EQUTYPE { get; set; }

        public decimal REORDERQTY { get; set; }

        public decimal REORDERLEVEL { get; set; }


    }
}

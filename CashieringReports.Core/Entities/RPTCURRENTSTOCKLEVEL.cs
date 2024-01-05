using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class RPTCURRENTSTOCKLEVEL
    {

        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        //public int EQUBLOCK { get; set; }
        public int ReservedQTY { get; set; }
        public int DefectedQTY { get; set; }
        public int ReceivedQTY { get; set; }
        public int SoldQTY { get; set; }
        public int QTY_InHand { get; set; }
        //public string EQU_TYPE { get; set; }
    }
}

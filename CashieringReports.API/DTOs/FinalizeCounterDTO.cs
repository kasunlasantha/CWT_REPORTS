using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class FinalizeCounterDTO
    {
        public string U_NAME { get; set; }
        public string U_COUNTER { get; set; }
        public int Cashi_ID { get; set; }
    }
}

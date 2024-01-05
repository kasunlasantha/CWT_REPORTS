using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashieringReports.API.DTOs
{
    public class MobiCancelReqDTO
    {
        public string upload_method { get; set; }
        public int payment_id { get; set; }
    }
}

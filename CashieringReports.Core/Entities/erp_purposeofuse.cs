﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashieringReports.Core.Entities
{
    [Keyless]
    public class erp_purposeofuse
    {
        public string PURPOSE { get; set; }
    }
}

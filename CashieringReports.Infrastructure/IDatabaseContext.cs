using CashieringReports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace CashieringReports.Infrastructure
{
    public interface IDatabaseContext
    {

        DbSet<CASHIER> CASHIERs { get; set; }

        DbSet<STOCK> STOCKs { get; set; }

        //public DbSet<RPTCURRENTSTOCKLEVEL> RPTCURRENTSTOCKLEVELs { get; set; }

        int SaveChanges();
/*        DbEntityEntry Entry(object entity);
        Database Database { get; }*/
        void Dispose();
    }
}

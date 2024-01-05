using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CashieringReports.Core.Entities;
using System.Data.Entity.Infrastructure;

namespace CashieringReports.Infrastructure
{
    public class DBContextCore : DbContext, IDatabaseContext
    {
        public DBContextCore(DbContextOptions<DBContextCore> options)
           : base(options)
        {

        }

        public DbSet<CASHIER> CASHIERs { get; set; }

        public DbSet<STOCK> STOCKs { get; set; }
        public DbSet<RPTCURRENTSTOCKLEVEL> RPTCURRENTSTOCKLEVELs { get; set; }

        public DbSet<RPTMISCPAYMENTSUMMARY> RPTMISCPAYMENTSUMMARYs { get; set; }
        public DbSet<RPTMISCALLCOUNTERDETAIL> RPTMISCALLCOUNTERDETAILs { get; set; }
        public DbSet<RPTMISCVATSUMMARY> RPTMISCVATSUMMARYs { get; set; }
        public DbSet<RPTMISCCANCELLED> RPTMISCCANCELLEDs { get; set; }
        public DbSet<RPTMISCPAYMENT> RPTMISCPAYMENTs { get; set; }
        public DbSet<RPTMISCACCWISEPAYMENT> RPTMISCACCWISEPAYMENTs { get; set; }
        public DbSet<RPTMISCTransSummary> RPTMISCTransSummarys { get; set; }
        public DbSet<RPTMISCTransDetailed> RPTMISCTransDetaileds { get; set; }
        public DbSet<RPTMISCPaymentCategory> RPTMISCPaymentCategorys { get; set; }
        public DbSet<RPTCenterPaymentCounterSumry> RPTCenterPaymentCounterSumrys { get; set; }
        public DbSet<RPTCenterCheqShedule> RPTCenterCheqShedules { get; set; }
        public DbSet<RPTCancelledBillData> RPTCancelledBillDatas { get; set; }
        public DbSet<RPTBankDepositEntryDT> RPTBankDepositEntryDTs { get; set; }
        public DbSet<BODRetStr> BODRetStrs { get; set; }
        public DbSet<GETEODRET> GETEODRETs { get; set; }
        public DbSet<CWT_COUNTER> CWT_COUNTERs { get; set; }
        public DbSet<CWT_MISCCASHIERINFO> CWT_MISCCASHIERINFOs { get; set; }
        public DbSet<RPTCenterCombinedSummary> RPTCenterCombinedSummarys { get; set; }
        public DbSet<RPTCenterCombinedCancelSummary> RPTCenterCombinedCancelSummarys { get; set; }
        public DbSet<CWT_CA_SERVICEID> CWT_CA_SERVICEIDs { get; set; }
        public DbSet<erp_purposeofuse> erp_purposeofuses { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<GRNDetail> GRNDetails { get; set; }
        public DbSet<MAXGRN> MAXGRNs { get; set; }
        public DbSet<REPORT_APPROVAL> REPORT_APPROVALs { get; set; }
        public DbSet<APPROVAL_SELECT> APPROVAL_SELECTs { get; set; }
        


        //RECEIPTS
        public DbSet<RPTMISCPAYFORRECIPT> RPTMISCPAYFORRECIPTs { get; set; }
        public DbSet<ERPRECEIPT> ERPRECEIPTs { get; set; }
        public DbSet<SLTRECEIPT> SLTRECEIPTs { get; set; }
        public DbSet<RPTCRMRECEIPT> RPTCRMRECEIPTs { get; set; }
        public DbSet<RPTCENTERDETAIL> RPTCENTERDETAILs { get; set; }
        public DbSet<RPTCOUNTERDETAIL> RPTCOUNTERDETAILs { get; set; }
        public DbSet<RPTCENTERSTOCKLVL> RPTCENTERSTOCKLVLs { get; set; }
        public DbSet<RPTSALESDATA> RPTSALESDATAs { get; set; }
        public DbSet<RPTLastGRNdetails> RPTLastGRNdetailss { get; set; }
        public DbSet<RPTStockAdjustment> RPTStockAdjustments { get; set; }
        public DbSet<RPTpurposeofuse> RPTpurposeofuses { get; set; }
        














    }
}

using CreditInfoDataLoader.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInfoDataLoader.Model
{
    public class Contract
    {
        public string ContractCode { get; set; }
        public PhaseOfContract PhaseOfContract { get; set; }
        public Amount OriginalAmount { get; set; }
        public Amount InstallmentAmount { get; set; }
        public Amount CurrentBalanceAmount { get; set; }
        public Amount OverdueBalanceAmount { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public DateTime DateOfNextPayment { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime RealEndDate { get; set; }

        public List<Individual> Individuals { get; set; }
        public List<SubjectRole> SubjectRoles { get; set; }
    }
}

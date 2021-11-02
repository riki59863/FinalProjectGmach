using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class DirectDebit
    {
        public DirectDebit()
        {
            Deposits = new HashSet<Deposits>();
            Loan = new HashSet<Loan>();
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Target { get; set; }
        public int TotalSum { get; set; }
        public int DirectDebitSum { get; set; }
        public int CurrencyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int CollectionDay { get; set; }
        public int BankId { get; set; }
        public int NumberBranchId { get; set; }
        public int NumberAccount { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DirectDebitFile { get; set; }

        public virtual Banks Bank { get; set; }
        public virtual BankBranches NumberBranch { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Deposits> Deposits { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

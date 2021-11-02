using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class CurrencyType
    {
        public CurrencyType()
        {
            Deposits = new HashSet<Deposits>();
            Loan = new HashSet<Loan>();
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public double ValueInShkalim { get; set; }
        public DateTime UpdatedLast { get; set; }

        public virtual ICollection<Deposits> Deposits { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

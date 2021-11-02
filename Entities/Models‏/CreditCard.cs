using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Deposits = new HashSet<Deposits>();
            Loan = new HashSet<Loan>();
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardNumberPlain { get; set; }
        public DateTime? CreditCardExpiry { get; set; }
        public string Name { get; set; }
        public int? CreditCardType { get; set; }
        public int? Deleted { get; set; }
        public string GatewayKey { get; set; }
        public int? Optlock { get; set; }

        public virtual ICollection<Deposits> Deposits { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

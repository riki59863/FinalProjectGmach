using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class User
    {
        public User()
        {
            Deposits = new HashSet<Deposits>();
            DirectDebit = new HashSet<DirectDebit>();
            Guarnty = new HashSet<Guarnty>();
            Loan = new HashSet<Loan>();
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string IdentityNumber { get; set; }
        public int? LoanId { get; set; }
        public int? DepositId { get; set; }

        public virtual Deposits Deposit { get; set; }
        public virtual Loan LoanNavigation { get; set; }
        public virtual ICollection<Deposits> Deposits { get; set; }
        public virtual ICollection<DirectDebit> DirectDebit { get; set; }
        public virtual ICollection<Guarnty> Guarnty { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

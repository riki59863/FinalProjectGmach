using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Guarnty
    {
        public Guarnty()
        {
            LoanGuarantyId1Navigation = new HashSet<Loan>();
            LoanGuarantyId2Navigation = new HashSet<Loan>();
            LoanGuarantyId3Navigation = new HashSet<Loan>();
            LoanGuarantyId4Navigation = new HashSet<Loan>();
            LoanGuarantyId5Navigation = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Loan> LoanGuarantyId1Navigation { get; set; }
        public virtual ICollection<Loan> LoanGuarantyId2Navigation { get; set; }
        public virtual ICollection<Loan> LoanGuarantyId3Navigation { get; set; }
        public virtual ICollection<Loan> LoanGuarantyId4Navigation { get; set; }
        public virtual ICollection<Loan> LoanGuarantyId5Navigation { get; set; }
    }
}

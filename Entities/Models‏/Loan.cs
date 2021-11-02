using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Loan
    {
        public Loan()
        {
            Payment = new HashSet<Payment>();
            UserNavigation = new HashSet<User>();
            Warning = new HashSet<Warning>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Sum { get; set; }
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string HebrewDate { get; set; }
        public int RepaymentManner { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public string HebrewRepaymentDate { get; set; }
        public int? DirectDebitId { get; set; }
        public int PaymentsNumber { get; set; }
        public bool PaidUp { get; set; }
        public int? GuarantyId1 { get; set; }
        public int? GuarantyId2 { get; set; }
        public int? GuarantyId3 { get; set; }
        public int? GuarantyId4 { get; set; }
        public int? GuarantyId5 { get; set; }
        public int? CreditCardId { get; set; }
        public int? MonthlyPaymentDay { get; set; }
        public int? MonthlyPaymentSum { get; set; }
        public string Shtar { get; set; }
        public DateTime? FirstRepaymentDate { get; set; }
        public int? PaymentsIndex { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual CurrencyType Currency { get; set; }
        public virtual DirectDebit DirectDebit { get; set; }
        public virtual Guarnty GuarantyId1Navigation { get; set; }
        public virtual Guarnty GuarantyId2Navigation { get; set; }
        public virtual Guarnty GuarantyId3Navigation { get; set; }
        public virtual Guarnty GuarantyId4Navigation { get; set; }
        public virtual Guarnty GuarantyId5Navigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<User> UserNavigation { get; set; }
        public virtual ICollection<Warning> Warning { get; set; }
    }
}

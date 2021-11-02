using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public int CurrencyId { get; set; }
        public int? ExchangeRate { get; set; }
        public string Comments { get; set; }
        public int MethodId { get; set; }
        public int? DirectDebitId { get; set; }
        public DateTime? InputDate { get; set; }
        public string HebrewPaymentDate { get; set; }
        public int? CreditCardId { get; set; }
        public int LoanId { get; set; }
        public int? NumOfPayments { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual CurrencyType Currency { get; set; }
        public virtual DirectDebit DirectDebit { get; set; }
        public virtual Loan Loan { get; set; }
        public virtual PaymentMethod Method { get; set; }
        public virtual User User { get; set; }
    }
}

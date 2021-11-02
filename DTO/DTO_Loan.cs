using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Sum { get; set; }
        public int CurrencyId { get; set; }
        public DateTime LoanDate { get; set; }
        public string HebrewLoanDate { get; set; }
        public int RepaymentManner { get; set; }
        public DateTime RepaymentDate { get; set; }
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
        public int MonthlyPaymentDay { get; set; }
        public int? MonthlyPaymentSum { get; set; }
    }
}

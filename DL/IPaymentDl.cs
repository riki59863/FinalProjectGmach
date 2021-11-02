
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IPaymentDl
    {
        Task<List<Payment>> getAllPaymentsForLoan(int userId );
        //Task<List<Payment>> getAllPaymentsThatWerentPadeByDate(DateTime date);
        Task<List<Payment>> getAllPayments(DTO_PaymentParams dTO_PaymentParams);
        Task updatePayment(Payment updatedPayment);
        Task postPayment(Payment newPayment);
        Task<List<Payment>> getAllPaymentsForLoanByUserIdAndLoanDate(int userId, DateTime loanDate);
        //Task<Payment> getTheLastPayment(int userId);
    }
}

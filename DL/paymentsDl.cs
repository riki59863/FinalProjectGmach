

using DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class paymentsDl : IPaymentDl
    {
        gmach1112020Context gmachContext;
        public paymentsDl(gmach1112020Context _gmachContext)
        {
            this.gmachContext = _gmachContext;
        }
        //public async Task<Payments> getPayments(DateTime date)
        //{
        //    var p = _gmachServerContext.Loans.Where(d => d.FirstPaymentDate == date && d => d.HadBeenPaidUp==false).ToListAsync() ;
        //    if (dbContext.Loans.Where(i => i.code == p.loanCode).FirstOrDefaultAsync() ==)
        //    {
        //    }
        //}
        public async Task<List<Payment>> getAllPayments(DTO_PaymentParams dTO_PaymentParams)
        {
            var query = await gmachContext.Payment
             .Join(gmachContext.User,
             payment => payment.UserId,
             user => user.Id,
             (payment, user) => new { Payment = payment, User = user })
             .Where(userAndPayment => (dTO_PaymentParams.firstName == null || (userAndPayment.User.Id == userAndPayment.Payment.UserId && userAndPayment.User.FirstName == dTO_PaymentParams.firstName))
                 && (dTO_PaymentParams.lastName == null || (userAndPayment.User.Id == userAndPayment.Payment.UserId && userAndPayment.User.LastName == dTO_PaymentParams.lastName))
                 && (dTO_PaymentParams.CollectionSumFrom == null || userAndPayment.Payment.Sum >= dTO_PaymentParams.CollectionSumFrom)
                 && (dTO_PaymentParams.CollectionSumTill == null || userAndPayment.Payment.Sum <= dTO_PaymentParams.CollectionSumTill)
                 && (dTO_PaymentParams.CollectionSumExact == null || userAndPayment.Payment.Sum == dTO_PaymentParams.CollectionSumExact)
                 && (dTO_PaymentParams.dateExact == null || DateTime.Compare(userAndPayment.Payment.Date, dTO_PaymentParams.dateExact == null ? DateTime.MinValue : dTO_PaymentParams.dateExact.Value) == 0)
                 && (dTO_PaymentParams.dateFrom == null || DateTime.Compare(userAndPayment.Payment.Date, dTO_PaymentParams.dateFrom == null ? DateTime.MinValue : dTO_PaymentParams.dateFrom.Value) >= 0)
                 && (dTO_PaymentParams.dateTill == null || DateTime.Compare(userAndPayment.Payment.Date, dTO_PaymentParams.dateTill == null ? DateTime.MinValue : dTO_PaymentParams.dateTill.Value) <= 0)).Select(p => p.Payment).ToListAsync();
            return query;
            //List<User> usersLast = await gmachContext.User.Where(user => user.LastName == dTO_PaymentParams.lastName).ToListAsync();
            //List<User> usersFirst = await gmachContext.User.Where(user => user.FirstName == dTO_PaymentParams.firstName).ToListAsync();
            //List<Payment> p = await gmachContext.Payment.Where(
            //    q => (dTO_PaymentParams.CollectionSumFrom == null || q.CollectionSum >= dTO_PaymentParams.CollectionSumFrom)
            //    && (dTO_PaymentParams.CollectionSumTill == null || q.CollectionSum <= dTO_PaymentParams.CollectionSumTill)
            //    && (dTO_PaymentParams.CollectionSumExact == null || q.CollectionSum == dTO_PaymentParams.CollectionSumExact)
            //    && (dTO_PaymentParams.firstName == null || usersFirst.Where(u => u.Id == q.UserId).AsEnumerable().ToList().Count == 1)
            //    && (dTO_PaymentParams.lastName == null || (searchLastNameAsync(usersLast, q.UserId)))).ToListAsync();
        }

        public async Task<List<Payment>> getPaymentsSearch(DTO_PaymentParams param)
        {
            var p = gmachContext.Payment.Where(q => (q.Sum > param.CollectionSumFrom || param.CollectionSumFrom == null));
            return await p.ToListAsync();
        }
        public async Task<List<Payment>> getAllPaymentsForLoan(int userId)
        {
            return await gmachContext.Payment.Where(d => d.UserId == userId).ToListAsync();
        }
        public async Task<List<Payment>> getAllPaymentsForLoanByUserIdAndLoanDate(int userId, DateTime loanDate)
        {
            var p = gmachContext.Payment.Where(p => (p.UserId == userId && DateTime.Compare(p.Date, loanDate) >= 0));
            return await p.ToListAsync();
        }
        //public async Task<List<Payment>> getAllPaymentsThatWerentPade(string loanId)
        //{
        //    return await gmachContext.Payment.Where(d => d.l == loanId).ToListAsync();

        //}
        public async Task updatePayment(Payment updatedPayment)
        {
            gmachContext.Payment.Update(updatedPayment);
            await gmachContext.SaveChangesAsync();
        }
        public async Task postPayment(Payment newPayment)
        {
            await gmachContext.Payment.AddAsync(newPayment);
            await gmachContext.SaveChangesAsync();
        }
        //public async Task<Payment> getTheLastPayment(int userId)
        //{
        //    return (Payment)gmachContext.Payment.OrderByDescending(x => x.Id).Take(1);
        //}

    }
}

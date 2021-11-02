
using DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class LoanDl : ILoanDl
    {
        gmach1112020Context gmachContext;
        public LoanDl(gmach1112020Context _gmachContext)
        {
            gmachContext = _gmachContext;
        }

        public async Task<List<Loan>> getAllLoans(DTO_LoansParams dTO_LoansParams)
        {
            var a = gmachContext.Loan.Where(l => (dTO_LoansParams.PaidUp == null || l.PaidUp == dTO_LoansParams.PaidUp)).FirstOrDefault();
            var query = await gmachContext.Loan
                        .Join(gmachContext.User,
                        loan => loan.UserId,
                        user => user.Id,
                        (loan, user) => new { Loan = loan, User = user })
                        .Where(userAndLoan => (dTO_LoansParams.firstName == null || (userAndLoan.User.Id == userAndLoan.Loan.UserId && userAndLoan.User.FirstName == dTO_LoansParams.firstName))
                            && (dTO_LoansParams.lastName == null || (userAndLoan.User.Id == userAndLoan.Loan.UserId && userAndLoan.User.LastName == dTO_LoansParams.lastName))
                            && (dTO_LoansParams.sumFrom == null || userAndLoan.Loan.Sum >= dTO_LoansParams.sumFrom)
                            && (dTO_LoansParams.sumTill == null || userAndLoan.Loan.Sum <= dTO_LoansParams.sumTill)
                            && (dTO_LoansParams.sumExact == null || userAndLoan.Loan.Sum == dTO_LoansParams.sumExact)
                            && (dTO_LoansParams.PaidUp == null || userAndLoan.Loan.PaidUp == dTO_LoansParams.PaidUp)
                            && (dTO_LoansParams.dateExact == null || DateTime.Compare(userAndLoan.Loan.Date, dTO_LoansParams.dateExact == null ? DateTime.MinValue : dTO_LoansParams.dateExact.Value) == 0)
                            && (dTO_LoansParams.MonthlyPaymentDay == null || userAndLoan.Loan.MonthlyPaymentDay == dTO_LoansParams.MonthlyPaymentDay)
                            && (dTO_LoansParams.dateFrom == null || DateTime.Compare(userAndLoan.Loan.Date, dTO_LoansParams.dateFrom == null ? DateTime.MinValue : dTO_LoansParams.dateFrom.Value) >= 0)
                            && (dTO_LoansParams.dateTill == null || DateTime.Compare(userAndLoan.Loan.Date, dTO_LoansParams.dateTill == null ? DateTime.MinValue : dTO_LoansParams.dateTill.Value) <= 0)).Select(l => l.Loan).ToListAsync();
            return query;
        }


        //public async List<Loan> getAllLoanList()
        //{
        //    return  gmachContext.Loan.ToListAsync();
        //}
        public async Task<Loan> getLoanById(int id)
        {
            return await gmachContext.Loan.Where(u => u.Id == id).FirstOrDefaultAsync(); ;
        }
        //public async Task<int> getLoanByUserId(int identityNumber)
        //{
        //    User user = await gmachContext.User.Where(u => u.IdentityNumber == identityNumber).FirstOrDefaultAsync();
        //    Loan l = await gmachContext.Loan.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
        //    return l.Id;
        //}
        public Loan getLoanByUserId(string identityNumber)
        {
            User user = gmachContext.User.Where(u => u.IdentityNumber == identityNumber).FirstOrDefault();
            Loan l = gmachContext.Loan.Where(l => l.UserId == user.Id).FirstOrDefault();
            return l;
        }
        public async Task<Loan> getLoanByUserIdForPayment(int id)
        {
            Loan l = await gmachContext.Loan.Where(l => (l.UserId == id && l.PaidUp == false)).FirstOrDefaultAsync();
            return l;
        }
        //public async Task<Loan> getLoanDetails(string loanCode)
        //{
        //    return await gmachContext.Loan.Where(u => u.LoanCode == loanCode).FirstOrDefaultAsync();
        //}
        //public async Task<List<Loan>> getLoanList(string name)
        //{
        //    var user = await gmachContext.Loan.Where(u => u.LoanerName == name).ToListAsync();
        //    return user;
        //}
        public Task<List<Loan>> getAllLoans()
        {
            return gmachContext.Loan.ToListAsync();
        }
        //public async Task<List<Loan>> getLoansByDate(DateTime date)
        //{
        //    var p = gmachContext.Loan.Where(d => d.HadBeenPaidUp == "yes" && d.FirstPaymentDate <= date && d.DayInMonth == date.Day).ToListAsync();
        //    return await p;
        //}
        //public async Task<int> postNewLoan(DTO_Loaner loan)
        //{
        //    await gmachContext.Loan.AddAsync(loan.loan).ConfigureAwait(false); 
        //    var a = await gmachContext.User.FindAsync(loan.user.IdentityNumber).ConfigureAwait(false) ;
        //    await gmachContext.User.AddAsync(loan.user).ConfigureAwait(false); 
        //    await gmachContext.DirectDebit.AddAsync(loan.directDebit).ConfigureAwait(false); 
        //    foreach (var g in loan.usersAsGuarntys)
        //    {
        //        await gmachContext.User.AddAsync(g).ConfigureAwait(false); 
        //    }
        //    await gmachContext.SaveChangesAsync().ConfigureAwait(false); 
        //    return await getLoanByUserId(loan.user.IdentityNumber);
        //}
        public Loan postNewLoan(DTO_Loaner loan)
        {
            gmachContext.Loan.Add(loan.loan);
            gmachContext.SaveChanges();
            Loan l = getLoanByUserId(loan.user.IdentityNumber);
            return l;
        }
        public void updateLoan(Loan loan)
        {
            var loanToUpdate = gmachContext.Loan.Where(l => l.Id == loan.Id).FirstOrDefault();
            gmachContext.Entry(loanToUpdate).CurrentValues.SetValues(loan);
            gmachContext.SaveChanges();
        }
        public async Task<Loan> getLoanerByUserId(int userId)
        {
            return await gmachContext.Loan.Where(d => d.UserId == userId).FirstOrDefaultAsync();
        }
        public async Task<int> returnId(Loan loan)
        {
            return 1;
        }

    }
}

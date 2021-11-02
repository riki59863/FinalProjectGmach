
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ILoanDl
    {
        //Task<List<Loan>> getLoanList(string name);
        //Task<Loan> getLoanDetails(string loanCode);
        Task<List<Loan>> getAllLoans();
        //Task<List<Loan>> getLoansByDate(DateTime date);
        Task<Loan> getLoanById(int id);
        //Task post(DTO_Loaner loan);
        Task<List<Loan>> getAllLoans(DTO_LoansParams dTO_LoansParams);
        void updateLoan(Loan loan);
        //Task<int> postNewLoan(DTO_Loaner loan);
        Loan postNewLoan(DTO_Loaner loan);
        Task<int> returnId(Loan loan);
        Loan getLoanByUserId(string identityNumber);
        Task<Loan> getLoanByUserIdForPayment(int id);
        Task<Loan> getLoanerByUserId(int userId);
    }
}
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ILoanBl
    {
        //Task<List<Loan>> getLoanList(string name);
        Task<List<Loan>> getAllLoans(DTO_LoansParams dTO_LoansParams);
        Task<List<Loan>> getAllLoans();
        //Task<List<Loan>> getLoansByDate(DateTime date);
        Task<Loan> getLoanById(int id);
        Task post(DTO_Loaner loan);
        void updateLoan(Loan loan);
        Task<int> returnId(Loan loans);
        //Task<int> postNewLoan(DTO_Loaner loan);
        Loan postNewLoan(DTO_Loaner loan);
        Loan getLoanByUserId(string identityNumber);
        //void Put(Loan loans);
        Task<Loan> getLoanByUserIdForPayment(int id);
        Task<Loan> getLoanerByUserId(int userId);

    }
}
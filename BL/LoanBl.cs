//using AngleSharp.Io;
//using AngleSharp.Io;
using DL;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BL
{
    public class LoanBl : ILoanBl
    {
        ILoanDl _iLoanDl;
        public LoanBl(ILoanDl iLounDl)
        {
            _iLoanDl = iLounDl;
        }
        public async Task<Loan> getLoanById(int id)
        {
            return await _iLoanDl.getLoanById(id);
        }
        public async Task<int> returnId(Loan loan)
        {
            return await _iLoanDl.returnId(loan);
        }
        public Loan getLoanByUserId(string identityNumber)
        {
        return _iLoanDl.getLoanByUserId(identityNumber);
        }
        public async Task<Loan> getLoanByUserIdForPayment(int id)
        {
            return await _iLoanDl.getLoanByUserIdForPayment(id);
        }

        //public async Task<int> postNewLoan(DTO_Loaner loan)
        //{
        //    return await _iLoanDl.postNewLoan(loan);
        //}
        public Loan postNewLoan(DTO_Loaner loan)
        {
            return  _iLoanDl.postNewLoan(loan);
        }
        //public async Task<List<Loan>> getLoanList(string name)
        //{
        //    return await _iLoanDl.getLoanList(name);
        //}
        public Task<List<Loan>> getAllLoans()
        {
            return _iLoanDl.getAllLoans();
        }
        //public async Task<List<Loan>> getLoansByDate(DateTime date)
        //{
        //    return await _iLoanDl.getLoansByDate(date);
        //}
        public async Task post(DTO_Loaner loan)
        {
            //await _iLoanDl.post(loan);
        }

        public Task<List<Loan>> getAllLoans(DTO_LoansParams dTO_LoansParams)
        {
            return _iLoanDl.getAllLoans(dTO_LoansParams);
        }
        public void updateLoan(Loan loan)
        {
             _iLoanDl.updateLoan(loan);
        }
        public async Task<Loan> getLoanerByUserId(int userId)
        {
            return await _iLoanDl.getLoanerByUserId(userId);
        }
    }
}

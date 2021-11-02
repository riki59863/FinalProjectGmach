
using AutoMapper;
using DL;
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class paymentsBl:IpaymentsBl
    {
        IPaymentDl iPaymentsDl;
        ILoanDl iLoanDl;
        IWarningDl iWarningDl;
        IUserDl iuserDl;
        IUserBl iUserBl;
        IMapper _mapper;

        public paymentsBl(IPaymentDl _paymentsDl, ILoanDl _iLoandl, IWarningDl _iWarningDl,IUserDl _iuserDl, IMapper mapper)
        {
            iUserBl = iUserBl;
            iuserDl = _iuserDl;
            iWarningDl = _iWarningDl;
            iLoanDl = _iLoandl;
            iPaymentsDl = _paymentsDl;
            _mapper = mapper;
        }
        public async Task<List<Payment>> getAllPaymentsForLoan(int userId)
        {
            return await iPaymentsDl.getAllPaymentsForLoan(userId);
        }
        public async Task<List<Payment>> getAllPaymentsForLoanByUserIdAndLoanDate(int userId, DateTime loandate)
        {
            return await iPaymentsDl.getAllPaymentsForLoanByUserIdAndLoanDate(userId, loandate);
        }
        public async Task<int> postPayment(Payment payment)
        {
            DateTime date = DateTime.MinValue;
            int sum = 0;//to sum the all paments for loan
            List<Payment> paymentList = new List<Payment>();
            Loan l = await iLoanDl.getLoanByUserIdForPayment(payment.UserId);//the loan oh the payment
            Payment lastPayment = new Payment();
            paymentList = await getAllPaymentsForLoanByUserIdAndLoanDate(payment.UserId, l.Date);//get all the payments for loan
            if(paymentList ==null)
            {
                payment.Date = (DateTime)l.FirstRepaymentDate;
            }
            else
            {
                paymentList.ForEach(p =>
                {
                    if (DateTime.Compare(p.Date, date) > 0)//get the last payment to know the date of the payment
                    {
                        date = p.Date;
                        lastPayment = p;
                    }
                });
                //Payment p = await iPaymentsDl.getTheLastPayment(payment.UserId);//get the last payment to know the date of the payment
                payment.Date = lastPayment.Date.AddMonths(1);//add 1 month to the last payment
            }
            if (payment.Date<payment.InputDate)
            {
                payment.Comments+="התשלום נכנס באיחור ";
            }
            else if(payment.Date > payment.InputDate) 
            {
                payment.Comments += " התשלום נכנס לפני הזמן";
            }
            await iPaymentsDl.postPayment(payment);
            paymentList.ForEach(e =>
            {
                sum += e.Sum;
            });
            if ((sum+payment.Sum)==l.Sum)//the loan is finish
            {
                l.PaidUp = true;
                iLoanDl.updateLoan(l);
            }
            else if ((sum + payment.Sum) > l.Sum)
            {
                payment.Comments += "שולם יותר ממה שהיה צריך יש זכות ללוה בסך:  " + (l.Sum - sum);
                l.PaidUp = true;
                iLoanDl.updateLoan(l);
            }
            return l.Sum - sum -payment.Sum;
        }
        public async Task<List<Payment>> getAllPayments(DTO_PaymentParams dTO_PaymentParams)
        {
            return await iPaymentsDl.getAllPayments(dTO_PaymentParams);
        }
        public async Task<List<DTO_User>> getAllPaymentsThatWerentPadeByDate(DateTime paymentDate)
        {
            //User user;
            List<User> users = new List<User>();
            List<Payment> paymentList = new List<Payment>();
            List<Loan> loanListThatDidntPay = new List<Loan>();
            List<Loan> loanList = new List<Loan>();
            List<DTO_User> userListThatdidntPade = new List<DTO_User>();
            DTO_LoansParams dTO_LoansParams = new DTO_LoansParams();
            dTO_LoansParams.PaidUp = false;
            dTO_LoansParams.MonthlyPaymentDay = paymentDate.Day;

            DTO_PaymentParams dTO_PaymentParams = new DTO_PaymentParams();
            dTO_PaymentParams.dateExact = paymentDate;

            DTO_UserParams dTO_UserParams = new DTO_UserParams();
            loanList = await iLoanDl.getAllLoans(dTO_LoansParams);
            paymentList = await iPaymentsDl.getAllPayments(dTO_PaymentParams);
            users = await iuserDl.getAllUsers(dTO_UserParams);
            bool a = false;


            loanList.ForEach(loan =>
            {

                paymentList.ForEach(p =>
                {
                    if (p.UserId == loan.UserId)
                    {
                        a = true;
                    }
                });
                if (!a)
                {
                    loanListThatDidntPay.Add(loan);
                }
                a = false;
            });
            loanListThatDidntPay.ForEach(loan =>
            {
                users.ForEach(u =>
                {
                    if (u.Id == loan.UserId)
                    {
                        userListThatdidntPade.Add(_mapper.Map<User, DTO_User>(u));
                    }
                });
            });
            //List<DTO_User> u = _mapper.Map<List<User>, List<DTO_User>>(userListThatdidntPade);
            // return u;
            return userListThatdidntPade;
        }
        public async Task updatePayment(Payment updatedPayment)
        {
            await iPaymentsDl.updatePayment(updatedPayment);
        }
        //public async Task<List<Payment>> getPaymentsBydate(DateTime date)
        //{
        //    //(הלוואות שלא נפרעו והתאריך הוא אחרי תחילת התשלומים וזה באותו יום ההחזרה(20 או 1
        //    //List<Loan> loansList = await _loanDl.getLoansByDate(date);
        //    // מונה התשלומים
        //    var count = 0;
        //    //רשימה ריקה לתשלומים שאמורים להיכנס באותו יום
        //    List<Payment> pamymentsInSpecificDate = new List<Payment> { };
        //    //...ריצה על ההלוואות שלא נפרעו
        //    foreach (var l in loansList)
        //    {
        //        //רשימת התשלומים של בן אדם מסוים על פי קוד הלוואה

        //        //List<Payment> paymentsList = await _paymentsDl.getAllPaymentsForLoan(l.LoanCode);
        //        //foreach (var s in paymentsList)
        //        //{
        //        //    count++;
        //        //    if (s.PaymentDate == date)//אם זה תשלום שכבר שולם
        //        //    {
        //        //        pamymentsInSpecificDate.Add(s);//הוספה לרשימת התשלומים
        //        //    }
        //        //}
        //        //if (count < l.NumberOfPayments)//אם עדין לא נגמרו התשלומים
        //        //{
        //        //    Payment p = new Payment();//רשומה חדשה 
        //        //    p.LoanCode = l.LoanCode;
        //        //    p.PaymentDate = date;
        //        //    pamymentsInSpecificDate.Add(p);//הוספה לרשימת התשלומים
        //        //}
        //        ////else
        //        ////{
        //        ////    pamymentsInSpecificDate.Add(s);//צריך פתרון להכניס לרשימת התשלומים
        //        ////}
        //    }
        //    return pamymentsInSpecificDate;
        //}
        //public async Task<List<Payment>> getAllPaymentsThatWerentPade(string loanCode)
        //{
        //    int sum = 0, counter = 0;
        //    var loanD = await _loanDl.getLoanDetails(loanCode);
        //    var paymentsList = await _paymentsDl.getAllPaymentsForLoan(loanCode);
        //    foreach (var payment in paymentsList)
        //    {
        //        sum += payment.Sum;
        //        if (sum >= loanD.Sum || DateTime.Now < loanD.FirstPaymentDate)
        //            return null;
        //        counter++;
        //    }
        //    List<Payment> unPayedPamyments = new List<Payment> { };
        //    bool first = true;
        //    int a = 0;
        //    Payment p = new Payment();
        //    for (int i = 0; i < loanD.NumberOfPayments - counter; i++)
        //    {
        //        a++;
        //        if (first)
        //            p.PaymentDate = paymentsList[counter].PaymentDate.AddMonths(1);
        //        else
        //            p.PaymentDate = unPayedPamyments[a - 1].PaymentDate.AddMonths(1);
        //        //p.Sum = loanD.Sum / loanD.NumberOfPayments;
        //        //p.LoanCode = loanD.LoanCode;
        //        unPayedPamyments.Add(p);
        //    }
        //    return unPayedPamyments;
        //}
        //public async Task<List<>> getAllPaymentsThatWerentPadeYesturday(DateTime date)
        //{
        //    //List<Warning> warning = new List<Warning>;

        //    return await _iWarningDl.getWarningsForDate(date) ;
        //}  
    }
}

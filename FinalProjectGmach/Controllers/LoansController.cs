using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectGmach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        ILoanBl iLoanBl;
        IUserBl iUserBl;
        IGuarantyBl iGuarantyBl;
        IDirectDebitBl idirectDebit;


        public LoansController(ILoanBl _iLoanBl, IUserBl _iUserBl, IGuarantyBl _iGuarantyBl, IDirectDebitBl _idirectDebit)
        {
            iLoanBl = _iLoanBl;
            iUserBl = _iUserBl;
            iGuarantyBl = _iGuarantyBl;
            idirectDebit = _idirectDebit;
        }

        //// GET: api/<controller>
        //[HttpGet("{password}")]
        ////public async Task<List<Loan>> getLoanList(string password)
        ////{
        ////    return await iLoanBl.getLoanList(password);
        ////}
        

        [HttpPost]
        [Route("[action]")]
        public async void uploadShtar([FromForm] IFormFile file)
        {
            var loan = Request.Form["newLoaner"];
            //DTO_Loaner newloan = JsonConvert.DeserializeObject<DTO_Loaner>(loan);
            JObject jObject = JObject.Parse(loan);
            JToken jUser = jObject["user"];
            JToken jLoan = jObject["loaner"];
            JToken jDD = jObject["directDebit"];
            JToken[] jGuaranty = jObject["guaranty"].ToArray();
            DTO_Loaner newloan = new DTO_Loaner();
            List<Guarnty> guarantyList = new List<Guarnty>();
            int i = 0;
            int userId;
            foreach (JToken g in jGuaranty)//cast guaranty list
            {
                if (g.SelectToken("firstName").ToString() != null && g.SelectToken("firstName").ToString() != "")
                {
                    User s = g.ToObject<User>();
                    newloan.usersAsGuarntys.Add(s);
                    Guarnty gurantyForList = new Guarnty();
                    gurantyForList.Comments = newloan.usersAsGuarntys[i].Comments;
                    guarantyList.Add(gurantyForList);
                }
            }
            newloan.user = jUser.ToObject<User>();
            if (jDD.SelectToken("numberAccount").ToString() != "" )
            {
                jDD.ToObject<DirectDebit>().Active = true;
                newloan.directDebit = jDD.ToObject<DirectDebit>();
            }
            int j = 0;
            foreach (User u in newloan.usersAsGuarntys)//post the users of the guranties
            {
                User existUserForGuaranty =  iUserBl.getUserByIdentity(u.IdentityNumber);//check if the user is exist
                if (existUserForGuaranty == null)
                {
                    User user = new User();
                    user = u;
                    int userid = await iUserBl.addUser(user);
                    guarantyList[j].UserId = userid;
                    j++;
                }
                else
                {
                    guarantyList[j].User = existUserForGuaranty;
                    j++;
                }
            }
            User existUserForLoan =  iUserBl.getUserByIdentity(newloan.user.IdentityNumber);//check if the user is exist
            if (existUserForLoan == null)
                userId = await iUserBl.addUser(newloan.user);//post user
            else
                userId = existUserForLoan.Id; jLoan["userId"] = userId;
            jLoan["paidUp"] = 0;
            jLoan["repaymentManner"] = 0;
            jLoan["id"] = 0;//probbly need to change
            jLoan["guarantyId1"] = 0;
            jLoan["guarantyId2"] = 0;
            jLoan["guarantyId3"] = 0;//all the guarantys -need a loop
            jLoan["guarantyId4"] = 0;
            jLoan["guarantyId5"] = 0;
            
            Loan loanO = jLoan.ToObject<Loan>();
            newloan.loan = loanO;
            //loanO.UserId = userId;
            //newloan.loan.UserId = userId;
            int count = 1;
            foreach (Guarnty guarnty in guarantyList)//post the guaranty
            {
                //int gurantId = iGuarantyBl.addGuaranty(guarnty);
                //guarnty.Id = gurantId;
                if (count == 1)
                    newloan.loan.GuarantyId1Navigation=guarnty;
                else if (count == 2)
                    newloan.loan.GuarantyId2Navigation = guarnty;
                else if (count == 3)
                    newloan.loan.GuarantyId3Navigation = guarnty;
                else if (count == 4)
                    newloan.loan.GuarantyId4Navigation = guarnty;
                else if (count == 5)
                    newloan.loan.GuarantyId5Navigation = guarnty;
                count++;
            }
            if (newloan.loan.GuarantyId1 == 0)
            {
                newloan.loan.GuarantyId1 = null;
            }
            if (newloan.loan.GuarantyId2 == 0)
            {
                newloan.loan.GuarantyId2 = null;
            }
            if (newloan.loan.GuarantyId3 == 0)
            {
                newloan.loan.GuarantyId3 = null;
            }
            if (newloan.loan.GuarantyId4 == 0)
            {
                newloan.loan.GuarantyId4 = null;
            }
            if (newloan.loan.GuarantyId5 == 0)
            {
                newloan.loan.GuarantyId5 = null;
            }
            if (newloan.directDebit != null)//post dd
            {
                newloan.directDebit.UserId = userId;
                await idirectDebit.post(newloan.directDebit);
            }
            //int id = await iLoanBl.postNewLoan(newloan);//post loan
            Loan l =  iLoanBl.postNewLoan(newloan);//post loan
            newloan.loan = l;
            string path = "C:\\Users\\This_User\\Desktop\\PATH\\";
            //C: \Users\This_User\Desktop\24.09\10 - 09\src\assets\shtar
            file.CopyTo(System.IO.File.Create(path + l.Id+".jpg"));
            var newPath = path + l.Id + ".JPG";
            newloan.loan.Shtar = newPath;
            //await iLoanBl.updateLoan(newloan.loan);//add to the loan the scaned shtar
             iLoanBl.updateLoan(newloan.loan);//add to the loan the scaned shtar
        }
        // GET api/<controller>/5
        [HttpGet]
        public Task<List<Loan>> getAllLoans()
        {
            return iLoanBl.getAllLoans();
        }
        [HttpGet("{id}")]
        public async Task<Loan> getLoanById(int id)
        {
            return await iLoanBl.getLoanById(id);
        }
        [Route("checkIfUserHasLoan/{userId}")]
        [HttpGet]
        public async Task<Loan> checkIfUserHasLoan(int userId)
        {
            return await iLoanBl.getLoanByUserIdForPayment(userId);
        }
        [Route("getLoanByUserId/{userId}")]
        [HttpGet]
        public async Task<Loan> getLoanByUserId(int userId)
        {
            return await iLoanBl.getLoanerByUserId(userId);
        }
        // POST api/<controller>
        [HttpPost("loan")]
        public async Task post(DTO_Loaner loan)
        {
            await iLoanBl.post(loan);
        }
        [HttpPost]
        public async Task<List<Loan>> getAllLoans([FromBody] DTO_LoansParams dTO_LoansParams)
        {
            return await iLoanBl.getAllLoans(dTO_LoansParams);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void updateLoan(Loan loan)
        {
             iLoanBl.updateLoan(loan);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

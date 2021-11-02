using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BL;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectGmach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IpaymentsBl ipaymentsBl;
        public PaymentsController(IpaymentsBl ipaymentsBl)
        {
            this.ipaymentsBl = ipaymentsBl;
        }
        // GET: api/<controller>



        ////[Route("[action]/{loanCode}")]
        //[HttpGet("{userId}/{paymentId}")]
        //public async Task<List<Payment>> getAllPaymentsForLoan(int userId, int paymentId)
        //{
        //    return await ipaymentsBl.getAllPaymentsForLoan(userId,paymentId);
        //}

        //[HttpGet("{paymentDate}")]
        [Route("[action]")]
        [HttpGet]
        public async Task<List<DTO_User>> getAllPaymentsThatWerentPadeByDate(DateTime paymentDay)
        
        {
            return await ipaymentsBl.getAllPaymentsThatWerentPadeByDate(paymentDay);
        }

        //[Route("[action]/{dTO_PaymentParams}")]
        //[HttpGet]
        //public async Task<List<Payment>> getAllPayments([FromQuery]DTO_PaymentParams dTO_PaymentParams)
        //{
        //    return await ipaymentsBl.getAllPayments(dTO_PaymentParams);
        //}
        // POST api/<controller>
        [HttpPost]
        public async Task<List<Payment>> getAllPayments([FromBody]DTO_PaymentParams dTO_PaymentParams)
        {
            return await ipaymentsBl.getAllPayments(dTO_PaymentParams);
        }
        [HttpPost("newPayment")]
        public async Task<int> postPayment([FromBody] Payment payment)
        {
            return await ipaymentsBl.postPayment(payment);
        }
        // PUT api/<controller>/5
        [HttpPut]
        public async Task updatePayment(Payment updatedPayment)
        {
            await ipaymentsBl.updatePayment(updatedPayment);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

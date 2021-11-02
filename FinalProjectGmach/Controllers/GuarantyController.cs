using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectGmach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuarantyController : ControllerBase
    {
        IGuarantyBl iGuarantyBl;

        public GuarantyController(IGuarantyBl _iGuarantyBl)
        {
            iGuarantyBl = _iGuarantyBl;
        }

        // GET api/<controller>/5
        //[HttpGet]
        //public async Task<List<Guarnty>> getallGuaranteeForLoan()
        //{
        //    return await iGuarantyBl.getallGuaranties();
        //}
        [HttpGet]
        public async Task<List<Guarnty>> getGuarantiesForLoan(int[] guarantiesId)
        {
            return await iGuarantyBl.getGuarantiesForLoan(guarantiesId);
        }

        // POST api/<controller>
        [HttpPost]
        public  int addGuaranty(Guarnty guaranteeForLoan)
        {
           return  iGuarantyBl.addGuaranty(guaranteeForLoan);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

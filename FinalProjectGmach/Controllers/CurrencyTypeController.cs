using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectGmach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        public ICurrencyTypeBl currencyTypeBl;

        public CurrencyTypeController(ICurrencyTypeBl _currencyTypeBl)
        {
            currencyTypeBl = _currencyTypeBl;
        }
        [HttpGet]
        public API_Obj getExchangeRate()
        {
            return currencyTypeBl.getExchangeRate();
        }
        [HttpGet("{id}")]
        public async Task<CurrencyType> getCurrencyById(int id)
        {
            return await currencyTypeBl.getCurrencyById(id);
        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
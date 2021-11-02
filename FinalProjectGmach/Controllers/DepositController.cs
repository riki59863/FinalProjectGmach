using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectGmach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        public IDepositsBl iDepositsBl;

        public DepositController(IDepositsBl _iDepositsBl)
        {
            iDepositsBl = _iDepositsBl;
        }

        //// GET: api/<controller>
        //[HttpGet("{name}")]
        //public async Task<List<Deposits>> getDepositsList(string name)
        //{
        //    return await iDepositsBl.getDepositsList(name);
        //}

        [HttpGet]
        public async Task<List<Deposits>> getAllDeposits()
        {
            return await iDepositsBl.getAllDeposits();
        }

        [HttpGet ("{depositId}")]
        public async Task<Deposits> getDepositById(int depositId)
        {
            return await iDepositsBl.getDepositById(depositId);
        }
        [Route("getDepositByUserId/{userId}")]
        [HttpGet]
        public async Task<Deposits> getDepositByUserId(int userId)
        {
            return await iDepositsBl.getDepositByUserId(userId);
        }
        // POST api/<controller>
        [HttpPost]
        public async Task addNewDeposite([FromBody] Deposits deposit)
        {
             await iDepositsBl.addNewDeposite(deposit);
        }
        // PUT api/<controller>/5
        //[HttpPut]
        //public async void updateDeposit(DepositAccounts depositAccounts, User user)
        //{
        //    await _idepositAccountBl.updateDeposit(depositAccounts, user);
        //}
        [HttpPut]
        public async Task updateDeposite(Deposits updatedDeposit)
        {
            await iDepositsBl.updateDeposit(updatedDeposit);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

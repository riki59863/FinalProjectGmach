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
    public class LoginController : ControllerBase
    {
        ILoginBl _iLoginBl;
       
        public LoginController(ILoginBl iLoginBL)
        {
            _iLoginBl = iLoginBL;
        }
        //[HttpGet/*("{id}")*/]
        //public async Task<User> getUser([FromQuery]string password, [FromQuery]string userName)
        //{
        //    return await _iLoginBl.getUser(password, userName);
        //}

        // POST api/<controller>
        [HttpPost]
        public async void addUser([FromBody]User user)
        {
             await _iLoginBl.addUser(user);
        }

        // PUT api/<controller>/5
        [HttpPut("{userId}")]
        //public async void Put([FromBody]int id)
        //{
        //     await _iLoginBl.updateuser(id);

        //}

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async void Delete(User user)
        {
             await _iLoginBl.deleteUser(user);
        }
    }
}

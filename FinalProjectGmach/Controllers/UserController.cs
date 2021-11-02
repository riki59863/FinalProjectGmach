using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserController : ControllerBase
    {
        IUserBl _iUserBl;

        public UserController(IUserBl _iUserBl)
        {
            this._iUserBl = _iUserBl;
        }
        //[HttpGet]
        //public async Task<List<User>> getAllUsers(DTO_UserParams dTO_UserParams)
        //{
        //    return await _iUserBl.getAllusers(dTO_UserParams);

        //}

        [HttpGet("{userId}")]
        public async Task<User> getUserById(int userId)
        {
            return await _iUserBl.getUserById(userId);
        }

        // GET: api/<controller>
        //[HttpGet("{code}/{accessName}")]
        //public async Task<User> getUser([FromQuery] string code, [FromQuery] string accessName)
        //{
        //    return _iUserBl.getUser(code, accessName);
        //}

        // POST api/<controller>
        //[HttpPost]
        //public async void addUser([FromBody]User user)
        //{
        //    await _iUserBl.addUser(user);
        //}
        [HttpPost]
        public async Task<List<User>> getAllUsers([FromBody] DTO_UserParams dTO_UserParams)
        {
            return await _iUserBl.getAllUsers(dTO_UserParams);
        }
        [HttpPost("newUser")]
        public async Task<int> newUser([FromBody] User user)
        {
            return await _iUserBl.addUser(user);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<User> updateUser(User userToUpdate)
        {
           return await _iUserBl.updateuser(userToUpdate);
        }

        // DELETE api/<controller>/5

        [HttpDelete("{userId}")]
        public async Task<User> Delete(int userId)
        {
            return await _iUserBl.deleteUser(userId);
        }
        [Route("getAddress/{str}")]
        [HttpGet]
        public List<string> getAddress(string str)
        {
            return _iUserBl.getAddress(str);
        }

        [Route("getUserByIdentityNumber/{identityNumber}")]
        [HttpGet]
        public async Task<User> getUserByIdentityNumber(string identityNumber)
        {
            return await _iUserBl.getUserByIdentityNumber(identityNumber);
        }
    }
}

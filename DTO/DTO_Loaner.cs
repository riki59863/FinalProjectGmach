using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Loaner
    {
        public Loan loan;
        public User user;
        public List<User> usersAsGuarntys = new List<User>();
        public DirectDebit directDebit;

    }
}

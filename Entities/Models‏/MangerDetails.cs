using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class MangerDetails
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}

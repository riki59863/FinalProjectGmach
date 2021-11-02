using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_UserParams
    {
        public int ?Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? CellphoneNumber { get; set; }
        public string? Email { get; set; }
        public string? IdentityNumber { get; set; }

    }
}

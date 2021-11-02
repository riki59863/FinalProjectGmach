using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_LoansParams
    {
        public int? sumFrom { get; set; }
        public int? sumTill { get; set; }
        public int? sumExact { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTill { get; set; }
        public DateTime? dateExact { get; set; } 
        public DateTime? RepaymentDate { get; set; }
        public DateTime? LoanDate { get; set; }
        public int? MonthlyPaymentDay { get; set; }

        public bool? PaidUp { get; set; }

    }
}

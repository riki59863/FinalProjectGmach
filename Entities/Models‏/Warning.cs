using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Warning
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public DateTime WarningDate { get; set; }

        public virtual Loan Loan { get; set; }
    }
}

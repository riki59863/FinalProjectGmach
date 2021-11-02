using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Banks
    {
        public Banks()
        {
            DirectDebit = new HashSet<DirectDebit>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<DirectDebit> DirectDebit { get; set; }
    }
}

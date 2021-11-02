using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Method { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}

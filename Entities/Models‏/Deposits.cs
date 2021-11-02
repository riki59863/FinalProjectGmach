using System;
using System.Collections.Generic;

namespace Entities.Models‏
{
    public partial class Deposits
    {
        public Deposits()
        {
            UserNavigation = new HashSet<User>();
        }

        public int Id { get; set; }
        public int Sum { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public string HebrewDate { get; set; }
        public string HebrewReturnDate { get; set; }
        public int? DirectDebitId { get; set; }
        public int? CreditCardId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual CurrencyType Currency { get; set; }
        public virtual DirectDebit DirectDebit { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<User> UserNavigation { get; set; }
    }
}

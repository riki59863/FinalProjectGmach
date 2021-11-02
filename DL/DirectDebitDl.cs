using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DirectDebitDl : IDirectDebitDl
    {
        gmach1112020Context gmachContext;

        public DirectDebitDl(gmach1112020Context _gmachContext)
        {
            gmachContext = _gmachContext;
        }

        public async Task post(DirectDebit directDebit)
        {
            gmachContext.DirectDebit.AddAsync(directDebit);
            gmachContext.SaveChangesAsync();
        }
    }
}

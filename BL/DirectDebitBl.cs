using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DirectDebitBl : IDirectDebitBl
    {

        IDirectDebitDl iDrectDebitDl;

        public DirectDebitBl(IDirectDebitDl _iDrectDebitDl)
        {
            iDrectDebitDl = _iDrectDebitDl;
        }

        public async Task post(DirectDebit directDebit)
        {
            await iDrectDebitDl.post(directDebit);
        }
    }
}

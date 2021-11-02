using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDirectDebitDl
    {
        Task post(DirectDebit directDebit);
    }
}

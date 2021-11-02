using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ICurrencyTypeDl
    {
        Task<List<CurrencyType>> getAllCurrencyType();
        Task<CurrencyType> getCurrencyById(int id);
        API_Obj getExchangeRate();
    }
}

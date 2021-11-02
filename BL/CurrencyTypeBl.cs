using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CurrencyTypeBl : ICurrencyTypeBl
    {
        ICurrencyTypeDl currencyTypeDl;

        public CurrencyTypeBl(ICurrencyTypeDl _currencyTypeDl)
        {
            currencyTypeDl = _currencyTypeDl;
        }
        public async Task<List<CurrencyType>> getAllCurrencyType()
        {
            return await currencyTypeDl.getAllCurrencyType();
        }
        public async Task<CurrencyType> getCurrencyById(int id)
        {
            return await currencyTypeDl.getCurrencyById(id);
        }
        public API_Obj getExchangeRate()
        {
            return currencyTypeDl.getExchangeRate();
        }
    }
}

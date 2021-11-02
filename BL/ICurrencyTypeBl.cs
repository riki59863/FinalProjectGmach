using DL;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICurrencyTypeBl
    {
        Task<List<CurrencyType>> getAllCurrencyType();
        Task<CurrencyType> getCurrencyById(int id);
        API_Obj getExchangeRate();
    }
}
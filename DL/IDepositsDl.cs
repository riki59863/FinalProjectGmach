using DTO;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DL
{
    public interface IDepositsDl
    {
        //Task<List<Deposits>> getDepositsList(string name);
        Task post(Deposits deposit);
        Task<List<Deposits>> getAllDeposits();
        Task updateDeposit(Deposits updatedDeposit);
        Task<Deposits> getDepositById(int depositId);
        Task addNewDeposite(Deposits deposit);
        Task<Deposits> getDepositByUserId(int userId);

    }
}
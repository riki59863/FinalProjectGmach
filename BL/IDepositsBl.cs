using DTO;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IDepositsBl
    {
        //public Task<List<Deposits>> getDepositsList(string name);
        Task<List<Deposits>> getAllDeposits();
        Task<Deposits> getDepositById(int depositId);
        Task updateDeposit(Deposits updatedDeposit);
        Task addNewDeposite(Deposits deposit);
        Task<Deposits> getDepositByUserId(int userId);

    }
}
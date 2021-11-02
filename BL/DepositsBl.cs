using DL;
using DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DepositsBl : IDepositsBl
    {
        public IDepositsDl iDepositsDl;

        public DepositsBl(IDepositsDl iDepositAccountsDl)
        {
            iDepositsDl = iDepositAccountsDl;
        }
       

        //public async Task<List<Deposits>> getDepositsList(string name)
        //{
        //    return await _idepositAccountDl.getDepositsList(name);

        //}
        public async Task<List<Deposits>> getAllDeposits()
        {
            return await iDepositsDl.getAllDeposits();
        }
        public async Task updateDeposit(Deposits updatedDeposit)
        {
           await iDepositsDl.updateDeposit(updatedDeposit);
        }
        public async Task<Deposits> getDepositById(int depositId)
        {
            return await iDepositsDl.getDepositById(depositId);
        }
        public async Task addNewDeposite(Deposits deposit)
        {
            await iDepositsDl.addNewDeposite(deposit);
        }
        public async Task<Deposits> getDepositByUserId(int userId)
        {
            return await iDepositsDl.getDepositByUserId(userId);
        }
    }
}

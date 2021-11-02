

using DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DepositsDl : IDepositsDl
    {
        gmach1112020Context gmachContext;

        public DepositsDl(gmach1112020Context _gmachContext)
        {
            gmachContext = _gmachContext;
        }

        //public async Task<List<Deposits>> getDepositsList(string name)
        //{
        //    return await gmachContext.Deposits.Where(u => u.DepositorName == name).ToListAsync();
        //}

        public async Task<Deposits> getDepositById(int depositId)
        {
            return await gmachContext.Deposits.Where(x=>x.Id==depositId).FirstOrDefaultAsync();
        }

        public async Task post(Deposits deposit)
        {
            await gmachContext.Deposits.AddAsync(deposit);
            await gmachContext.SaveChangesAsync();
        }
        public async Task<List<Deposits>> getAllDeposits()
        {
            return await gmachContext.Deposits.ToListAsync();
        }
        public async Task updateDeposit(Deposits updatedDeposit)
        {
            var depositeToUpdate = await gmachContext.Deposits.Where(d => d.Id == updatedDeposit.Id).FirstOrDefaultAsync();
            gmachContext.Entry(depositeToUpdate).CurrentValues.SetValues(updatedDeposit);
            gmachContext.SaveChanges();
        }
        public async Task addNewDeposite(Deposits deposit)
        {
            await gmachContext.Deposits.AddAsync(deposit);
            await gmachContext.SaveChangesAsync();
        }
        public async Task<Deposits> getDepositByUserId(int userId)
        {
            return await gmachContext.Deposits.Where(d => d.UserId == userId).FirstOrDefaultAsync();
        }
    }
}

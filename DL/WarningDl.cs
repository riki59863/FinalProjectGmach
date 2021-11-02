
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class WarningDl:IWarningDl
    {
        gmach1112020Context gmachContext;
        public WarningDl(gmach1112020Context _gmachContext)
        {
            gmachContext = _gmachContext;
        }
        public async Task<List<Warning>> getWarningsForDate(DateTime date)
        {
            return await gmachContext.Warning.Where(u => u.WarningDate == date).ToListAsync();
        }
        //public async Task<List<Warning>> geAlertList(string name)
        //{
        //    return await gmachContext.Warning.Where(u => u.u == name).ToListAsync();

        //}
    }
}

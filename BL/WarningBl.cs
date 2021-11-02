using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WarningBl : IWarningBl
    {
        IWarningDl iWarningDl;
        public WarningBl(IWarningDl warningDl)
        {
            this.iWarningDl = warningDl;
        }
        public async Task<List<Warning>> getWarningsForDate(DateTime date)
        {
            return await iWarningDl.getWarningsForDate(date);
        }
        //public async Task<List<Warning>> getAlertList(string name)
        //{
        //    return await iWarningDl.geAlertList(name);
        //}
    }
}

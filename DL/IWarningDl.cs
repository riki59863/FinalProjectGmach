
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IWarningDl
    {
        Task<List<Warning>> getWarningsForDate(DateTime date);
        //Task<List<Warning>> geAlertList(string name);
    }
}

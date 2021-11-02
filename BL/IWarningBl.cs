
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IWarningBl
    {
        //Task<List<Warning>> getAlertList(string name);

        Task<List<Warning>> getWarningsForDate(DateTime date);
    }
}

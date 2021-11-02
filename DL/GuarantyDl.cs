using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class GuarantyDl : IGuarantyDl
    {
        gmach1112020Context gmachContext;
        ILoanDl iloanDl;

        public GuarantyDl(gmach1112020Context _gmachContext, ILoanDl iloanDl)
        {
            gmachContext = _gmachContext;
            this.iloanDl = iloanDl;
        }

        public async Task<List<Guarnty>> getallGuaranteeForLoan()
        {
            return await gmachContext.Guarnty.ToListAsync();
        }
        public async Task<List<Guarnty>> getGuarantiesForLoan(int[] guarantiesId)
        {
            List<Guarnty> guarantiesList = new List<Guarnty>();
            Guarnty guaranty = new Guarnty();
            for (int i = 0; i < guarantiesId.Length; i++)
            {
                guaranty = await gmachContext.Guarnty.Where(x => x.Id == guarantiesId[i])
                .FirstOrDefaultAsync();
                guarantiesList.Add(guaranty);
            }
            
            return guarantiesList;
        }
        public  Guarnty getGuarantyByUserId(int guarantyId)
        {
            return  gmachContext.Guarnty.Where(x => x.UserId == guarantyId).FirstOrDefault();
        }
        public int addGuaranty(Guarnty guaranteeForLoan)
        {
             gmachContext.Guarnty.Add(guaranteeForLoan);
             gmachContext.SaveChanges();
            Guarnty g =  getGuarantyByUserId(guaranteeForLoan.UserId);
            return g.Id;
        }

        //public async Task<List<Loans>> getloansListThatSurety(string name)
        //{
        //    var loanlist = iloanDl.getAllLoans();
        //    var gurList = await gemach_serverContext.GuaranteeForLoan.Where(u => u.GuaranteerName == name).ToListAsync();
        //    foreach (var )      
        //    return gurList;
        //}
    }
}

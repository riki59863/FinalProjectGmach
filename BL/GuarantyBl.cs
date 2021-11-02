using DL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GuarantyBl : IGuarantyBl
    {
        IGuarantyDl iGuarantyDl;
        public GuarantyBl(IGuarantyDl _iGuarantyDl)
        {
            this.iGuarantyDl = _iGuarantyDl;
        }
        public async Task<List<Guarnty>> getGuarantiesForLoan(int[] guarantiesId)
        {
            return await this.iGuarantyDl.getGuarantiesForLoan(guarantiesId);
        }

        public async Task<List<Guarnty>> getallGuaranteeForLoan()
        {
            return await iGuarantyDl.getallGuaranteeForLoan();
        }
        public  int addGuaranty(Guarnty guarnty)
        {
          return   iGuarantyDl.addGuaranty(guarnty);
        }
    }
}

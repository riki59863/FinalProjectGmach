﻿using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IGuarantyDl
    {
        Task<List<Guarnty>> getallGuaranteeForLoan();
        Task<List<Guarnty>> getGuarantiesForLoan(int[] guarantiesId);
        int addGuaranty(Guarnty guaranteeForLoan);
    }
}
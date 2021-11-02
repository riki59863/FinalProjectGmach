using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IGuarantyBl
    {
        Task<List<Guarnty>> getallGuaranteeForLoan();
        Task<List<Guarnty>> getGuarantiesForLoan(int[] guarantiesId);
        int addGuaranty(Guarnty guarnty);
    }
}
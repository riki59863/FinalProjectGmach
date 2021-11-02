using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_PaymentParams
    {
        public int? CollectionSumFrom { get; set; }
        public int? CollectionSumTill { get; set; }
        public int? CollectionSumExact { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTill { get; set; }
        public DateTime? dateExact { get; set; }

    }
}



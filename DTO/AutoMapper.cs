using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, DTO_User>();
            CreateMap<Loan, DTO_Loan>();
            CreateMap<DTO_User, User>();
        }
    }
}

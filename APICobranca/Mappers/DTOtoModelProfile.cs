using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICobranca.Mappers
{
    public class DTOtoModelProfile : Profile
    {
        public DTOtoModelProfile()
        {
            CreateMap<DTOs.User, DB.User>();
            CreateMap<DTOs.Debit, DB.Debit>();
        }
    }
}
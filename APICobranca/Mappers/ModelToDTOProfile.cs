using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICobranca.Mappers
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<DB.User, DTOs.User>();
            CreateMap<DB.Debit, DTOs.Debit>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace APICobranca.Mappers
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ModelToDTOProfile>();
                x.AddProfile<DTOtoModelProfile>();
            });
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

          CreateMap<data.CategoriaProductos, DataModels.Course>().ReverseMap();

        
        }
    }
}

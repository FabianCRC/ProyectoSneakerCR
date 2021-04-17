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

            CreateMap<data.CategoriaProductos, DataModels.CategoriaProductos>().ReverseMap();
            CreateMap<data.CorreoTienda, DataModels.CorreoTienda>().ReverseMap();
            CreateMap<data.MarcaProductos, DataModels.MarcaProductos>().ReverseMap();
            CreateMap<data.Productos, DataModels.Productos>().ReverseMap();
            CreateMap<data.TelefonoTienda, DataModels.TelefonoTienda>().ReverseMap();
            CreateMap<data.Tiendas, DataModels.Tiendas>().ReverseMap();
            CreateMap<data.UbicacionTienda, DataModels.UbicacionTienda>().ReverseMap();
            CreateMap<data.AspNetUsers, DataModels.AspNetUsers>().ReverseMap();
            CreateMap<data.UsuarioTienda, DataModels.UsuarioTienda>().ReverseMap();
            CreateMap<data.ValoracionTienda, DataModels.ValoracionTienda>().ReverseMap();



        }
    }
}

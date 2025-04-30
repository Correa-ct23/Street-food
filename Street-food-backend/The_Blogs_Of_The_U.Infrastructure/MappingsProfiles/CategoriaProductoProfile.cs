using AutoMapper;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class CategoriaProductoProfile : Profile
    {
        public CategoriaProductoProfile()
        {
            CreateMap<CategoriaProducto, CategoriaProductoDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NOMBRE, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.DESCRIPCION, opt => opt.MapFrom(src => src.Descripcion))
                .ReverseMap();
        }
    }
}
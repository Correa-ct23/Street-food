using AutoMapper;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NOMBRE, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.DESCRIPCION, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.PRECIO, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.DISPONIBLE, opt => opt.MapFrom(src => src.Disponible))
                .ForMember(dest => dest.CATEGORIA_ID, opt => opt.MapFrom(src => src.CategoriaId))
                .ForMember(dest => dest.TIEMPO_PREPARACION, opt => opt.MapFrom(src => src.TiempoPreparacion))
                .ReverseMap();
        }
    }
}
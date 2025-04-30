using AutoMapper;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class DetallePedidoProfile : Profile
    {
        public DetallePedidoProfile()
        {
            CreateMap<DetallePedido, DetallePedidoDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PEDIDO_ID, opt => opt.MapFrom(src => src.PedidoId))
                .ForMember(dest => dest.PRODUCTO_ID, opt => opt.MapFrom(src => src.ProductoId))
                .ForMember(dest => dest.CANTIDAD, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.PRECIO_UNITARIO, opt => opt.MapFrom(src => src.PrecioUnitario))
                .ForMember(dest => dest.SUBTOTAL, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.OBSERVACIONES, opt => opt.MapFrom(src => src.Observaciones))
                .ReverseMap();
        }
    }
}
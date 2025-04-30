using AutoMapper;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CLIENTE_ID, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.FECHA_HORA, opt => opt.MapFrom(src => src.FechaHora))
                .ForMember(dest => dest.ESTADO, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.TOTAL, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.COCINERO_ID, opt => opt.MapFrom(src => src.CocineroId))
                .ForMember(dest => dest.DOMICILIARIO_ID, opt => opt.MapFrom(src => src.DomiciliarioId))
                .ForMember(dest => dest.INSTRUCCIONES, opt => opt.MapFrom(src => src.Instrucciones))
                .ReverseMap();
        }
    }
}
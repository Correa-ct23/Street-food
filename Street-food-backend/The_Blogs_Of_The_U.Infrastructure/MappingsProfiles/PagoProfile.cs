using AutoMapper;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class PagoProfile : Profile
    {
        public PagoProfile()
        {
            CreateMap<Pago, PagoDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PEDIDO_ID, opt => opt.MapFrom(src => src.PedidoId))
                .ForMember(dest => dest.METODO_PAGO_ID, opt => opt.MapFrom(src => src.MetodoPagoId))
                .ForMember(dest => dest.MONTO, opt => opt.MapFrom(src => src.Monto))
                .ForMember(dest => dest.FECHA_PAGO, opt => opt.MapFrom(src => src.FechaPago))
                .ForMember(dest => dest.ESTADO, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.TRANSACCION_ID, opt => opt.MapFrom(src => src.TransaccionId))
                .ReverseMap();
        }
    }
}
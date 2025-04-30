using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Core.Ports;
using The_Blogs_Of_The_U.Domain.Entities;

namespace The_Blogs_Of_The_U.Domain.Services
{
    [DomainService]
    public class PagoService
    {
        private readonly IMySqlRepositoryClient _repository;
        private readonly IMapper _mapper;

        public PagoService(IMySqlRepositoryClient repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MetodoPago>> GetAllMetodosPago()
        {
            try
            {
                return await _repository.GetAllMetodosPago();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener métodos de pago: {ex.Message}");
            }
        }

        public async Task<bool> CreatePago(Pago pago)
        {
            if (pago.PedidoId <= 0 || pago.MetodoPagoId <= 0)
                throw new ArgumentException("IDs no válidos");

            if (pago.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero");

            return await _repository.CreatePago(pago);
        }
    }
}

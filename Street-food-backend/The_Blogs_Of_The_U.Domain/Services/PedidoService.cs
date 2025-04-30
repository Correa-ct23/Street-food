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
    public class PedidoService
    {
        private readonly IMySqlRepositoryClient _repository;
        private readonly IMapper _mapper;

        public PedidoService(IMySqlRepositoryClient repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            try
            {
                return await _repository.GetAllPedidos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedidos: {ex.Message}");
            }
        }

        public async Task<int> CreatePedido(Pedido pedido)
        {
            if (pedido.ClienteId <= 0)
                throw new ArgumentException("ClienteId no válido");

            if (pedido.Total <= 0)
                throw new ArgumentException("El total debe ser mayor que cero");

            return await _repository.CreatePedido(pedido);
        }

        public async Task<bool> AddDetallePedido(DetallePedido detalle)
        {
            if (detalle.PedidoId <= 0 || detalle.ProductoId <= 0)
                throw new ArgumentException("IDs no válidos");

            if (detalle.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero");

            return await _repository.CreateDetallePedido(detalle);
        }
    }

}

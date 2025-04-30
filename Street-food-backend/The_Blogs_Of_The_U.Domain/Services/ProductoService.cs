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
    // ProductoService.cs
    [DomainService]
    public class ProductoService
    {
        private readonly IMySqlRepositoryClient _repository;
        private readonly IMapper _mapper;

        public ProductoService(IMySqlRepositoryClient repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            try
            {
                return await _repository.GetAllProductos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos: {ex.Message}");
            }
        }

        public async Task<bool> CreateProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es requerido");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero");

            return await _repository.CreateProducto(producto);
        }
    }
}

using The_Blogs_Of_The_U.Domain.Entities;

namespace The_Blogs_Of_The_U.Domain.Core.Ports
{
    public interface IMySqlRepositoryClient
    {
        Task<Users> ValidateUserAccess(UserAcces userAcces);
        Task<UserAcces> GetUserAcces(string email);
        Task<List<Sections>> GetAllSections();

        Task<List<Producto>> GetAllProductos();
        Task<List<Roles>> GetAllRoles();

        Task<bool> CreateRole(Roles role);
        Task<Roles> GetRolUser(string userEmail);
        Task<List<Users>> GetAllUsers();

        Task<bool> SetPassword(string password, string email);

        Task<bool> CreateSection(Sections sections);
        Task<int> CreateUsers(Users users);

        Task<int> CreateUserAccess(UserAcces userAcces);

        Task<string> getParameters(string name);
        Task<bool> CreateProducto(Producto producto);
        Task<List<Pedido>> GetAllPedidos();
        Task<int> CreatePedido(Pedido pedido);
        Task<bool> CreateDetallePedido(DetallePedido detalle);
        Task<List<MetodoPago>> GetAllMetodosPago();
        Task<bool> CreatePago(Pago pago);
    }
}
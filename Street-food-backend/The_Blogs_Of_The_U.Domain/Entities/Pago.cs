using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Domain.Entities
{
    public class Pago
    {
        public int? Id { get; set; }
        public int PedidoId { get; set; }
        public int MetodoPagoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; } // "Pendiente", "Completado", etc.
        public string TransaccionId { get; set; }
    }
}

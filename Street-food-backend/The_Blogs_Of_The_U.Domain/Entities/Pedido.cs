using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Domain.Entities
{
    public class Pedido
    {
        public int? Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } // "Recibido", "En preparación", etc.
        public decimal Total { get; set; }
        public int? CocineroId { get; set; }
        public int? DomiciliarioId { get; set; }
        public string Instrucciones { get; set; }
    }
}

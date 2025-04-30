using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class ProductoDto
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public bool DISPONIBLE { get; set; }
        public int CATEGORIA_ID { get; set; }
        public int TIEMPO_PREPARACION { get; set; }
    }
}

using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Jamaica : Alimento
    {
        public Jamaica(List<IngredienteAlimento> ingredientes) : base("Agua de Jamaica", 30, ingredientes) { }
    }
}

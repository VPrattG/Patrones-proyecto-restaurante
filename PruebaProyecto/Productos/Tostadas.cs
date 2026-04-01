using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Tostadas : Alimento
    {
        public Tostadas(List<IngredienteAlimento> ingredientes) : base("Tostadas", 130.2, ingredientes) { }
    }
}

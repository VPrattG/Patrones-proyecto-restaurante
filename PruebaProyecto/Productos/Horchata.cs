using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Horchata : Alimento
    {
        public Horchata(List<IngredienteAlimento> ingredientes) : base("Horchata", 28, ingredientes) { }
    }
}

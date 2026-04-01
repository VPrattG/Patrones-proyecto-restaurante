using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Limonada : Alimento
    {
        public Limonada(List<IngredienteAlimento> ingredientes) : base("Limonada", 27.5, ingredientes) { }
    }
}

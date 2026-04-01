using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Agua : Alimento
    {
        public Agua(List<IngredienteAlimento> ingredientes) : base("Agua", 0, ingredientes) { }
    }
}

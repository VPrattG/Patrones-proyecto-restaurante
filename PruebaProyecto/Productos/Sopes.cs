using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Sopes : Alimento
    {
        public Sopes(List<IngredienteAlimento> ingredientes) : base("Sopes", 111, ingredientes) { }
    }
}

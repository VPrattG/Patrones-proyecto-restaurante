using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;

namespace PruebaProyecto.Productos
{
    public class Enchiladas : Alimento
    {
        public Enchiladas(List<IngredienteAlimento> ingredientes) : base("Enchiladas", 120.5, ingredientes) { }
    }
}

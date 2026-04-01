using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class Refresco : Alimento
    {
        public Refresco(List<IngredienteAlimento> ingredientes) : base("Enchiladas", 25, ingredientes) { }
    }
}

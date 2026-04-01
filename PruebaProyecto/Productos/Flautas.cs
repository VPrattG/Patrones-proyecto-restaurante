using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;

namespace PruebaProyecto.Productos
{
    public class Flautas : Alimento
    {
        public Flautas(List<IngredienteAlimento> ingredientes) : base("Flautas", 105.0, ingredientes) { }
    }
}

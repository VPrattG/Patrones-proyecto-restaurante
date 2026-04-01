using PruebaProyecto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Productos
{
    public class CarneAsada : Alimento
    {
        public CarneAsada(List<IngredienteAlimento> ingredientes) : base("Carne Asada", 175, ingredientes) { }
    }
}

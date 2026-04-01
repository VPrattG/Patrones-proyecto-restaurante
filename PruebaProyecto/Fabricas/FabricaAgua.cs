using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaAgua : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));

            return new Refresco(ingredientes);
        }
    }
}

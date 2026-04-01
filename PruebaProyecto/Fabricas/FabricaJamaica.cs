using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaJamaica : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));
            ingredientes.Add(new IngredienteAlimento("Flor de Jamaica", 3));
            ingredientes.Add(new IngredienteAlimento("Azúcar", 20));
            ingredientes.Add(new IngredienteAlimento("Hielo", 85));

            return new Jamaica(ingredientes);
        }
    }
}

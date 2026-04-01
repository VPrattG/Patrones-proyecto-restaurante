using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaHorchata : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));
            ingredientes.Add(new IngredienteAlimento("Arroz", 50));
            ingredientes.Add(new IngredienteAlimento("Canela", 10));
            ingredientes.Add(new IngredienteAlimento("Azúcar", 20));
            ingredientes.Add(new IngredienteAlimento("Hielo", 85));

            return new Horchata(ingredientes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaEnchiladas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Pollo", 300));
            ingredientes.Add(new IngredienteAlimento("Crema", 15));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 10));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 8));
            ingredientes.Add(new IngredienteAlimento("Queso", 50));
            ingredientes.Add(new IngredienteAlimento("Salsa roja", 175));
            ingredientes.Add(new IngredienteAlimento("Masa", 120));
            return new Enchiladas(ingredientes);
        }
    }
}

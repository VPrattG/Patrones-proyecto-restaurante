using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaSopes : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Masa", 120));
            ingredientes.Add(new IngredienteAlimento("Frijol", 100));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 12));
            ingredientes.Add(new IngredienteAlimento("Queso", 85));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 10));
            ingredientes.Add(new IngredienteAlimento("Salsa de tomate", 100));

            return new Sopes(ingredientes);
        }
    }
}

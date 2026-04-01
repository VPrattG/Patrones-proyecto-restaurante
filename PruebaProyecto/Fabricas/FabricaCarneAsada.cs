using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaCarneAsada : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Filete", 200));
            ingredientes.Add(new IngredienteAlimento("Cebollín", 4));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 12));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 4));
            ingredientes.Add(new IngredienteAlimento("Tomate", 5));
            ingredientes.Add(new IngredienteAlimento("Frijol", 50));
            ingredientes.Add(new IngredienteAlimento("Nopal", 20));
            ingredientes.Add(new IngredienteAlimento("Lima", 5));

            return new CarneAsada(ingredientes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaFlautas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Pollo", 140));
            ingredientes.Add(new IngredienteAlimento("Crema", 20));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 9));
            ingredientes.Add(new IngredienteAlimento("Tomate", 6));
            ingredientes.Add(new IngredienteAlimento("Queso", 30));
            ingredientes.Add(new IngredienteAlimento("Salsa verde", 125));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 5));
            ingredientes.Add(new IngredienteAlimento("Masa", 150));
            return new Flautas(ingredientes);
        }
    }
}

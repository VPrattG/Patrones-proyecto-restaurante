using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Productos;

namespace PruebaProyecto.Fabricas
{
    public class FabricaTostadas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Tostadas", 3));
            ingredientes.Add(new IngredienteAlimento("Frijol", 120));
            ingredientes.Add(new IngredienteAlimento("Res", 150));
            ingredientes.Add(new IngredienteAlimento("Salsa de tomate", 85));
            ingredientes.Add(new IngredienteAlimento("Cebolla morada", 10));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 8));
            ingredientes.Add(new IngredienteAlimento("Crema", 25));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 6));
            
            return new Tostadas(ingredientes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;

namespace PruebaProyecto
{
    public class Inventario
    {
        public List<Ingrediente> Ingredientes { get; private set; }
        public Inventario()
        {
            Ingredientes = new List<Ingrediente>();
            // Medido en gramos
            Ingredientes.Add(new Ingrediente("Masa", 3000, 500)); 
            Ingredientes.Add(new Ingrediente("Pollo", 10000, 2500));
            Ingredientes.Add(new Ingrediente("Res", 10000, 2500));
            Ingredientes.Add(new Ingrediente("Filete", 10000, 3000));
            Ingredientes.Add(new Ingrediente("Frijol", 8000, 2500));
            Ingredientes.Add(new Ingrediente("Hielo", 2000, 500));
            Ingredientes.Add(new Ingrediente("Azúcar", 3000, 800));
            Ingredientes.Add(new Ingrediente("Queso", 2000, 500));
            Ingredientes.Add(new Ingrediente("Canela", 3000, 1000));
            Ingredientes.Add(new Ingrediente("Arroz", 6000, 1200));
            // Medido en mililitros
            Ingredientes.Add(new Ingrediente("Agua", 649, 4000));
            Ingredientes.Add(new Ingrediente("Crema", 5000, 1000));
            Ingredientes.Add(new Ingrediente("Salsa roja", 4000, 800));
            Ingredientes.Add(new Ingrediente("Salsa verde", 4000, 800));
            Ingredientes.Add(new Ingrediente("Salsa de tomate", 4000, 800));
            // Medido en rebanadas/gajos
            Ingredientes.Add(new Ingrediente("Cebolla blanca", 300, 60));
            Ingredientes.Add(new Ingrediente("Cebolla morada", 300, 60));
            Ingredientes.Add(new Ingrediente("Lechuga", 500, 200));
            Ingredientes.Add(new Ingrediente("Tomate", 500, 200));
            Ingredientes.Add(new Ingrediente("Aguacate", 300, 100));
            Ingredientes.Add(new Ingrediente("Nopal", 600, 320));
            Ingredientes.Add(new Ingrediente("Lima", 250, 100));
            // Medido en unidades enteras
            Ingredientes.Add(new Ingrediente("Limón", 750, 250));
            Ingredientes.Add(new Ingrediente("Cebollín", 500, 200));
            Ingredientes.Add(new Ingrediente("Flor de Jamaica", 800, 500));
            Ingredientes.Add(new Ingrediente("Latas de refresco", 75, 30));
            Ingredientes.Add(new Ingrediente("Tostadas", 240, 48));
        }
        public bool RevisarDisponibilidad(Alimento alimento)
        {
            List<string> ingredientesFaltantes = new List<string>();
            foreach(var ingredienteAli in alimento.Ingredientes)
            {
                var ingredienteInv = Ingredientes.FirstOrDefault(i =>
                i.Nombre.Equals(ingredienteAli.Nombre, StringComparison.OrdinalIgnoreCase));

                // Si el alimento no existe, o no se tiene el material necesario, se añade a una lista
                if (ingredienteInv == null)
                {
                    ingredientesFaltantes.Add($"- El ingrediente {ingredienteAli.Nombre} no se encuentra en el inventario.");
                }
                else if(ingredienteInv.Cantidad < ingredienteAli.CantidadNecesaria)
                {
                    ingredientesFaltantes.Add($"- La cantidad de {ingredienteInv.Nombre} es insuficiente. \n\t" +
                        $"Necesario: {ingredienteAli.CantidadNecesaria}, Disponible: {ingredienteInv.Cantidad}");
                }
            }

            // Si la lista no está vacía, se devuelve falso, y todos los ingredientes faltantes
            if (ingredientesFaltantes.Count > 0)
            {
                foreach (string faltante in ingredientesFaltantes)
                {
                    Console.WriteLine(faltante);
                }
                return false;
            }
            
            // De otro modo, se devuelve verdadero
            return true;
        }

        public bool UtilizarIngredientes(Alimento alimento)
        {
            // Si no hay suficientes ingredientes, se interrumpe la operación
            if(!RevisarDisponibilidad(alimento))
            {
                return false;
            }

            foreach(IngredienteAlimento ingredienteAli in alimento.Ingredientes)
            {
                var ingredienteInv = Ingredientes.FirstOrDefault(i =>
                i.Nombre.Equals(ingredienteAli.Nombre, StringComparison.OrdinalIgnoreCase));

                ingredienteInv.Utilizar(ingredienteAli.CantidadNecesaria);
            }
            
            return true;
        }

        public void DesplegarInventario()
        {
            Console.Clear();
            Console.WriteLine("Ingredientes en el inventario: \n");
            
            foreach(Ingrediente ingrediente in Ingredientes)
            {
                Console.WriteLine($"{ingrediente.Nombre}: {ingrediente.Cantidad} de {ingrediente.CantidadMaxima}.");
                if(ingrediente.Cantidad <= ingrediente.PuntoDeOrden)
                {
                    Console.WriteLine("\t* Es necesario ordenar más del ingrediente.");
                }
            }
        }

        public void ReponerInventario()
        {
            foreach(var ingrediente in Ingredientes)
            {
                if (ingrediente.Cantidad <= ingrediente.PuntoDeOrden)
                {
                    Console.WriteLine($"Se ha pedido y reabastecido el siguiente ingrediente: {ingrediente.Nombre}");
                    ingrediente.Ordenar();
                    Thread.Sleep(100);
                }
            }
        }
    }
}

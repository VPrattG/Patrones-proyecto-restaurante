using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto
{
    public enum Area
    {
        Meseros,
        Cocina,
        Bebidas
    }
    public class Ventas
    {
        List<Orden> ordenes;
        List<Area> areasDePropina;
        static Random rng;

        public Ventas()
        {
            ordenes = new List<Orden>();
            areasDePropina = new List<Area>();
            rng = new Random();
        }
        public void AgregarVenta(Orden orden)
        {
            ordenes.Add(orden);
            areasDePropina.Add(ValorAleatorio<Area>());
        }
        public void MostrarVentas()
        {
            Console.WriteLine();

            for (int i = 0; i < ordenes.Count; i++)
            {
                Console.WriteLine($"Orden {i + 1}:");
                ordenes[i].DesplegarOrden(ordenes[i].ListaPlatillos, "Platillos");
                ordenes[i].DesplegarOrden(ordenes[i].ListaBebidas, "Bebidas");
                Console.WriteLine($"\tPropina de ${ordenes[i].Propina} para el Área de {areasDePropina[i]}");
            }
        }
        public void Reiniciar()
        {
            ordenes.Clear();
            areasDePropina.Clear();
        }
        public static T ValorAleatorio<T>() where T : Enum
        {
            var valores = Enum.GetValues(typeof(T));
            return (T)valores.GetValue(rng.Next(valores.Length));
        }
    }
}

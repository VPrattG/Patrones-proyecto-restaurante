using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;

namespace PruebaProyecto
{
    public class Orden
    {
        private List<Alimento> _listaPlatillos;
        private List<Alimento> _listaBebidas;
        private double _propina;
        public Orden()
        {
            _listaPlatillos = new List<Alimento>();
            _listaBebidas = new List<Alimento>();
        }
        public List<Alimento> ListaPlatillos 
        {
            get
            {
                return _listaPlatillos;
            } 
        }
        public List<Alimento> ListaBebidas
        {
            get
            {
                return _listaBebidas;
            }
        }
        public double Propina
        {
            get
            {
                return _propina;
            }
        }
        public void AgregarPlatillo(Alimento alimento)
        {
            _listaPlatillos.Add(alimento);
            _propina += alimento.Precio * 0.1;
        }
        public void AgregarBebida(Alimento alimento)
        {
            _listaBebidas.Add(alimento);
            _propina += alimento.Precio * 0.1;
        }
        public void DesplegarOrden(List<Alimento> lista, string titulo)
        {
            if (lista.Count>0)
            {
                Console.WriteLine($"\t{titulo}:");
                foreach (var elemento in lista)
                {
                    Console.WriteLine($"\t\t{elemento.Nombre} --- ${elemento.Precio}");
                }
            }
        }
    }
}

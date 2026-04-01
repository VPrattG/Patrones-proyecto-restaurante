using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto
{
    public class AdministradorMesa
    {
        private static AdministradorMesa _instance;
        private static readonly object _lock = new object();

        public const int maximoMesas = 8;
        private readonly List<Mesa> _mesas;

        private AdministradorMesa()
        {
            _mesas = new List<Mesa>();
            for(int i = 1; i<=maximoMesas; i++)
            {
                _mesas.Add(new Mesa(i));
            }
        }

        public static AdministradorMesa obtenerInstancia()
        {
            if(_instance == null)
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new AdministradorMesa();
                    }
                }
            }
            return _instance;
        }

        // Ocupa la primera mesa disponible
        public Mesa OcuparMesa()
        {
            lock (_lock)
            {
                foreach(var mesa in _mesas)
                {
                    if (!mesa.Ocupada)
                    {
                        mesa.OcuparMesa();

                        Console.WriteLine($"Se ha ocupado la mesa {mesa.Numero}.");

                        return mesa;
                    }
                }
                throw new InvalidOperationException("No hay mesas disponibles actualmente.");
            }
        }

        // Desocupa una mesa
        // A diferencia de la función de ocupar, esta necesita el número específico.
        public void DesocuparMesa(int numMesa)
        {
            lock (_lock)
            {
                if (numMesa < 1 || numMesa > maximoMesas)
                {
                    throw new ArgumentOutOfRangeException($"El número de mesa debe estar entre 1 y {maximoMesas}.");
                }
                
                Mesa mesa = _mesas[numMesa - 1];
                
                mesa.DesocuparMesa();
            }
        }

        // Despliega si una mesa en particular está disponible o no
        public bool Disponibilidad(int numMesa)
        {
            if (numMesa < 1 || numMesa > maximoMesas)
            {
                throw new ArgumentOutOfRangeException($"El número de mesa debe estar entre 1 y {maximoMesas}.");
            }
            
            // Como se pide la disponibilidad y se almacena si está ocupada o no, se devuelve el valor opuesto
            return !_mesas[numMesa - 1].Ocupada;
        }

        public void MostrarMesas()
        {
            Console.WriteLine("++++++++++++ Mesas ++++++++++++");
            foreach (var mesa in _mesas)
            {
                Console.WriteLine(mesa.DesplegarInfo());
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++");
        }

        public int ContarMesasDisponibles()
        {
            int contador = 0;
            
            foreach (var mesa in _mesas)
            {
                if (!mesa.Ocupada) { contador++; }
            }
            
            return contador;
        }
    }
}

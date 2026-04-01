using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Bases
{
    public abstract class Alimento
    {
        private string _nombre;
        private double _precio;
        private List<IngredienteAlimento> _ingredientes;
        public string Nombre
        {
            get { return _nombre; }
        }
        public double Precio
        {
            get { return _precio; }
        }
        public List<IngredienteAlimento> Ingredientes
        {
            get { return _ingredientes; }
        }
        public Alimento(string nombre, double precio, List<IngredienteAlimento> ingredientes)
        {
            _nombre = nombre;
            _precio = precio;
            _ingredientes = ingredientes;
        }
    }
}

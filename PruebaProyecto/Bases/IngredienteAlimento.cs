using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Bases
{
    // Los platillos no necesitan saber la cantidad máxima o punto de orden de cada ingrediente
    // Por ende, se hizo una segunda clase
    public class IngredienteAlimento
    {
        private string _nombre;
        private int _cantidadNecesaria;
        public IngredienteAlimento(string nom, int cant)
        {
            _nombre = nom;
            _cantidadNecesaria = cant;
        }
        public string Nombre
        {
            get { return _nombre; }
        }
        public int CantidadNecesaria
        {
            get { return _cantidadNecesaria; }
        }
    }
}

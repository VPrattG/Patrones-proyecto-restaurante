using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto
{
    public class Mesa
    {
        private int _numero;
        private bool _ocupada;

        public int Numero
        {
            get { return _numero; }
        }

        public bool Ocupada
        {
            get { return _ocupada; }
        }
        
        public Mesa(int num)
        {
            _numero = num;
            _ocupada = false;
        }

        public void OcuparMesa()
        {
            if (_ocupada)
            {
                Console.WriteLine("La mesa ya se encuentra ocupada.");
            }
            else
            {
                _ocupada = true;
            }
        }
        public void DesocuparMesa()
        {
            if(! _ocupada)
            {
                Console.WriteLine("La mesa ya se encuentra desocupada.");
            }
            else
            {
                _ocupada = false;
            }
        }
        public string DesplegarInfo()
        {
            if(_ocupada) { return $"Mesa {_numero}: Ocupada"; }
            else { return $"Mesa {_numero}: Desocupada"; }
        }
    }
}

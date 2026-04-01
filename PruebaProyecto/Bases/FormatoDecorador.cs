using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Bases
{
    public class FormatoDecorador : CreadorFormato
    {
        protected CreadorFormato _creadorFormato;
        public FormatoDecorador(CreadorFormato creadorFormato)
        {
            _creadorFormato = creadorFormato;
            foreach (string linea in _creadorFormato.Reporte)
            {
                _reporte.Add(linea);
            }
        }
        public override void CapturarLineas(Action acc)
        {
            _creadorFormato.CapturarLineas(acc);
            _reporte.Clear();
            foreach (string linea in _creadorFormato.Reporte)
            {
                _reporte.Add(linea);
            }
        }
        public override void AgregarLinea(string linea)
        {
            _creadorFormato.AgregarLinea(linea);
            _reporte.Add(linea);
        }
        public override void CrearFormato()
        {
            _creadorFormato.CrearFormato();
        }
    }
}

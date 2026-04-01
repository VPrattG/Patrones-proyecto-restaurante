using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto.Bases
{
    public abstract class CreadorFormato
    {
        protected List<string> _reporte;
        protected StringWriter _stringWriter;
        public CreadorFormato()
        {
            _reporte = new List<string>();
            _stringWriter = new StringWriter();
        }
        public List<string> Reporte
        {
            get { return _reporte; }
        }
        public void Reiniciar()
        {
            _reporte.Clear();
        }
        public abstract void CapturarLineas(Action acc);
        public abstract void AgregarLinea(string linea);
        public abstract void CrearFormato();
    }
}

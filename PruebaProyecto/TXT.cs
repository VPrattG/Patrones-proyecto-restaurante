using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;

namespace PruebaProyecto
{
    public class TXT : CreadorFormato
    {
        public override void CapturarLineas(Action acc)
        {
            TextWriter salida = Console.Out;
            try
            {
                Console.SetOut(_stringWriter);
                acc();

                string contenido = _stringWriter.ToString();
                string[] lineas = contenido.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                _reporte.AddRange(lineas);
            }
            finally
            {
                Console.SetOut(salida);
            }
        }
        public override void AgregarLinea(string linea)
        {
            _reporte.Add(linea);
        }
        public override void CrearFormato()
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string ruta = Path.GetFullPath($"Reporte_{fecha}.txt");

            Console.WriteLine("Generando TXT...");

            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (string linea in _reporte)
                {
                    sw.WriteLine(linea);
                }
            }

            Console.WriteLine("Archivo generado exitosamente.");
            Console.WriteLine($"Archivo encontrado en {ruta}");
        }
    }
}

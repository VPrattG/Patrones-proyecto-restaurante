using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using System.Xml;

namespace PruebaProyecto.Decoradores
{
    public class FormatoXML : FormatoDecorador
    {
        private string _elementoRaiz;
        private string _elementoLinea;
        public FormatoXML(CreadorFormato creadorFormato) : base(creadorFormato) 
        {
            _elementoRaiz = "Reporte";
            _elementoLinea = "Línea";
        }

        public override void CrearFormato()
        {
            List<string> lineasReporte = new List<string>(_reporte);

            base.CrearFormato();

            CrearXML(lineasReporte);
        }

        public void CrearXML(List<string> reporte)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string ruta = Path.GetFullPath($"Reporte_{fecha}.xml");

            Console.WriteLine("Generando XML...");
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  "
                };

                using (XmlWriter writer = XmlWriter.Create(ruta, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(_elementoRaiz);

                    writer.WriteAttributeString("FechaGeneracion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    // Cada línea se incorpora como elemento
                    for (int i = 0; i < reporte.Count; i++)
                    {
                        writer.WriteStartElement(_elementoLinea);
                        writer.WriteAttributeString("Numero", (i + 1).ToString());
                        writer.WriteString(reporte[i]);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                Console.WriteLine("Archivo XML generado exitosamente.");
                Console.WriteLine($"Archivo encontrado en {ruta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar XML: {ex}");
            }
        }
    }
}

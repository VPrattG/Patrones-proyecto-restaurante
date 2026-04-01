using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace PruebaProyecto.Decoradores
{
    public class FormatoPDF : FormatoDecorador
    {
        public FormatoPDF(CreadorFormato creadorFormato) : base(creadorFormato) { }

        public override void CrearFormato()
        {
            List<string> lineasReporte = new List<string>(_reporte);

            base.CrearFormato();

            CrearPDF(lineasReporte);
        }

        public void CrearPDF(List<string> reporte)
        {
            try
            {
                string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string ruta = Path.GetFullPath($"Reporte_{fecha}.pdf");
                double y = 0;

                Console.WriteLine("Generando PDF...");

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = $"Reporte de {DateTime.Now.ToString("U")}";

                PdfPage pag = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(pag);
                XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

                foreach (string s in reporte)
                {
                    gfx.DrawString(s, font, XBrushes.Black,
                        new XRect(0, y, pag.Width + 2, pag.Height), XStringFormats.TopLeft);
                    y += 12;
                }

                pdf.Save(ruta);
                Console.WriteLine("Archivo PDF generado exitosamente.");
                Console.WriteLine($"Archivo encontrado en {ruta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar PDF: {ex.Message}");
            }
        }
    }
}

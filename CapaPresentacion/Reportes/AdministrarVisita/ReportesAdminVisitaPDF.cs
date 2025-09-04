using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using CapaDatos;

namespace CapaPresentacion.Reportes.AdministrarVisita
{
    public class ReportesAdminVisitaPDF
    {
                
        //VINCULOS DE LA VISITA         
        public static MemoryStream RepPdfInternosVinculados(List<DVisitaInterno>listaVinculos)
        {
            MemoryStream ms = new MemoryStream();

            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

            Paragraph titulo = new Paragraph("Reporte seguro en memoria", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Salta: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal));
            doc.Add(new Paragraph("PDF en memoria y liberable.", fuenteNormal));
            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;
            tabla.AddCell("Interno");
            tabla.AddCell("Parentesco");
            tabla.AddCell("Unidad");
            tabla.AddCell("Vigente");

            // Filas dinámicas
            foreach (var vinculo in listaVinculos)
            {
                tabla.AddCell(vinculo.interno.apellido.ToString() + " " + vinculo.interno.nombre.ToString());
                tabla.AddCell(vinculo.parentesco.parentesco);
                tabla.AddCell(vinculo.interno.organismo.organismo.ToString());
                tabla.AddCell(vinculo.vigente.ToString());
            }

            doc.Add(tabla);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }
    } 
    
}

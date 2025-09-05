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
using System.Windows.Forms;
using CommonCache;

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

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 11, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            //logo encabezado
            string rutaImagen = Path.Combine(Application.StartupPath, "Resources/Img-reportes/", "logo_spps2.png");
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            logo.ScaleAbsolute(40, 40);
            logo.SetAbsolutePosition(80, 770);
            doc.Add(logo);
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("  SERVICIO PENITENCIARIO", fuenteLogo));
            doc.Add(new Paragraph("DE LA PROVINCIA DE SALTA", fuenteLogo));
            doc.Add(new Paragraph("ALCAIDIA GRAL. N° 1", fuenteLogo));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(organismo, fuenteOrganismo));

            //pdfptable tablaencabezado = new pdfptable(1);
            //tablaencabezado.horizontalalignment = element.align_left; // tabla a la izquierda
            //tablaencabezado.defaultcell.horizontalalignment = element.align_center;
            ////tablaencabezado.defaultcell.border = rectangle.no_border;
            //tablaencabezado.totalwidth = 200f; // ancho fijo en puntos
            //tablaencabezado.lockedwidth = true;
            //tablaencabezado.setwidths(new float[] { 200f}); // anchos absolutos de cada columna
            //tablaencabezado.addcell("servicio penitenciario");
            //tablaencabezado.addcell("de la provincia de salta");
            //tablaencabezado.addcell(organismo);
            //doc.add(tablaencabezado);
            //fin logo encabezado.....................................

            //fecha
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Salta: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            doc.Add(new Paragraph(" "));
            //fin fecha.............................

            Paragraph titulo = new Paragraph("Reporte seguro en memoria", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            PdfPTable tabla = new PdfPTable(4);
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

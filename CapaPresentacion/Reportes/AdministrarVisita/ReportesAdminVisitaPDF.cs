﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using CapaDatos;
using System.Windows.Forms;
using CommonCache;
using System.Globalization;

namespace CapaPresentacion.Reportes.AdministrarVisita
{
    public class ReportesAdminVisitaPDF
    {
                
        //VINCULOS DE LA VISITA         
        public static MemoryStream RepPdfInternosVinculados(DCiudadano ciudadanox,List<DVisitaInterno>listaVinculos)
        {
            MemoryStream ms = new MemoryStream();

            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 10, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            //logo encabezado
            string rutaImagen = Path.Combine(Application.StartupPath, "Resources/Img-reportes/", "logo_spps2.png");
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            logo.ScaleAbsolute(40, 40);
            logo.SetAbsolutePosition(150, 770);
            doc.Add(logo);
            doc.Add(new Paragraph(" "));

            // Crear tabla con 2 columnas
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 50; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            tablaEncabezado.AddCell(new Paragraph("  SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA", fuenteLogo));
            tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // "d 'de' MMMM 'de' yyyy" → ejemplo: "9 de septiembre de 2025"
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(fechaCompleta, fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................

            doc.Add(new Paragraph(" "));

            //datos ciudadano
            doc.Add(new Paragraph(" Apellido y nombre: " + ciudadanox.apellido + " " + ciudadanox.nombre , fuenteNormal));
            doc.Add(new Paragraph(" DNI: " + ciudadanox.dni, fuenteNormal));
            PdfPTable tablaDatos = new PdfPTable(2);
            tablaDatos.WidthPercentage = 60;
            tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda
            tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaDatos.AddCell(new Paragraph("Sexo: " + ciudadanox.sexo.sexo, fuenteNormal));
            tablaDatos.AddCell(new Paragraph("Edad: " + ciudadanox.edad, fuenteNormal));
            doc.Add(tablaDatos);
            //fin datos ciudadano

            doc.Add(new Paragraph(" "));

            Paragraph titulo = new Paragraph("Vinculos de la visita", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            doc.Add(new Paragraph(" "));

            PdfPTable tablaVinculos = new PdfPTable(4);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 2.1f, 1f, 1.3f, 0.6f });
            tablaVinculos.AddCell("Interno");
            tablaVinculos.AddCell("Parentesco");
            tablaVinculos.AddCell("Unidad");
            tablaVinculos.AddCell("Vigente");

            // Filas dinámicas
            foreach (var vinculo in listaVinculos)
            {
                tablaVinculos.AddCell(new Paragraph(vinculo.interno.apellido.ToString() + " " + vinculo.interno.nombre.ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.parentesco.parentesco,fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.interno.organismo.organismo.ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(vinculo.vigente ? "SI" : "NO", fuenteNormal));
            }

            doc.Add(tablaVinculos);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }
    } 
    
}

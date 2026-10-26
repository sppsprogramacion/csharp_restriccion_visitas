using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes.AdministrarVisita;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormSabanaCiudadano : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();

        int idCiudadanoGlobal = 0;
        DateTime fechaInicioGlobal;
        DateTime fechaFinGlobal;

        DCiudadanoSabanaResponse ciudadanoSabanaGlobal = new DCiudadanoSabanaResponse();

        public FormSabanaCiudadano(int idCiudadanoX, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            this.idCiudadanoGlobal = idCiudadanoX;
            this.fechaInicioGlobal = fechaInicio;
            this.fechaFinGlobal = fechaFin;

        }

        private async void FormSabanaCiudadano_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            //BUSCAR INTERNO CON EL ID PASADO DESDE EL FORMULARIO DE BUSQUEDA (FormInternos)
            NEntradaSalida nEntradaSalida = new NEntradaSalida();
            (DCiudadanoSabanaResponse dCiudadanoSabanaResponse, string errorInternoResponse) = await nEntradaSalida.BuscarCiudadanoSabanaXInterno(this.idCiudadanoGlobal, fechaInicioGlobal.ToString("yyyy-MM-dd"), fechaFinGlobal.ToString("yyyy-MM-dd"));

            if (dCiudadanoSabanaResponse != null)
            {
                this.ciudadanoSabanaGlobal = dCiudadanoSabanaResponse;
            }
            else
            {
                MessageBox.Show("no se encontró el ciudadano: " + errorInternoResponse, "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //CARGAR DATOS DEL INTERNO
            txtDni.Text = this.ciudadanoSabanaGlobal.dni.ToString();
            txtVisita.Text = this.ciudadanoSabanaGlobal.nombre_visita;
            pictureFoto.Load(this.ciudadanoSabanaGlobal.foto);

            //CARGAR VINCULOS
            var datosfiltrados = this.ciudadanoSabanaGlobal.listaVinculosResponse
                .Select(c => new
                {
                    IdInterno = c.interno_id,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    Prontuario = c.interno.prontuario,
                    Unidad = c.interno.organismo.organismo,
                    Parentesco = c.parentesco.parentesco,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Prohibido = c.prohibido,
                    FechaProhib = c.fecha_prohibido,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    DetalleProhib = c.detalles_prohibicion,
                    FechaAlta = c.fecha_alta,                    

                })
                .ToList();

            dtgvParentescos.DataSource = datosfiltrados;

            if (this.ciudadanoSabanaGlobal.listaVinculosResponse.Count == 0)
            {
                MessageBox.Show("No se encontraron registros de vinculos.", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dtgvParentescos.Columns[0].Width = 50;
                dtgvParentescos.Columns[1].Width = 200;
                dtgvParentescos.Columns[3].Width = 150;
                dtgvParentescos.Columns[5].Width = 70;
                dtgvParentescos.Columns[6].Width = 70;
                dtgvParentescos.Columns[7].Width = 70;
            }

            //CARGAR SABANA DE INGRESO DE VISITAS
            txtFechaInicioVer.Text = fechaInicioGlobal.ToShortDateString();
            txtFechaFinVer.Text = fechaFinGlobal.ToShortDateString();

            var datosfiltradosSabana = this.ciudadanoSabanaGlobal.listaEntradasResponse
                .Select(c => new
                {
                    Fecha = c.fecha_registro,
                    Interno = c.nombre_interno,
                    Parentesco = c.parentesco,
                    Entrada = c.hora_registro,
                    Salida = c.hora_egreso,
                    Menores = c.menores,
                    Organismo = c.organismo
                })
                .ToList();

            dtgIngresos.DataSource = datosfiltradosSabana;

            if (this.ciudadanoSabanaGlobal.listaEntradasResponse.Count == 0)
            {
                MessageBox.Show("No se encontraron registros de sabana", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dtgIngresos.Columns[0].Width = 80;
                dtgIngresos.Columns[1].Width = 250;
                dtgIngresos.Columns[2].Width = 90;
                dtgIngresos.Columns[3].Width = 70;
                dtgIngresos.Columns[4].Width = 70;
                dtgIngresos.Columns[5].Width = 300;
                dtgIngresos.Columns[6].Width = 150;

            }
        }

        private void dtgvParentescos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvParentescos.SelectedRows.Count > 0)
                {
                    int id_interno;
                    id_interno = Convert.ToInt32(dtgvParentescos.CurrentRow.Cells["IdInterno"].Value.ToString());

                    

                    if (id_interno > 0)
                    {
                        txtIdInterno.Text = id_interno.ToString();
                        txtInternoVinculado.Text = dtgvParentescos.CurrentRow.Cells["Interno"].Value.ToString();
                        txtParentesco.Text = dtgvParentescos.CurrentRow.Cells["Parentesco"].Value.ToString();
                        txtDetalleProhibicionParentesco.Text = dtgvParentescos.CurrentRow.Cells["DetalleProhib"].Value?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una vinculo.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btnImprimirVinculos_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            //buscar ciudadano
            this.Enabled = false;
            (DCiudadano dCiudadanoX, string errorCiudadanoResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadanoGlobal);
            this.Enabled = true;

            if (dCiudadanoX == null)
            {
                
                MessageBox.Show(errorCiudadanoResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //buscar vinculos
            (List<DVisitaInterno> listaParentescos, string errorResponse) = await nVisitaInterno.RetornarListaParentescos(idCiudadanoGlobal);

            if (listaParentescos == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Generar PDF en memoria
            MemoryStream msOriginal = ReportesAdminVisitaPDF.RepPdfInternosVinculados(dCiudadanoX, listaParentescos);

            // Clonar el stream para que PdfiumViewer pueda cerrarlo sin afectar el original
            MemoryStream ms = new MemoryStream(msOriginal.ToArray());

            PdfDocument pdfDocument = null;

            try
            {
                pdfDocument = PdfDocument.Load(ms);

                Form formVisor = new Form
                {
                    Text = "Vista previa PDF",
                    Width = 800,
                    Height = 600
                };

                PdfViewer pdfViewer = new PdfViewer
                {
                    Dock = DockStyle.Fill,
                    Document = pdfDocument
                };

                formVisor.Controls.Add(pdfViewer);

                formVisor.FormClosed += (s, args) =>
                {
                    // Liberar recursos al cerrar el visor
                    pdfViewer.Document.Dispose();
                    pdfViewer.Dispose();
                    formVisor.Dispose();
                    ms.Dispose();
                    pdfDocument = null;
                };

                formVisor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar PDF: " + ex.Message);
                ms.Dispose();
                pdfDocument?.Dispose();
            }
        }
    }
}

using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormSabanaInternos : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();

        int idInternoGlobal = 0;
        DateTime fechaInicioGlobal;
        DateTime fechaFinGlobal;

        DInternoSabanaResponse internoSabanaGlobal = new DInternoSabanaResponse();
        
        public FormSabanaInternos(int idInternoX, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            this.idInternoGlobal = idInternoX;
            this.fechaInicioGlobal = fechaInicio;
            this.fechaFinGlobal = fechaFin;

        }

        private async void FormSabanaInternos_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            //BUSCAR INTERNO CON EL ID PASADO DESDE EL FORMULARIO DE BUSQUEDA (FormInternos)
            NEntradaSalida nEntradaSalida = new NEntradaSalida();

            (DInternoSabanaResponse dInternoSabanaResponse, string errorInternoResponse) = await nEntradaSalida.BuscarInternoSabanaXInterno(this.idInternoGlobal, fechaInicioGlobal.ToString("yyyy-MM-dd"), fechaFinGlobal.ToString("yyyy-MM-dd"));

            if (dInternoSabanaResponse != null)
            {
                this.internoSabanaGlobal = dInternoSabanaResponse;
            }
            else
            {
                MessageBox.Show("no se encontró el interno: " + errorInternoResponse, "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //CARGAR DATOS DEL INTERNO
            txtProntuario.Text = this.internoSabanaGlobal.prontuario.ToString();
            txtInterno.Text = this.internoSabanaGlobal.nombre_interno;
            txtEstadoProcesalVer.Text = this.internoSabanaGlobal.estado_procesal;
            txtJurisdiccionVer.Text = this.internoSabanaGlobal.jurisdiccion;
            txtOrganismoAlojamientoVer.Text = this.internoSabanaGlobal.organismo;
            txtFechaAlojamiento.Text = this.internoSabanaGlobal.fecha_alojamiento.ToShortDateString();
            //txtCausa.Text = this.internoSabanaGlobal.caaa

            //CARGAR VINCULOS
            var datosfiltrados = this.internoSabanaGlobal.listaVinculosResponse
                .Select(c => new
                {
                    Id = c.id_visita_interno,
                    Visita = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                    DNI = c.ciudadano.dni,
                    Parentesco = c.parentesco.parentesco,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Prohibido = c.prohibido,
                    FechaProhib = c.fecha_prohibido,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    DetalleProhib = c.detalles_prohibicion,
                    FechaAlta = c.fecha_alta,
                    //Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvParentescos.DataSource = datosfiltrados;

            if (this.internoSabanaGlobal.listaVinculosResponse.Count == 0)
            {
                MessageBox.Show("No se encontraron registros de vinculos.", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {

                dtgvParentescos.Columns[1].Width = 200;
            }

            //CARGAR SABANA DE INGRESO DE VISITAS
            txtFechaInicioVer.Text = fechaInicioGlobal.ToShortDateString();
            txtFechaFinVer.Text = fechaFinGlobal.ToShortDateString();

            var datosfiltradosSabana = this.internoSabanaGlobal.listaEntradasResponse
                .Select(c => new
                {
                    Fecha = c.fecha_registro,
                    Visita = c.nombre_visita,
                    Parentesco = c.parentesco,
                    Entrada = c.hora_registro,
                    Salida = c.hora_egreso,
                    Menores = c.menores,
                    Organismo = c.organismo
                })
                .ToList();

            dtgIngresos.DataSource = datosfiltradosSabana;

            if (this.internoSabanaGlobal.listaEntradasResponse.Count == 0)
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
    }
}

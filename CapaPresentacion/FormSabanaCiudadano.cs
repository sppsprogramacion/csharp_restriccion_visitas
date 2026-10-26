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
            txtVisita.Text = this.ciudadanoSabanaGlobal.nombre_interno;

            //CARGAR VINCULOS
            var datosfiltrados = this.ciudadanoSabanaGlobal.listaVinculosResponse
                .Select(c => new
                {
                    Id = c.id_visita_interno,
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

                dtgvParentescos.Columns[1].Width = 200;
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
    }
}

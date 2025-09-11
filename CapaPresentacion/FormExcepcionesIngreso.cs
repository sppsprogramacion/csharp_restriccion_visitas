using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
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
    public partial class FormExcepcionesIngreso : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        //cumplimentar/anular excepcion
        bool accionCumplimentarExcepcion = false;
        bool accionAnularExcepcion = false;

        public FormExcepcionesIngreso()
        {
            InitializeComponent();
        }

        private async void btnVerExcepciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridExcepciones();
        }

        private void dtgvExcepcionesIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvExcepcionesIngreso.SelectedRows.Count > 0)
                {
                    int id_excepcion_ingreso;
                    id_excepcion_ingreso = Convert.ToInt32(dtgvExcepcionesIngreso.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_excepcion_ingreso > 0)
                    {
                        //deshabilitar controles
                        //this.HabilitarControlesExcepcion(false);
                        //this.HabilitarControlesCumplimentarAnularExcepcion(false);

                        //cargar datos de datagrid a controles
                        txtIdExcepcion.Text = id_excepcion_ingreso.ToString();
                        txtMotivoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["MotivoExcepcion"].Value.ToString();
                        txtDetalleExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Detalle"].Value.ToString();
                        txtInternoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Interno"].Value.ToString();
                        dtpFechaExcepcion.Value = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaExcepcion"].Value.ToString());
                        txtOrganismoExepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioCargaExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Usuario"].Value.ToString();
                        chkCumplimentadoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Cumplimentado"].Value.ToString());
                        
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCumplimentarExcepcion_Click(object sender, EventArgs e)
        {
            if (txtIdExcepcion.Text == string.Empty)
            {
                MessageBox.Show("Debe selecionar una excepción para cumplimentar", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.accionAnularExcepcion = false;
            this.accionCumplimentarExcepcion = true;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE CUMPLIMENTAR:";
            this.HabilitarControlesCumplimentarAnularExcepcion(true);
        }

        private void btnAnularExcepcion_Click(object sender, EventArgs e)
        {
            if (txtIdExcepcion.Text == string.Empty)
            {
                MessageBox.Show("Debe selecionar una excepción para anular", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.accionCumplimentarExcepcion = false;
            this.accionAnularExcepcion = true;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE ANULAR:";
            this.HabilitarControlesCumplimentarAnularExcepcion(true);
        }

        //HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION
        private void HabilitarControlesCumplimentarAnularExcepcion(bool habilitar)
        {
            //habilita controles
            txtDetalleCumplAnularExcepcion.Enabled = habilitar;

            //limpia
            txtDetalleCumplAnularExcepcion.Text = string.Empty;


            //habilita botones
            btnAnularExcepcion.Enabled = !habilitar;
            btnCumplimentarExcepcion.Enabled = !habilitar;
            btnGuardarCumplAnularExcepcion.Enabled = habilitar;
            btnCancelarCumplAnularExcepcion.Enabled = habilitar;

           
        }

        private async void btnGuardarCumplAnularExcepcion_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                txtDetalleCumplAnularExcepcion = txtDetalleCumplAnularExcepcion.Text,
            };

            var validator = new ExcepcionIngresoCumplimentarAnularValidator();
            var result = validator.Validate(datosFormulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validacion de formulario

            NExcepcionIngresoVisita nExcepcionIngreso = new NExcepcionIngresoVisita();

            var data = new
            {
                detalle_cambio = txtDetalleCumplAnularExcepcion.Text,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);


            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionAnularExcepcion)
            {
                groupCumplimentarAnular.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.AnularExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                groupCumplimentarAnular.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La excepción se anuló correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }


            if (this.accionCumplimentarExcepcion)
            {
                groupCumplimentarAnular.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.CumplimentarExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                groupCumplimentarAnular.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La excepción se cumplimentó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                this.HabilitarControlesCumplimentarAnularExcepcion(false);
                this.CargarDataGridExcepciones();
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FIN HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION..............................


        //METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridExcepciones()
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();
            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngresoXFecha(dtpFechaExcepcionBuscar.Value.ToString("yyyy-MM-dd"));

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaExcepcionesIngreso
                .Select(c => new
                {
                    Id = c.id_excepcion_ingreso_visita,
                    FechaExcepcion = c.fecha_excepcion,
                    MotivoExcepcion = c.motivo,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    Cumplimentado = c.cumplimentado,
                    Detalle = c.detalle_excepcion,
                    FechaCarga = c.fecha_carga,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre,
                    Anulado = c.anulado

                })
                .ToList();

            dtgvExcepcionesIngreso.DataSource = datosfiltrados;

            if (listaExcepcionesIngreso.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvExcepcionesIngreso.Columns[2].Width = 200;
                dtgvExcepcionesIngreso.Columns[3].Width = 200;
                dtgvExcepcionesIngreso.Columns[4].Width = 200;
            }
        }

        private void btnCancelarCumplAnularExcepcion_Click(object sender, EventArgs e)
        {
            this.accionCumplimentarExcepcion = false;
            this.accionAnularExcepcion = false;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE:";
            this.HabilitarControlesCumplimentarAnularExcepcion(false);
        }
    }
}

using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion
{
    public partial class FormAdminProhibicionAnticipada : Form
    {
        //VARIABLES GLOBALES
        DProhibicionAnticipada dProhibicion = new DProhibicionAnticipada();
        private ErrorProvider errorProvider = new ErrorProvider();
        //ID PROHIBICION GLOBAL
        int idProhibicionGlobal=0;
        
        public FormAdminProhibicionAnticipada()
        {
            InitializeComponent();
        }

        private async void FormAdminProhibicionAnticipada_Load_1(object sender, EventArgs e)
        {
            // Obtener el tamaño de la pantalla actual
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

            // Ajustar el tamaño del formulario
            if (this.Height > screenHeight)
                this.Height = screenHeight;

            if (this.Width > screenWidth)
                this.Width = screenWidth;

            // Opcional: centrar el formulario si se ajustó
            this.StartPosition = FormStartPosition.CenterScreen;

            //CARGAR LISTA SEXO
            //Carga de combo sexo
            NSexo nSexo = new NSexo();
            cmbSexoVisita.ValueMember = "id_sexo";
            cmbSexoVisita.DisplayMember = "sexo";
            cmbSexoVisita.DataSource = await nSexo.RetornarListaSexo();

            //acceder a la instancia de FormTramites abierta.
            FormProhibicionesAnticipadas formProhibicion = Application.OpenForms["FormProhibicionesAnticipadas"] as FormProhibicionesAnticipadas;

            //OBTENER ID PROHIBICION GLOBAL DE FORMULARIO D EVISITAS ANTICIPADAS          
            idProhibicionGlobal = Convert.ToInt32(formProhibicion.idProhibicionAnticipadaGlobal);
            
            //CARGAR DATOS DE LA PROHIBICION EN FORMULARIO
            this.dProhibicion = await this.BuscarProhibicion(idProhibicionGlobal);
            //cargar datos de la prohibicion en formulario
            this.CargarFormularioProhibicion();
        }
        //FIN LOAD FORMULARIO

        //REGION PROHIBICIONES
        #region PROHIBICIONES

        //VER PROHIBICIONES
        private void btnVerProhibiciones_Click(object sender, EventArgs e)
        {


        }
        //FIN VER PROHIBICIONES................................


        //DATA GRID PROHIBICIONES
        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;


                if (dtgvProhibiciones.SelectedRows.Count > 0)
                {
                    int idProhibicion;
                    idProhibicion = Convert.ToInt32(dtgvProhibiciones.CurrentRow.Cells["ID"].Value.ToString());

                    if (idProhibicion > 0)
                    {
                        txtIdProhibicion.Text = idProhibicion.ToString();
                        txtDisposicion.Text = dtgvProhibiciones.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDetalle.Text = dtgvProhibiciones.CurrentRow.Cells["Detalle"].Value.ToString();
                        dtpFechaInicio.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaInicio"].Value.ToString());
                        dtpFechaFin.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaFin"].Value.ToString());
                        txtOrganismo.Text = dtgvProhibiciones.CurrentRow.Cells["Organismo"].Value.ToString();
                        dtpFechaProhibicion.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaProhibicion"].Value.ToString());
                        chkVigente.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Vigente"].Value.ToString());
                        chkAnulado.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Anulado"].Value.ToString());


                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATA GRID PROHIBICIONES...............................................

        #endregion PROHIBICIONES
        //FIN REGION PROHIBICIONES............................................................
        //........................................................................................


        //REGION EDICION PROHIBICION
        #region EDICION PROHIBICION

        //BOTON eDITAR PROHIBICION
        private void btnEditarProhibicion_Click(object sender, EventArgs e)
        {
            if (!btnLevantar.Enabled)
            {
                MessageBox.Show("No puede editar mientras esta levantando la prohibicion", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControlesEdicion(true);
        }
        //FIN BOTON eDITAR PROHIBICION.................................................

        //BOTON CANCELAR PRHIBICION
        private void btnCancelarProhibicion_Click(object sender, EventArgs e)
        {
            //cargar datos del prohibicion en formulario
            this.CargarFormularioProhibicion();

            this.HabilitarControlesEdicion(false);
        }
        //FIN BOTON CANCELAR PRHIBICION..................................................

        //BOTON GUARDAR PROHIBICON
        private async void btnGuardarProhibicion_Click(object sender, EventArgs e)
        {
            NProhibicionVisitaAnticipada nProhibicionAnticipada = new NProhibicionVisitaAnticipada();
            Boolean enviar = true;

            //EDITAR
            if (!string.IsNullOrEmpty(txtIdProhibicionAnticipada.Text))
            {
                var data = new
                {
                    dni_visita = Convert.ToInt32(txtDniVisita.Text),
                    apellido_visita = txtApellidoVisita.Text,
                    nombre_visita = txtNombreVisita.Text,
                    sexo_id = cmbSexoVisita.SelectedValue,
                    detalle = txtDetalleProhibicionAnticipada.Text,
                    apellido_interno = txtApellidoInterno.Text,
                    nombre_interno = txtNombreInterno.Text,
                    is_exinterno = chkExInterno.Checked,
                    fecha_inicio = dtpkFechaInicioProhibicion.Value,
                    fecha_fin = dtpkFechaFinProhibicion.Value,
                    detalle_motivo = txtMotivoDetalle.Text
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nProhibicionAnticipada.EditarProhibicion(Convert.ToInt32(txtIdProhibicionAnticipada.Text), dataProhibicion);

                if (respuestaEditar)
                {

                    MessageBox.Show("La edición de la prohibición se realizó correctamente", "Restricción Visitass", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.HabilitarControlesEdicion(false);

                    //CARGAR DATOS DE LA PROHIBICION EN FORMULARIO
                    this.dProhibicion = await this.BuscarProhibicion(this.idProhibicionGlobal);
                    this.CargarFormularioProhibicion();

                }
                else
                {
                    MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //FIN EDITAR.........................................................
        }
        //FIN BOTON GUARDAR PROHIBICON..........................................

        //HABILITAR CONTROLES
        private void HabilitarControlesEdicion(bool habilitar)
        {
            txtApellidoVisita.ReadOnly = !habilitar;
            txtNombreVisita.ReadOnly = !habilitar;
            txtDniVisita.ReadOnly = !habilitar;
            cmbSexoVisita.Enabled = habilitar;
            dtpkFechaInicioProhibicion.Enabled = habilitar;
            dtpkFechaFinProhibicion.Enabled = habilitar;
            txtDetalleProhibicionAnticipada.ReadOnly = !habilitar;
            txtApellidoInterno.ReadOnly = !habilitar;
            txtNombreInterno.ReadOnly = !habilitar;
            chkExInterno.Enabled = habilitar;
            txtMotivoDetalle.ReadOnly = !habilitar;
            txtMotivoDetalle.Text = "";

            btnEditarProhibicion.Enabled = !habilitar;
            btnGuardarProhibicion.Enabled = habilitar;
            btnCancelarProhibicion.Enabled = habilitar;

            //botones de levantar
            btnLevantar.Enabled = !habilitar;
        }

        //FIN HABILITAR CONTROLES...............................................

        //CARGAR PROHOBICION EN FORMULARIO
        private void CargarFormularioProhibicion()
        {
            txtIdProhibicionAnticipada.Text = this.dProhibicion.id_prohibicion_anticipada.ToString();
            txtApellidoVisita.Text = this.dProhibicion.apellido_visita;
            txtNombreVisita.Text = this.dProhibicion.nombre_visita;
            txtDniVisita.Text = this.dProhibicion.dni_visita.ToString();
            cmbSexoVisita.SelectedValue = this.dProhibicion.sexo_id;
            txtDetalleProhibicionAnticipada.Text = this.dProhibicion.detalle;
            txtApellidoInterno.Text = this.dProhibicion.apellido_interno;
            txtNombreInterno.Text = this.dProhibicion.nombre_interno;
            dtpkFechaInicioProhibicion.Value = this.dProhibicion.fecha_inicio;
            dtpkFechaFinProhibicion.Value = this.dProhibicion.fecha_fin;
            txtTipoLevantamiento.Text = this.dProhibicion.tipo_levantamiento;
            txtFechaProhibicion.Text = this.dProhibicion.fecha_prohibicion.ToShortDateString(); 
            chkExInterno.Checked = this.dProhibicion.is_exinterno;
            chkProhibicionVigente.Checked = this.dProhibicion.vigente;
            txtUsuarioAlta.Text = this.dProhibicion.usuario.apellido + " " + this.dProhibicion.usuario.nombre;
            txtOrganismoAlta.Text = this.dProhibicion.organismo.organismo;
        }


        //FIN CARGAR PROHIBICION EN FORMULARIO.......................................

        #endregion EDICION PROHIBICION
        //FIN REGION PROHIBICION.....................................................
        //...........................................................................


        //REGION LEVANTAR PROHIBICION
        #region LEVANTAR PROHIBICION        

        //BOTON LEVANTAR
        private void btnLevantar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicionAnticipada.Text == null || txtIdProhibicionAnticipada.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ( !btnEditarProhibicion.Enabled)
            {
                MessageBox.Show("No puede levantar la prohibicion mientras esta editando", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControlesLevantar(true);
        }
        //FIN BOTON LEVANTAR..................................................................

        //BOTON CANCELAR LEVANTAR
        private void btnCancelarLevantar_Click(object sender, EventArgs e)
        {

            this.HabilitarControlesLevantar(false);
        }
        //FIN BOTON CANCELAR LEVANTAR..........................................

        //BOTON GUARDAR LEVANTAR
        private async void btnGuardarLevantar_Click(object sender, EventArgs e)
        {
            NProhibicionVisitaAnticipada nProhibicionAnticipada = new NProhibicionVisitaAnticipada();

            var data = new
            {
                detalle_motivo = txtMotivoLevantar.Text,
                fecha_fin = dtpFechaFinLevantar.Value,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);


            bool respuestaOk = false;
            string mensajeRespuesta = "";

            
            (bool respuestaEditar, string errorResponse) = await nProhibicionAnticipada.LevantarManualProhibicion(Convert.ToInt32(txtIdProhibicionAnticipada.Text), dataEnviar);

            if (respuestaEditar)
            {
                respuestaOk = true;
                mensajeRespuesta = "El levantamiento de la prohibición se realizó correctamente";
            }
            else
            {
                mensajeRespuesta = errorResponse;
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //CARGAR DATOS DE LA PROHIBICION EN FORMULARIO
                this.dProhibicion = await this.BuscarProhibicion(this.idProhibicionGlobal);
                this.CargarFormularioProhibicion();

                this.HabilitarControlesLevantar(false);
                                
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON LEVANTAR.....................................................


        //HABILITAR CONTROLES LEVANTAR
        private void HabilitarControlesLevantar(bool habilitar)
        {
            dtpFechaFinLevantar.Enabled = habilitar;
            txtMotivoLevantar.Enabled = habilitar;
            txtMotivoLevantar.Text = "";

            btnLevantar.Enabled = !habilitar;
            btnGuardarLevantar.Enabled = habilitar;
            btnCancelarLevantar.Enabled = habilitar;

            //botones de Edicion
            btnEditarProhibicion.Enabled = !habilitar;
        }
        //FIN HABILITAR CONTROLES LEVANTAR

        #endregion LEVANTAR PROHIBICION
        //FIN REGION LEVANTAR......................................................
        //..........................................................................
    
        //BUSCAR PROHIBICION
        private async Task<DProhibicionAnticipada> BuscarProhibicion(int idProhibicionx)
        {
            NProhibicionVisitaAnticipada nProhibicion = new NProhibicionVisitaAnticipada();
            (DProhibicionAnticipada dProhibicionX, string errorResponse) = await nProhibicion.BuscarProhibicionXId(idProhibicionx);

            this.dProhibicion = dProhibicionX;

            if (this.dProhibicion == null)
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return dProhibicionX;
        }
        //FIN BUSCAR PROHIBICION......................................
    }


}

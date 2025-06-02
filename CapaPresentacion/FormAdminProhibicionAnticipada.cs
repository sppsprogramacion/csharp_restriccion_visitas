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
        //la accion puede ser prohibir, levantar o quitar
        string accionProhibir = "";
        string accionProhibirParentesco = "";
        //cumplimentar/anular excepcion
        bool accionCumplimentarExcepcion = false;
        bool accionAnularExcepcion = false;
        //vigencia vinculo
        bool accionRevincularVinculo = false;
        bool accionDesvincularVinculo = false;

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
            NProhibicionVisitaAnticipada nProhibicion = new NProhibicionVisitaAnticipada();

            //ID PROHIBICION GLOBAL
            int idProhibicionGlobal;
            idProhibicionGlobal = Convert.ToInt32(formProhibicion.idProhibicionAnticipadaGlobal);
            (DProhibicionAnticipada dProhibicionX, string errorResponse) = await nProhibicion.BuscarProhibicionXId(idProhibicionGlobal);

            this.dProhibicion = dProhibicionX;

            if (this.dProhibicion == null)
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtIdProhibicionAnticipada.Text = this.dProhibicion.id_prohibicion_anticipada.ToString();
            txtApellidoVisita.Text = this.dProhibicion.apellido_visita;
            txtNombreVisita.Text = this.dProhibicion.nombre_visita;
            txtDniVisita.Text = this.dProhibicion.dni_visita.ToString();
            txtDetalleProhibicionAnticipada.Text = this.dProhibicion.detalle;
            txtApellidoInterno.Text = this.dProhibicion.apellido_interno;
            txtNombreInterno.Text = this.dProhibicion.nombre_interno;
            txtFechaInicio.Text = this.dProhibicion.fecha_inicio.ToShortDateString();
            txtFechaFin.Text = this.dProhibicion.fecha_fin.ToShortDateString();
            txtTipoLevantamiento.Text = this.dProhibicion.tipo_levantamiento;
            chckExInterno.Checked = this.dProhibicion.is_exinterno;
            chkProhibicionVigente.Checked = this.dProhibicion.vigente;
            txtUsuarioAlta.Text = this.dProhibicion.usuario.apellido + " " + this.dProhibicion.usuario.nombre;
            txtOrganismoAlta.Text = this.dProhibicion.organismo.organismo;

        }

        //REGION PROHIBICIONES
        #region Prohibiciones

        //VER PROHIBICIONES
        private void btnVerProhibiciones_Click(object sender, EventArgs e)
        {
            

        }
        //FIN VER PROHIBICIONES................................

        //GUARDAR NUEVA PROHIBICION O NODIFICACION
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            Boolean enviar = true;

            //NUEVO
            if ( txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {
                    txtIdCiudadano = Convert.ToInt32(txtIdProhibicionAnticipada.Text),
                    txtDisposicion = txtDisposicion.Text,
                    txtDetalle = txtDetalle.Text,
                    dtpFechaInicio = dtpFechaInicio.Value,
                    dtpFechaFin = dtpFechaFin.Value,
                };

                var validator = new ProhibicionValidator();
                var result = validator.Validate(datosFormulario);

                if (!result.IsValid)
                {
                    enviar = false;
                    MessageBox.Show("Complete correctamente los campos del formulario","Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (var failure in result.Errors)
                    {
                        
                        Control control = Controls.Find(failure.PropertyName, true)[0];
                        errorProvider.SetError(control, failure.ErrorMessage);
                    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                    return;
                }

                //enviar datos si son correctos
                var data = new
                {
                    ciudadano_id = Convert.ToInt32(txtIdProhibicionAnticipada.Text),
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);
                
                (DProhibicionVisita dataRespuesta, string errorResponse) = await nProhibicionVisita.CrearProhibicion(dataProhibicion);
                    
                if (dataRespuesta != null)
                {                        
                    MessageBox.Show("La prohibición se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.HabilitarControles(false);
                    this.LimpiarControles();

                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                                        
                    //cargar lista de ciudadanos en datagrid
                    
                }
                else
                {
                    MessageBox.Show( errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            //FIN NUEVO............................................................

            //EDITAR
            if (!string.IsNullOrEmpty(txtIdProhibicion.Text))
            {
                var data = new
                {
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                    detalle_motivo = txtMotivo.Text,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);
               
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.EditarProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataProhibicion);
                if (respuestaEditar)
                {
                        
                    MessageBox.Show("La edición de la prohibición se realizó correctamente", "Restricción Visitass", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.LimpiarControles();
                    this.HabilitarControles(false);

                    //cargar lista de prhibiciones en datagrid
                                            
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                }
                else
                {                        
                    MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                

            }
            //FIN EDITAR.........................................................
        }
        //FIN GUARDAR NUEVA PROHIBICION O NODIFICACION.........................

        //DATA GRID PROHIBICIONES
        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (btnGuardar.Enabled == true || btnGuardarQP.Enabled == true)
                {
                    MessageBox.Show("No puede se puede seleccionar una prohibición mientras se esta editando o se está agregando una nueva prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                        dtgvHistorialProhibicion.DataSource = "";
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATA GRID PROHIBICIONES...............................................

        //CANCELAR NUEVA PROHIBICION O MODIFICIACION
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.HabilitarControles(false);
            this.LimpiarControles();
            
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        //FIN CANCELAR NUEVA PROHIBICION O MODIFICIACION..............................

        //HABILITAR EDICION
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControles(true);
            this.txtMotivo.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        //FIN HABILITAR EDICION................................................


        //HABILITAR PARA NUEVA PROHIBICION
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.HabilitarControles(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            dtgvHistorialProhibicion.DataSource = "";
        }
        //FIN HABILITAR PARA NUEVA PROHIBICION.........................

        //LEVANTAR PROHIBICION
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "levantar";
            this.HabilitarControlesQP(true);
        }
        //FIN LEVANTAR PROHIBICION............................................

       
        //ANULAR PROHIBICION
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "anular";
            this.HabilitarControlesQP(true);
        }
        //FIN ANULAR PROHIBICION...............................................................

        //CANCELAR LEVANTAR Y ANULAR
        private void btnCancelarQP_Click(object sender, EventArgs e)
        {
            btnQuitar.Enabled = true;
            btnAnular.Enabled = true;
            this.HabilitarControlesQP(false);
            this.LimpiarControlesQP();
        }
        //FIN CANCELAR LEVANTAR Y ANULAR .......................

        //GUARDAR LEVANTAR Y ANULAR
        private async void btnGuardarQP_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            
            var data = new
            {
                detalle_motivo = txtMotivoQP.Text,
                fecha_fin = dtpFechaFinQP.Value,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);

            
            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionProhibir == "levantar")
            {
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.LevantarManualProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El levantamiento de la prohibición se realizó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }
            

            if (this.accionProhibir == "anular")
            {
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.AnularProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibición se anuló correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }            

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas",MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //INICIALIZACION CONTROLES LEVANTAMIENTO                        
                this.HabilitarControlesQP(false);
                this.LimpiarControlesQP();

                //INICIALIZACION DE CONTROLES PROHIBICION
                this.LimpiarControles();
                this.HabilitarControles(false);

                //cargar lista de prhibiciones en datagrid
                

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        //FIN GUARDAR LEVANTAR, PROHIBIR Y ANULAR..................................................................

        
        //METODO PARA OBTENER HISTORIAL DE UNA PROHIBICION Y CARGARLO EN UN DATA GRID  
        private async void CargarDataGridHistorialProhibiciones(int idProhibicion)
        {
            NBitacoraProhibicionVisita nBitacoraProhibicionVisita = new NBitacoraProhibicionVisita();
            List<DBitacoraProhibicionVisita> listaBitacoraProhibicionesVisita = new List<DBitacoraProhibicionVisita>();
            listaBitacoraProhibicionesVisita = await nBitacoraProhibicionVisita.RetornarListaBitacoraProhibicionesVisita(idProhibicion);

            var datosfiltrados = listaBitacoraProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_bitacora_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Motivo = c.motivo,
                    DetalleMotivo = c.detalle_motivo,
                    FechaCambio = c.fecha_cambio,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvHistorialProhibicion.DataSource = datosfiltrados;            

        }
        //FIN METODO PARA OBTENER HISTORIAL DE UNA PROHIBICION Y CARGARLO EN UN DATA GRID...........

        //HABILITAR CONTROLES
        private void HabilitarControles(bool valor)
        {            
            txtDisposicion.Enabled = valor;
            txtDetalle.ReadOnly = !valor;
            dtpFechaInicio.Enabled = valor;
            dtpFechaFin.Enabled = valor;
            txtMotivo.Enabled = false;
            dtgvHistorialProhibicion.DataSource = "";

            //botnes de quitar prohibicion
            btnQuitar.Enabled = !valor;
            btnAnular.Enabled = !valor;
        }        
        //FIN HABILITAR CONTROLES

        //LIMPIAR CONTROLES
        private void LimpiarControles()
        {
            //limpiar errores
            errorProvider.Clear();

            txtIdProhibicion.Text = string.Empty;
            txtDisposicion.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            dtpFechaInicio.Text = string.Empty;
            dtpFechaFin.Text = string.Empty;
            txtOrganismo.Text = string.Empty;
            dtpFechaProhibicion.Text = string.Empty;
            chkVigente.Checked = false;
            chkAnulado.Checked = false;
            txtMotivo.Text = string.Empty;
        }
        //FIN LIMPIAR CONTROLES...................................

        

        //HABILITAR CONTROLES QUITAR/PROHIBIR
        private void HabilitarControlesQP(bool valor)
        {
            dtpFechaFinQP.Enabled = valor;
            txtMotivoQP.Enabled = valor;

            btnAnular.Enabled = !valor;
            btnQuitar.Enabled = !valor;

            btnGuardarQP.Enabled = valor;
            btnCancelarQP.Enabled = valor;

            //botones de prohibicion
            btnNuevo.Enabled = !valor;
            btnEditar.Enabled = !valor;
        }
        //FIN HABILITAR QUITAR/PRHIBIR

        //LIMPIAR CONTROLES QUITAR/PROHIBIR
        private void LimpiarControlesQP()
        {
            dtpFechaFinQP.Text = string.Empty;
            txtMotivoQP.Text = string.Empty;
            
        }
        //FIN LIMPIAR QUITAR/PRHIBIR........................

        //HISTORIAL DE UNA PROHIBICION
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición","Restricción Visitas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                this.CargarDataGridHistorialProhibiciones(Convert.ToInt32(txtIdProhibicion.Text));
            }
        }
        //FIN HISTORIAL DE UNA PROHIBICION.....................

        #endregion
        //FIN REGION PROHIBICIONES............................................................
        //........................................................................................

        //REGION PARENTESCOS
        #region Parentescos

        
        //BOTON VER PARENTESCOS..................................................................
        private void btnVerParentescos_Click(object sender, EventArgs e)
        {
            //formulario parentesco actual
            txtIdVisitaInterno.Text = "";
            txtInternoVinculado.Text = "";
            txtParentesco.Text = "";

            //formulario modificacion
            cmbParentescos.Enabled = false;
            txtMotivoModificarParentesco.Text = "";
            txtMotivoModificarParentesco.Enabled = false;
            btnModificarParentesco.Enabled = true;
            btnGuardarModificarParentesco.Enabled = false;
            btnCancelarModificarParentesco.Enabled = false;

            
        }
        //FIN VER´PARENTESCOS....................................................

        //BOTON PROHIBIR PARENTESCO
        private void btnProhibirParent_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibirParentesco = "prohibir";

            //habilitar controles
            this.HabilitarControlesProhibicionParentescos(true);
            
        }
        //FIN BOTON PROHIBIR PARENTESCO

        //BOTON LEVANTAR PROHIBICION PARENTESCO
        private void btnLevantarProhibirParent_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibirParentesco = "levantar";

            //habilitar controles
            this.HabilitarControlesProhibicionParentescos(true);
            
        }
        //FIN BOTON LEVANTAR PROHIBICION PARENTESCO..............................................


        //BOTON GUARDAR PROHIBIR PARENTESCO
        private async void btnGuardarPohibPar_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //prohibir parentesco
            if (this.accionProhibirParentesco == "prohibir")
            {
                var data = new
                {
                    fecha_inicio = dtpFechaIniProhibirParentesco.Value,
                    fecha_fin = dtpFechaFinProhibirParentesco.Value,
                    detalles_prohibicion = txtDetalleProhibirParentesco.Text,
                };

                string dataProhibir = JsonConvert.SerializeObject(data);

                (bool respuestaProhibir, string errorResponse) = await nVisitaInterno.ProhibirParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataProhibir);

                if (respuestaProhibir)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se prohibió correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            //levantar prohibicion parentesco
            if (this.accionProhibirParentesco == "levantar")
            {
                var data = new
                {
                    fecha_fin = dtpFechaFinProhibirParentesco.Value,
                    detalle_levantamiento = txtDetalleProhibirParentesco.Text,
                };

                string dataLevantar = JsonConvert.SerializeObject(data);

                (bool respuestaLevantar, string errorResponse) = await nVisitaInterno.LevantarProhibicionParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataLevantar);

                if (respuestaLevantar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibicion del parentesco se levnato correctamente";
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

                //deshabilitar controles
                this.HabilitarControlesProhibicionParentescos(false);

                //cargar lista de prhibiciones en datagrid
                

            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR PROHIBIR PARENTESCO.........................................

        //BOTON CANCELAR PROHIBICION PARENTESCO
        private void btnCancelarPohibPar_Click(object sender, EventArgs e)
        {
            this.accionProhibirParentesco = "";

            //deshabilitar controles
            this.HabilitarControlesProhibicionParentescos(false);
            
        }
        //FIN BOTON CANCELAR PROHIBICION PARENTESCO......................................


        //SECCION REVINCULACION/DESVINCULACION PARENTESCO
        #region VINCULACION PARENTESCO
        //BOTON REVINCULAR
        private void btnRevincular_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionRevincularVinculo = true;
            this.accionDesvincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(true);
        }
        //FIN BOTON REVINCULAR.......................................................

        //BOTON DESVINCULAR
        private void btnDesvincular_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionDesvincularVinculo = true;
            this.accionRevincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(true);
        }
        //FIN BOTON DESVINCULAR...............................................................

        //BOTON CANCELAR VINCULACION
        private void btnCancelarVinculacionParentesco_Click(object sender, EventArgs e)
        {
            this.accionRevincularVinculo = false;
            this.accionDesvincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(false);
        }
        //FIN BOTON CANCELAR VINCULACION...........................................................

        //BOTON GUARDAR VINCULACION
        private async void btnGuardarVinculacionParentesco_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //prohibir parentesco
            if (this.accionRevincularVinculo)
            {
                var data = new
                {
                    detalles_vigencia = txtDetalleVinculacionParentesco.Text,
                };

                string dataActualizar = JsonConvert.SerializeObject(data);

                (bool respuestaRevincular, string errorResponse) = await nVisitaInterno.RevincularParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataActualizar);

                if (respuestaRevincular)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se revinculó correctamente";
                    MessageBox.Show("Revinculado", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }

                this.accionRevincularVinculo = false;
            }

            //Desvincular parentesco
            if (this.accionDesvincularVinculo)
            {
                var data = new
                {
                    detalles_vigencia = txtDetalleVinculacionParentesco.Text,
                };

                string dataActualizar2 = JsonConvert.SerializeObject(data);

                (bool respuestaDesvincular, string errorResponse) = await nVisitaInterno.DesvincularParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataActualizar2);

                if (respuestaDesvincular)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se desvinculó correctamente";
                    MessageBox.Show("desvinculado", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }

                this.accionDesvincularVinculo = false;
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //deshabilitar controles
                this.HabilitarControlesVinculacionParentescos(false);

                //cargar lista de prhibiciones en datagrid
                

            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR VINCULACION.......................................................
        #endregion VINCULACION PARENTESCO
        //FIN SECCION REVINCULACION/DESVINCULACION PARENTESCO.......................................

        //DATA GRID PARENTESCOS
        private void dtgvParentescos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvParentescos.SelectedRows.Count > 0)
                {
                    int id_visita_interno;
                    id_visita_interno = Convert.ToInt32(dtgvParentescos.CurrentRow.Cells["ID"].Value.ToString());

                    //deshabilitar controles parentescos
                    this.HabilitarControlesProhibicionParentescos(false);
                    this.HabilitarControlesVinculacionParentescos(false);
                    this.HabilitarControlesCambioParentesco(false);

                    if (id_visita_interno > 0)
                    {
                        txtIdVisitaInterno.Text = id_visita_interno.ToString();
                        txtInternoVinculado.Text = dtgvParentescos.CurrentRow.Cells["Interno"].Value.ToString();
                        txtParentesco.Text = dtgvParentescos.CurrentRow.Cells["Parentesco"].Value.ToString();
                                                
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATA GRID PARENTESCOS.......................................
        
        //BOTON MODIFICAR PARENTESCO
        private void btnModificarParentesco_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar una vinculación", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControlesCambioParentesco(true);
        }
        //FIN BOTON MODIFICAR PARENTESCO..................................................

        //BOTON GUARDAR MODIFICAR PARENTESCO
        private async void btnGuardarModificarParentesco_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            //EDITAR
            if (txtIdVisitaInterno.Text != null || txtIdVisitaInterno.Text != "")
            {
                var data = new
                {
                    parentesco_id = cmbParentescos.SelectedValue,
                    detalle_motivo = txtMotivoModificarParentesco.Text
                };

                string dataVisitaInterno = JsonConvert.SerializeObject(data);

                try
                {
                    (bool respuestaEditar, string errorResponse) = await nVisitaInterno.CambiarParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataVisitaInterno);

                    if (respuestaEditar)
                    {

                        MessageBox.Show("El cambio de parentesco se realizó correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //this.LimpiarControles();
                        //this.HabilitarControles(false);


                        //cargar lista de prhibiciones en datagrid
                        

                        //formulario parentesco actual
                        txtIdVisitaInterno.Text = "";
                        txtInternoVinculado.Text = "";
                        txtParentesco.Text = "";

                        //formulario modificacion
                        this.HabilitarControlesCambioParentesco(false);
                    }
                    else
                    {
                        MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            //FIN EDITAR.........................................................
        }
        //FIN BOTON GUARDAR MODIFICAR PARENTESCO
                

        //BOTON CANCELAR MODIFICAR PARENTESCO
        private void btnCancelarModificarParentesco_Click(object sender, EventArgs e)
        {
            //formulario modificacion
            this.HabilitarControlesCambioParentesco(false);
        }
        //FIN BOTON MODIFICAR PARENTESCO...................................

        //METODO HABILITAR CONTROLES PROHIBICION VINCULO
        private void HabilitarControlesProhibicionParentescos(bool habilitar)
        {            
            dtpFechaIniProhibirParentesco.ResetText();
            dtpFechaIniProhibirParentesco.Enabled = habilitar;
            //determinar si se esta prohibiendo para habilitar la fecha de inicio, sino debe permaneces deshabilitado
            if (this.accionProhibirParentesco == "levantar")
            {
                dtpFechaIniProhibirParentesco.ResetText();
                dtpFechaIniProhibirParentesco.Enabled = false;
            }
            dtpFechaFinProhibirParentesco.ResetText();
            dtpFechaFinProhibirParentesco.Enabled = habilitar;
            txtDetalleProhibirParentesco.Enabled = habilitar;
            txtDetalleProhibirParentesco.Text = "";

            btnProhibirParent.Enabled = !habilitar;
            btnLevantarProhibirParent.Enabled = !habilitar;
            btnGuardarPohibPar.Enabled = habilitar;
            btnCancelarPohibPar.Enabled = habilitar;
        }
        //METODO HABILITAR CONTROLES PROHIBICION VINCULO

        //METODO HABILITAR CONTROLES VINCULACION VINCULO
        private void HabilitarControlesVinculacionParentescos(bool habilitar)
        {
            txtDetalleVinculacionParentesco.Enabled = habilitar;
            txtDetalleVinculacionParentesco.Text = "";

            btnRevincular.Enabled = !habilitar;
            btnDesvincular.Enabled = !habilitar;
            btnGuardarVinculacionParentesco.Enabled = habilitar;
            btnCancelarVinculacionParentesco.Enabled = habilitar;
        }
        //METODO HABILITAR CONTROLES VINCULACION VINCULO

        //METODO HABILITAR CONTROLES CAMBIO PARENTESCO
        private void HabilitarControlesCambioParentesco(bool habilitar)
        {
            cmbParentescos.Enabled = habilitar;
            txtMotivoModificarParentesco.Text = "";
            txtMotivoModificarParentesco.Enabled = habilitar;
            btnModificarParentesco.Enabled = !habilitar;
            btnGuardarModificarParentesco.Enabled = habilitar;
            btnCancelarModificarParentesco.Enabled = habilitar;
        }

        private void pagProhibicion_Click(object sender, EventArgs e)
        {

        }

        //FIN METODO HABILITAR CONTROLES CAMBIO PARENTESCO
        #endregion
        //FIN REGION PARENTESCOS..........................................................
        //.................................................................................


    }


}

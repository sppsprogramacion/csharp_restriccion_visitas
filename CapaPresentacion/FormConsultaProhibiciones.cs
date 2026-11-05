using CapaDatos;
using CapaNegocio;
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
    public partial class FormConsultaProhibiciones : Form
    {
        public FormConsultaProhibiciones()
        {
            InitializeComponent();
        }

        private void btnVerProhibiciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridProhibiciones("todas");
        }

        private void btnProhibicionesVigentes_Click(object sender, EventArgs e)
        {
            this.CargarDataGridProhibiciones("vigentes");
        }



        private async void btnControlarProhibiciones_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();

            this.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.LevantarProhibicionesConcontrol();
            this.Enabled = true;

            if (respuestaEditar)
            {
                MessageBox.Show("Se levantaron prohibiciones correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //cargar lista de prhibiciones en datagrid
                this.CargarDataGridProhibiciones("vigentes");
            }
            else
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

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
                        txtVisita.Text = dtgvProhibiciones.CurrentRow.Cells["Visita"].Value.ToString();
                        txtDni.Text = dtgvProhibiciones.CurrentRow.Cells["Dni"].Value.ToString();

                        txtDisposicion.Text = dtgvProhibiciones.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDetalle.Text = dtgvProhibiciones.CurrentRow.Cells["Detalle"].Value.ToString();
                        dtpFechaInicio.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaInicio"].Value.ToString());
                        dtpFechaFin.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaFin"].Value.ToString());
                        txtOrganismo.Text = dtgvProhibiciones.CurrentRow.Cells["Organismo"].Value.ToString();
                        dtpFechaProhibicion.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaProhibicion"].Value.ToString());
                        chkVigente.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Prohibida"].Value.ToString());


                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var frmHistorial = new FormHistorialProhibicion(Convert.ToInt32(txtIdProhibicion.Text));
                frmHistorial.ShowDialog();
            }
        }


        //METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES
        async private void CargarDataGridProhibiciones(string tipoConsulta)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            List<DProhibicionVisita> listaProhibicionesVisita = null;
            string error = "";

            if (tipoConsulta == "todas")
            {
                (List<DProhibicionVisita> listaProhibicionesVisitaResponse, string errorResponse) = await nProhibicionVisita.RetornarListaProhibicionesXOrganismoFecha(this.dtpFechaInicioSabana.Value.ToString("yyyy-MM-dd"), this.dtpFechaFinSabana.Value.ToString("yyyy-MM-dd"));
                listaProhibicionesVisita = listaProhibicionesVisitaResponse;
                error = errorResponse;
            }

            if (tipoConsulta == "vigentes")
            {
                (List<DProhibicionVisita> listaProhibicionesVisitaResponse, string errorResponse) = await nProhibicionVisita.RetornarListaProhibicionesVigentesXOrganismoFecha(this.dtpFechaInicioSabana.Value.ToString("yyyy-MM-dd"), this.dtpFechaFinSabana.Value.ToString("yyyy-MM-dd"));
                listaProhibicionesVisita = listaProhibicionesVisitaResponse;
                error = errorResponse;
            }

            if (listaProhibicionesVisita == null)
            {
                MessageBox.Show(error, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_prohibicion_visita,
                    Visita= c.ciudadano.apellido + " " + c.ciudadano.nombre,
                    Dni = c.ciudadano.dni,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    FechaProhibicion = c.fecha_prohibicion,
                    Organismo = c.organismo.organismo,
                    Prohibida = c.vigente,
                    TipoLevantamiento = c.tipo_levantamiento

                })
                .ToList();

            dtgvProhibiciones.DataSource = datosfiltrados;

            if (listaProhibicionesVisita.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvProhibiciones.Columns[0].Width = 50;
                dtgvProhibiciones.Columns[1].Width = 180;
                dtgvProhibiciones.Columns[2].Width = 80;
                dtgvProhibiciones.Columns[4].Width = 300;
                dtgvProhibiciones.Columns[5].Width = 80;
                dtgvProhibiciones.Columns[6].Width = 80;
                dtgvProhibiciones.Columns[7].Width = 80;
                dtgvProhibiciones.Columns[8].Width = 150;
            }

            foreach (DataGridViewRow row in dtgvProhibiciones.Rows)
            {
                if (row.Cells["Prohibida"].Value != null && Convert.ToBoolean(row.Cells["Prohibida"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.Black;    // Cambiar color del texto
                }

            }


        }        
        //FIN METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES...........

    }
}

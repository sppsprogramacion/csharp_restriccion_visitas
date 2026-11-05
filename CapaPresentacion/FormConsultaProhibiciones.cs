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

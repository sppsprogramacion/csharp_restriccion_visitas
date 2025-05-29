using CapaDatos;
using CapaNegocio;
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

namespace CapaPresentacion
{
    public partial class FormProhibicionesAnticipadas : Form
    {
        //variable global id_ciudadano
        public int idCiudadanoGlobal { get; set; }

        
        public FormProhibicionesAnticipadas()
        {
            InitializeComponent();
        }

        private void Visitas_Load(object sender, EventArgs e)
        {

            //cargar lista de ciudadanos en datagrid
            //this.CargarDataGridCiudadanos();
        }


        //METODO PARA OBTENER LA LISTA DE CIUDADANOS Y CARGARLO EN UN DATA GRID DE CIUDADANOS
        async private void CargarDataGridPRohibiciones()
        {
            NCiudadano nCiudadano = new NCiudadano();
            //List<DCiudadano> listaCiudadanos = new List<DCiudadano>();
            (List<DCiudadano> listaCiudadanos, string error) = await nCiudadano.RetornarListaCiudadanos();

            if(listaCiudadanos == null)
            {
                MessageBox.Show(error, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    ID = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo
                    
                })
                .ToList();

            dtgvProhibicionesAnticipadas.DataSource = datosFiltrados;
        }

       

        private void dtgvVisitas_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idCiudadanoGlobal = Convert.ToInt32(dtgvProhibicionesAnticipadas.CurrentRow.Cells["ID"].Value.ToString());

                if (dtgvProhibicionesAnticipadas.SelectedRows.Count > 0)
                {
                    if (this.idCiudadanoGlobal > 0)
                    {
                        FormAdminVisita formAdminVisita = new FormAdminVisita();
                        formAdminVisita.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            NProhibicionVisitaAnticipada nProhibiciones = new NProhibicionVisitaAnticipada();
            (List<DProhibicionAnticipada> listaProhibiciones, string errorResponse) = await nProhibiciones.ListaProhibicionesXApellido(txtApellido.Text);

            if (listaProhibiciones == null)
            {
                MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaProhibiciones
                .Select(c => new
                {
                    ID = c.id_prohibicion_anticipada,
                    Apellido = c.apellido_visita,
                    Nombre = c.nombre_visita,
                    DNI = c.dni_visita,
                    Sexo = c.sexo.sexo

                })
                .ToList();

            dtgvProhibicionesAnticipadas.DataSource = datosFiltrados;

            if (listaProhibiciones.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvProhibicionesAnticipadas.Columns[0].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[1].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[2].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[3].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[4].Width = 90;
            }
        }
               
    }
}

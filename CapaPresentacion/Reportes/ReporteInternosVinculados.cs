using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class ReporteInternosVinculados : Form
    {
        private DCiudadano dCiudadano;
        private List<DVisitaInterno> internosVinculados;
                
        public ReporteInternosVinculados(DCiudadano dCiudadanox, List<DVisitaInterno> internosVinculadosx)
        {
            InitializeComponent();
            dCiudadano = dCiudadanox;
            internosVinculados = internosVinculadosx;
        }

        private void ReporteInternosVinculados_Load(object sender, EventArgs e)
        {

            this.reportInternosVinculados.RefreshReport();
        }
    }
}

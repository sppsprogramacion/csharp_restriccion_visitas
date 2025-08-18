using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones
{
    public class ProhibicionDatos
    {
        //public int id_prohibicion_visita { get; set; }
        public int txtIdCiudadano { get; set; }
        //public int organismo_id { get; set; }
        //public DateTime fecha_prohibicion { get; set; }
        public string txtDisposicion { get; set; }
        public string txtDetalle { get; set; }
        public DateTime dtpFechaInicio { get; set; }
        public DateTime dtpFechaFin { get; set; }
        //public bool vigente { get; set; }
        //public bool anulado { get; set; }

        //para edicion
        public string txtMotivo { get; set; }

        //para levantar prohibicion y prohibir
        public string txtMotivoQP { get; set; }
        public DateTime dtpFechaFinQP { get; set; }

        //para prohibir/levantar parentesco
        public DateTime dtpFechaIniProhibirParentesco { get; set; }
        public DateTime dtpFechaFinProhibirParentesco { get; set; }
        public string txtDetalleProhibirParentesco { get; set; }



    }
}

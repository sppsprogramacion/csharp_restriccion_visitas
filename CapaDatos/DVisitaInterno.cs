﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DVisitaInterno
    {
        public int id_visita_interno { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public string parentesco_id { get; set; }
        public DParentesco parentesco { get; set; }
        public bool vigente { get; set; }
        public bool anulado { get; set; }
        public bool prohibido { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime? fecha_prohibido { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string detalles_prohibicion { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }

    }
}

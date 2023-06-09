using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Modelos
{
    public class viewGridPropiedades
    {
        public int id_propiedad { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public string tipo_propiedad { get; set; }
        public int num_habitaciones { get; set; }
        public int num_banos { get; set; }
        public string estacionamiento { get; set; }
        public string estado { get; set; }
        public string tipo_contrato { get; set; }
        public int precio_inicial { get; set; }
        public string comision { get; set; }
        public int precio_final { get; set; }
    }
}
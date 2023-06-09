using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Modelos
{
    public class ViewGridEmpleado
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int tipo_tel { get; set; }
        public string telefono { get; set; }
        public string telefononu { get; set; }
         public int genero { get; set; }
        public string geners { get; set; }
        public int cargo { get; set; }
        public string cargos { get; set; }
        public int tipo_contrato { get; set; }
        public string tipoC { get; set; }
        public int sede { get; set; }
        public string sedes { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InmoviliariaWeb.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Propiedade:Base
    {
        public int id_propiedad { get; set; }
        public string direccion { get; set; }
        public int ciudad { get; set; }
        public int departamento { get; set; }
        public int tipo_propiedad { get; set; }
        public int num_habitaciones { get; set; }
        public int num_banos { get; set; }
        public int estacionamiento { get; set; }
        public int estado { get; set; }
        public int tipo_contrato { get; set; }
        public int precio_inicial { get; set; }
        public int comision { get; set; }
        public int precio_final { get; set; }
    }
}

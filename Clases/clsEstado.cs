using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsEstado
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<EstadoPropiedad> LlenarCombo()
        {
            return dbInmobiliaria.EstadoPropiedads.OrderBy(p => p.descripcion).ToList();
        }
    }
}
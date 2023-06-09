using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsTipoPropiedad
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<TiposPropiedad> LlenarCombo()
        {
            return dbInmobiliaria.TiposPropiedads.OrderBy(p => p.nombre).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsCiudad
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<Ciudad> LlenarCombo()
        {
            return dbInmobiliaria.Ciudads.OrderBy(p => p.descripcion).ToList();
        }

    }
}
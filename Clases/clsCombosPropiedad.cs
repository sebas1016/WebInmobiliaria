using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsCombosPropiedad
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<Comision> LlenarCombo()
        {
            return dbInmobiliaria.Comisions.OrderBy(p => p.descricion).ToList();
        }

    }
}
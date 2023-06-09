using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsEstacionamiento
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<Estacionamiento> LlenarCombo()
        {
            return dbInmobiliaria.Estacionamientoes.OrderBy(p => p.descripcion).ToList();
        }
    }
}
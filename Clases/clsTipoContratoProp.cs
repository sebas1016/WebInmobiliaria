using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsTipoContratoProp
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<TiposContrato> LlenarCombo()
        {
            return dbInmobiliaria.TiposContratoes.OrderBy(p => p.nombre).ToList();
        }
    }
}
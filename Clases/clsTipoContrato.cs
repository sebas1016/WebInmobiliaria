using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsTipocontrato
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public List<TiposContrato> LlenarCombo()
        {
            return dbSuper.TiposContratoes
                .OrderBy(p => p.nombre)
                .ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsCargo
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public List <Cargo> LlenarCombo()
        {
            return dbSuper.Cargoes
                .OrderBy(p => p.descripcion )
                .ToList();
        }
    }
}
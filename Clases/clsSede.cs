using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;
namespace InmoviliariaWeb.Clases
{
    public class clsSede
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public List<Sede> LlenarCombo()
        {
            return dbSuper.Sedes
                .OrderBy(p=> p.descripcion)
                .ToList();
        }
    }
}
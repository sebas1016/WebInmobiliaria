using InmoviliariaWeb.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Clases
{
    public class clsTipoTelefono
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public List<Tipo_Tel> LlenarCombo()
        {
            return dbSuper.Tipo_Tel
                .OrderBy(p => p.descripcion)
                .ToList();
        }
    }
}
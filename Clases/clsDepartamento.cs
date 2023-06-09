using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsDepartamento
    {
            
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public List<Departamento> LlenarCombo()
        {
            return dbInmobiliaria.Departamentoes.OrderBy(p => p.descripcion).ToList();
        }

    
    }
}
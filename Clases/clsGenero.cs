using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;
namespace InmoviliariaWeb.Clases
{
    public class clsGenero
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public List<Genero> LlenarCombo()
        {
            return dbSuper.Generoes
                .OrderBy(p=> p.descripcion) 
                .ToList();
        }
    }
}
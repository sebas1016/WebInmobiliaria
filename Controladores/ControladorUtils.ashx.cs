using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Clases;
using Newtonsoft.Json;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorUtils
    /// </summary>
    public class ControladorUtils : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write(LlenarComboTpTelefono());
            //context.Response.Write(LlenarComboGenero());
            //context.Response.Write(LlenarComboCiudad());
        }

      /*  private string LlenarComboTpTelefono()
        {
            clsUtils tipi_telefono = new clsUtils();
            return JsonConvert.SerializeObject(tipi_telefono.LlenarComboTpTelefono());
        }*/

        private string LlenarComboGenero()
        {
            clsUtils genero = new clsUtils();
            return JsonConvert.SerializeObject(genero.LlenarComboGenero());
        }
        private string LlenarComboCiudad()
        {
            clsUtils ciudad = new clsUtils();
            return JsonConvert.SerializeObject(ciudad.LlenarComboCiudad());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
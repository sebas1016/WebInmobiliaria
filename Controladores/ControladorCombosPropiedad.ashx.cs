using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Clases;
using Newtonsoft.Json;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorCombosPropiedad
    /// </summary>
    public class ControladorCombosPropiedad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(LlenarCombo());
        }

        private string LlenarCombo()
        {
            clsCombosPropiedad comision = new clsCombosPropiedad();
            return JsonConvert.SerializeObject(comision.LlenarCombo());
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
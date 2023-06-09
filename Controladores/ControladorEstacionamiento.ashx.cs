using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Clases;
using Newtonsoft.Json;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorEstacionamiento
    /// </summary>
    public class ControladorEstacionamiento : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(LlenarCombo());
        }

        private string LlenarCombo()
        {
            clsEstacionamiento estacionamiento = new clsEstacionamiento();
            return JsonConvert.SerializeObject(estacionamiento.LlenarCombo());
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
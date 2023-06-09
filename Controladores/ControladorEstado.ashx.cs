using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Clases;
using Newtonsoft.Json;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorEstado
    /// </summary>
    public class ControladorEstado : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(LlenarCombo());
        }

        private string LlenarCombo()
        {
            clsEstado estado = new clsEstado();
            return JsonConvert.SerializeObject(estado.LlenarCombo());
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
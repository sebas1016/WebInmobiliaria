using InmoviliariaWeb.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorSede
    /// </summary>
    public class ControladorSede : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar());
        }
        private string Procesar()
        {
            clsSede sede = new clsSede();

            return JsonConvert.SerializeObject(sede.LlenarCombo());
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
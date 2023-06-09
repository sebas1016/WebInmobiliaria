using InmoviliariaWeb.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorTipoTelefono
    /// </summary>
    public class ControladorTipoTelefono : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar());
        }
        private string Procesar()
        {
            clsTipoTelefono TipoTelefono = new clsTipoTelefono();    

            return JsonConvert.SerializeObject(TipoTelefono.LlenarCombo());
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
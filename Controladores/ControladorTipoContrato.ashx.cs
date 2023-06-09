using InmoviliariaWeb.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorTipoContrato
    /// </summary>
    public class ControladorTipoContrato : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar());
        }
        private string Procesar()
        {
            clsTipocontrato Tipocontrato = new clsTipocontrato();

            return JsonConvert.SerializeObject(Tipocontrato.LlenarCombo());
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
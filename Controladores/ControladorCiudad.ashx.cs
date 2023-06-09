using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Clases;
using Newtonsoft.Json;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorCiudad
    /// </summary>
    public class ControladorCiudad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(LlenarCombo());
        }
        private string LlenarCombo()
        {
            clsCiudad ciudad = new clsCiudad();
            return JsonConvert.SerializeObject(ciudad.LlenarCombo());
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
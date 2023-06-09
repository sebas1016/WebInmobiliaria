using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using InmoviliariaWeb.Modelos;
using Newtonsoft.Json;
using InmoviliariaWeb.Clases;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorPropiedad
    /// </summary>
    public class ControladorPropiedad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            Propiedade propiedades = JsonConvert.DeserializeObject<Propiedade>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(propiedades);
            context.Response.Write(DatosRpta);

        }

        private string Procesar(Propiedade propiedades)
        {
            clsPropiedad _propiedades = new clsPropiedad();
            _propiedades.propiedades = propiedades;
            switch (propiedades.Comando)
            {
                case "LlenarGrid":
                    return JsonConvert.SerializeObject(_propiedades.LlenarGrid());
                case "Insertar":
                    return _propiedades.Insertar();
                case "Eliminar":
                    return _propiedades.Eliminar();
                case "Actualizar":
                    return _propiedades.Actualizar();
                default:
                    return "sin implementar";
            }
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
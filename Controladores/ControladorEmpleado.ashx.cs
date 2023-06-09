using InmoviliariaWeb.Clases;
using InmoviliariaWeb.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorEmpleado
    /// </summary>
    public class ControladorEmpleado : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            Empleado empleado = JsonConvert.DeserializeObject<Empleado>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(empleado);
            context.Response.Write(DatosRpta);
        }
        private string Procesar(Empleado empleado)
        {
            clsEmpleado empleado_ = new clsEmpleado();

            empleado_._empleado = empleado;

            switch (empleado.Comando)
            {
                case "LlenarGrid":
                    return JsonConvert.SerializeObject(empleado_.ListarProductos());
                case "Insertar":
                    return empleado_.Insertar();
                case "Eliminar":
                    return empleado_.Eliminar();
                case "Actualizar":
                    return empleado_.Actualizar();
                default:
                    return "No se ha implementado el comando";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;
using Newtonsoft.Json;
using InmoviliariaWeb.Clases;
using System.IO;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorClientes
    /// </summary>
    public class ControladorClientes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(cliente);
            context.Response.Write(DatosRpta);
        }

        private string Procesar(Cliente cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente;
            try
            {
                switch (cliente.Comando)
                {
                    case "LlenarGrid":
                        return JsonConvert.SerializeObject(_cliente.LlenarGrid());
                    case "Insertar":
                        return _cliente.Insertar();
                    case "Eliminar":
                        return _cliente.Eliminar();
                    case "Actualizar":
                        return _cliente.Actualizar();
                      
                    default:
                        return "sin implementar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
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
using Newtonsoft.Json;
using System.Web;
using InmoviliariaWeb.Clases;

namespace InmoviliariaWeb.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorCargo
    /// </summary>
    public class ControladorCargo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar());
        }
        private string Procesar()
        {
            clsCargo cargo = new clsCargo();

            return JsonConvert.SerializeObject(cargo.LlenarCombo());
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
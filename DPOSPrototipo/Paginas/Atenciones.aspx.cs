using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPOSPrototipo.Paginas
{
    public partial class Atenciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Listar atenciones vía HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string usuarioJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<SHMC_ATEN> atencionesObtenidas = js.Deserialize<List<SHMC_ATEN>>(usuarioJson);


            Session["atencionesObtenidas"] = atencionesObtenidas;
            gvAtenciones.DataSource = atencionesObtenidas;
            gvAtenciones.DataBind();
        }
    }
}
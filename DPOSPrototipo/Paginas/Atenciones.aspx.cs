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
            List<SHMC_ATEN> atencionesObtenidas = new List<SHMC_ATEN>();

            SHMC_USUA usuarioEncontrado = (SHMC_USUA)Session["usuarioEncontrado"];

            if (usuarioEncontrado != null)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones?COD_TECN=" + usuarioEncontrado.COD_TECN);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string atencionJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                atencionesObtenidas = js.Deserialize<List<SHMC_ATEN>>(atencionJson);
            }

            gvAtenciones.DataSource = atencionesObtenidas;
            gvAtenciones.DataBind();
        }
    }
}
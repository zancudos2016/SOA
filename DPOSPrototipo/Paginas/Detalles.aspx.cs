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
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener atención vía HTTP GET
            SHMC_ATEN atencionObtenida = new SHMC_ATEN();
            string COD_ATEN = Request.QueryString["COD_ATEN"];

            if (COD_ATEN != null)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones/" + COD_ATEN);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                atencionObtenida = js.Deserialize<SHMC_ATEN>(usuarioJson);
            }

            lblAtencion.Text = atencionObtenida.COD_ATEN.ToString();
            lblAtencionRep.Text = atencionObtenida.COD_ATEN.ToString();
            lblComercio.Text = atencionObtenida.ALF_COME;
        }
    }
}
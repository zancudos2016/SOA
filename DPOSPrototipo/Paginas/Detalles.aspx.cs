﻿using Entidades;
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
            if ( !Page.IsPostBack )
            {
                //Obtener atención vía HTTP GET
                SHMC_ATEN atencionObtenida = null;
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

                if (atencionObtenida != null)
                {
                    lblAtencion.Text = atencionObtenida.COD_ATEN.ToString();
                    lblComercio.Text = atencionObtenida.ALF_PTOA;
                    lblComentario.Text = atencionObtenida.ALF_COME;
                    lblFechaProgramada.Text = atencionObtenida.FEC_PROG;
                    lblTipoAtencion.Text = atencionObtenida.TIPO;
                    lblEstadoAtencion.Text = atencionObtenida.ESTADO;

                    Session["atencionObtenida"] = atencionObtenida;
                }
            }
        }

        protected void btnOpcion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opcion.aspx");
        }
    }
}
﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPOSPrototipo.Paginas
{
    public partial class DetenerAtencionFacilidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SHMC_ATEN atencionObtenida = (SHMC_ATEN)Session["atencionObtenida"];

                if (atencionObtenida != null)
                {
                    lblAtencion.Text = atencionObtenida.COD_ATEN.ToString();
                }

                FacilidadesWS.FacilidadesClient proxy = new FacilidadesWS.FacilidadesClient();
                List<SHMC_FACI> facilidadesEncontradas = proxy.ListarFacilidades();

                chklFacilidades.DataSource = facilidadesEncontradas;
                chklFacilidades.DataValueField = "COD_FACI";
                chklFacilidades.DataTextField = "ALF_FACI";
                chklFacilidades.DataBind();
            }
        }
    }
}
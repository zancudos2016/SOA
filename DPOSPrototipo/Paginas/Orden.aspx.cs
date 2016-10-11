using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPOSPrototipo.Paginas
{
    public partial class Orden : System.Web.UI.Page
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
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SHMC_ATEN atencionObtenida = (SHMC_ATEN)Session["atencionObtenida"];

            //Se graban las facilidades relacionadas a la atención - SOA
            FacilidadesWS.FacilidadesClient proxyFaci = new FacilidadesWS.FacilidadesClient();
            SHMD_ATEN_REPO_FACI atenRepoFaci;

            CheckBoxList chklFacilidades = (CheckBoxList)Session["chklFacilidades"];
            foreach (ListItem item in chklFacilidades.Items)
            {
                atenRepoFaci = new SHMD_ATEN_REPO_FACI();

                atenRepoFaci.COD_ATEN = (int)atencionObtenida.COD_ATEN;
                atenRepoFaci.COD_FACI = Convert.ToInt32(item.Value);
                atenRepoFaci.IND_MARC = item.Selected;

                proxyFaci.RegistrarAtencionFacilidad(atenRepoFaci);
            }

            //Se graba el reporte, relacionandolo con la atención - SOA
            ReportesWS.ReportesClient proxyRepo = new ReportesWS.ReportesClient();
            SHMD_ATEN_REPO atenRepo = new SHMD_ATEN_REPO();

            atenRepo.COD_ATEN = (int)atencionObtenida.COD_ATEN;
            atenRepo.ALF_COME = txtComentario.Text;

            int reporteGrabado = proxyRepo.RegistarReporte(atenRepo);

            if (reporteGrabado == -1)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('Ocurrio un error inesperado');", true);
            else
                Response.Redirect("Atenciones.aspx");
        }
    }
}
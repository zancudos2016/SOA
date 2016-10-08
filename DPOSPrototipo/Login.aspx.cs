using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using Entidades;

namespace DPOSPrototipo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            try
            {
                SHMC_USUA usuarioEncontrado = proxy.LoginUsuario(new SHMC_USUA()
                {
                    COD_USUA = Request.Form["username"],
                    ALF_PASS = Request.Form["password"]
                });

                Session["usuarioEncontrado"] = usuarioEncontrado;

                Response.Redirect("Principal.aspx");
            }
            catch (FaultException<UsuariosWS.GeneralException> error)
            {
                lblMensaje.Text = error.Reason.ToString() + " - " + error.Detail.Codigo + " " + error.Detail.Descripcion;
            }
        }
    }
}
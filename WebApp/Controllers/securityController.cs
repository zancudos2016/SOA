using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessRules;
using System.Web;

namespace WebDemo.Controllers
{
    public class securityController : ApiController
    {
        [HttpPost]
        [Route("WASECURITYG0001_USUA")]
        public BESNMC_USUA Get_AP0001SNPR_LOGI_LIST(BESNMC_USUA oBe)
        {
            var oBr = new BRSNMC_USUA();

            var oList = oBr.Get_AP0001SNPR_LOGI_LIST(oBe);

            if (oList.Count > 0)
            {
                var session = HttpContext.Current.Session;
                session["COD_USUA"] = oBe.COD_USUA;
                oBe.ALF_URLL = "App/Main/main.html";
                oBe.IND_ERRO = false;
                oBe.ALF_ERRO = "";
            }
            else
            {
                oBe.IND_ERRO = true;
                oBe.ALF_ERRO = "Datos de acceso incorrectos";
            }
            return oBe;
        }
        [HttpPost]
        [Route("WASECURITYG0002_SESI")]
        public BESNMC_USUA Get_SESI(BESNMC_USUA oBe)
        {
            if (HttpContext.Current.Session["COD_USUA"] == null)
                return new BESNMC_USUA {ALF_URLL = "../../index.html",IND_ERRO=true,ALF_ERRO="Sesión no iniciada." };

            oBe.IND_ERRO = false;
            oBe.ALF_ERRO = "";
            return oBe;
        }
    }
}

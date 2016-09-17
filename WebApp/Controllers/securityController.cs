﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using LogicaNegocio;
using System.Web;

namespace WebApp.Controllers
{
    public class securityController : ApiController
    {
        [HttpPost]
        [Route("WAP0001_USUA")]
        public SHMC_USUA Get_P0001_USUA_LIST(SHMC_USUA oBe)
        {
            var oBr = new LNSHMC_USUA();

            var oList = oBr.Get_P0001_USUA_LIST(oBe);

            if (oList.Count > 0)
            {
                var session = HttpContext.Current.Session;
                session["COD_USUA"] = oBe.COD_USUA;
                oBe.ALF_URLL = "Views/Main/main.html";
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
    }
}

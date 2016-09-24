using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WcfServices;

namespace WebApp.Controllers
{
    public class atencionesController : ApiController
    {
        [HttpPost]
        [Route("WA0001_ATEN")]
        public SHMC_ATEN Get_ATEN_LIST(SHMC_ATEN oBe)
        {
            if (HttpContext.Current.Session["COD_USUA"] == null)
                return new SHMC_ATEN();

            try
            {
                var sAtenciones = new Atenciones();
                //oBe.LST_ATEN = sAtenciones.ListarAtenciones();
                oBe.IND_ERRO = false;
                oBe.ALF_ERRO = "";
                return oBe;
            }
            catch (Exception ex)
            {
                oBe.IND_ERRO = true;
                oBe.ALF_ERRO = ex.Message;
                return oBe;
            }
        }

        [HttpPost]
        [Route("WA0002_ATEN")]
        public SHMC_ATEN Set_ATEN_SAVE(SHMC_ATEN oBe)
        {
            if (HttpContext.Current.Session["COD_USUA"] == null)
                return new SHMC_ATEN();

            try
            {
                var sAtenciones = new Atenciones();
                //oBe = sAtenciones.CrearAtencion(oBe);
                oBe.IND_ERRO = false;
                oBe.ALF_ERRO = "";
                return oBe;
            }
            catch (Exception ex)
            {
                oBe.IND_ERRO = true;
                oBe.ALF_ERRO = ex.Message;
                return oBe;
            }
        }
    }
}

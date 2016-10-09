using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

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
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string atencionJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                var oList = js.Deserialize<List<SHMC_ATEN>>(atencionJson);
                oBe.LST_ATEN = oList;
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
                var json = new JavaScriptSerializer().Serialize(oBe);
                byte[] data = Encoding.UTF8.GetBytes(json);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = null;
                try
                {
                    res = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    string atencionesJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    oBe = js.Deserialize<SHMC_ATEN>(atencionesJson);
                }
                catch (WebException e)
                {
                    HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                    string message = ((HttpWebResponse)e.Response).StatusDescription;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    string error = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string mensaje = js.Deserialize<string>(error);

                    throw new ArgumentException("(" + message + ") " + mensaje);
                }

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
        [Route("WA0003_ATEN")]
        public SHMC_ATEN Set_ATEN_EDIT(SHMC_ATEN oBe)
        {
            if (HttpContext.Current.Session["COD_USUA"] == null)
                return new SHMC_ATEN();

            try
            {
                var json = new JavaScriptSerializer().Serialize(oBe);
                byte[] data = Encoding.UTF8.GetBytes(json);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = null;
                try
                {
                    res = res = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    string atencionesJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    oBe = js.Deserialize<SHMC_ATEN>(atencionesJson);
                }
                catch (WebException e)
                {
                    HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                    string message = ((HttpWebResponse)e.Response).StatusDescription;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    string error = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string mensaje = js.Deserialize<string>(error);

                    throw new ArgumentException("(" + message + ") " + mensaje);
                }

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
        [Route("WA0004_ATEN")]
        public List<SHMC_EMPL> Set_ATEN_TECN(SHMC_ATEN oBe)
        {
            if (HttpContext.Current.Session["COD_USUA"] == null)
                return new List<SHMC_EMPL>();

            ServiceTecnicos.TecnicosClient proxy = new ServiceTecnicos.TecnicosClient();
            List<SHMC_EMPL> oList = proxy.ListarTecnicos().ToList<SHMC_EMPL>();

            return oList;
        }
    }
}

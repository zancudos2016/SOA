using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace TestServices
{
    [TestClass]
    public class RestTestAtenciones
    {
        [TestMethod]
        public void CrearAtencionOK()
        {
            string postdata = "{\"COD_ATEN\":\"5555\",\"COD_TIPO\":\"1\",\"FEC_ATEN\":\"2016-10-11\",\"ALF_COME\":\"1\",\"COD_ESTA\":\"1\",\"ALF_PTOA\":\"1\"}"; //JSON            
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string atencionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Atencion atencionCreada = js.Deserialize<Atencion>(atencionJson);
            Assert.AreEqual("5555", atencionCreada.COD_ATEN);
            Assert.AreEqual("1", atencionCreada.COD_TIPO);
            Assert.AreEqual("11/10/2016", atencionCreada.FEC_ATEN);
            Assert.AreEqual("1", atencionCreada.ALF_COME);
            Assert.AreEqual("1", atencionCreada.COD_ESTA);
            Assert.AreEqual("1", atencionCreada.ALF_PTOA);
        }

        [TestMethod]
        public void ModificarAtencionOK()
        {
            string postdata = "{\"COD_ATEN\":\"5555\",\"COD_TIPO\":\"1\",\"FEC_ATEN\":\"2016-10-11\",\"ALF_COME\":\"2\",\"COD_ESTA\":\"1\",\"ALF_PTOA\":\"1\"}"; //JSON            
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string atencionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Atencion atencionModificada = js.Deserialize<Atencion>(atencionJson);
            Assert.AreEqual("5555", atencionModificada.COD_ATEN);
            Assert.AreEqual("1", atencionModificada.COD_TIPO);
            Assert.AreEqual("11/10/2016", atencionModificada.FEC_ATEN);
            Assert.AreEqual("2", atencionModificada.ALF_COME);
            Assert.AreEqual("1", atencionModificada.COD_ESTA);
            Assert.AreEqual("1", atencionModificada.ALF_PTOA);
        }

        [TestMethod]
        public void EliminarAtencion()
        {
            //Prueba de eliminación de usuario vía HTTP DELETE
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones/5555");
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string atencionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            //Prueba de eliminación de atención vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones/5555");
            req2.Method = "GET";
            HttpWebResponse res2 = null;
            try
            {
                res = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string atencionJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Atencion atencionObtenida = js2.Deserialize<Atencion>(atencionJson2);
                Assert.AreEqual(null, atencionObtenida);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader2 = new StreamReader(e.Response.GetResponseStream());
                string error = reader2.ReadToEnd();
                JavaScriptSerializer js3 = new JavaScriptSerializer();
                string mensaje = js3.Deserialize<string>(error);
                Assert.AreEqual("La atención no existe", mensaje);
            }
        }
    }
}

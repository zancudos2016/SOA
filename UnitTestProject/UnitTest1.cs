using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using Entidades;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearAtencion()
        {
            AtencionesWS.AtencionesClient proxy = new AtencionesWS.AtencionesClient();
            AtencionesWS.SHMC_ATEN atencionCreada = proxy.CrearAtencion(new AtencionesWS.SHMC_ATEN()
            {
                COD_ATEN = 2222,
                COD_PUNT_ATEN = 1,
                COD_TIPO = 1,
                FEC_ATEN = "2016-09-01",
                ALF_COME = "ABC",
                FEC_PROG = "2016-09-05",
                COD_TECN = 1,
                COD_ESTA = 1,
                ALF_PTOA = ""
            });
            Assert.AreEqual(2222, atencionCreada.COD_ATEN);
            Assert.AreEqual(1, atencionCreada.COD_PUNT_ATEN);
            Assert.AreEqual(DateTime.Parse("2016-09-01".ToString()), atencionCreada.FEC_ATEN);
            Assert.AreEqual("ABC", atencionCreada.ALF_COME);
            Assert.AreEqual(DateTime.Parse("2016-09-05".ToString()), atencionCreada.FEC_PROG);
            Assert.AreEqual(1, atencionCreada.COD_TECN);
            Assert.AreEqual(1, atencionCreada.COD_ESTA);
        }

        [TestMethod]
        public void ListarAtenciones()
        {
            //Listar atenciones vía HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:25097/Atenciones.svc/Atenciones");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string usuarioJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<SHMC_ATEN> atencionesObtenidas = js.Deserialize<List<SHMC_ATEN>>(usuarioJson);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                COD_ATEN = 2,
                COD_PUNT_ATEN = 1,
                COD_TIPO = 2,
                FEC_ATEN = DateTime.Parse("2016-09-01".ToString()),
                ALF_COME = "ABC",
                FEC_PROG = DateTime.Parse("2016-09-05".ToString()),
                COD_TECN = 1,
                COD_ESTA = 3
            });
            Assert.AreEqual(2, atencionCreada.COD_ATEN);
            Assert.AreEqual(1, atencionCreada.COD_PUNT_ATEN);
            Assert.AreEqual(DateTime.Parse("2016-09-01".ToString()), atencionCreada.FEC_ATEN);
            Assert.AreEqual("ABC", atencionCreada.ALF_COME);
            Assert.AreEqual(DateTime.Parse("2016-09-05".ToString()), atencionCreada.FEC_PROG);
            Assert.AreEqual(2, atencionCreada.COD_TECN);
            Assert.AreEqual(3, atencionCreada.COD_ESTA);
        }
    }
}

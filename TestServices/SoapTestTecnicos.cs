using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestServices
{
    [TestClass]
    public class SoapTestTecnicos
    {
        [TestMethod]
        public void TestListarTecnicosOK()
        {
            WCFTecnicos.TecnicosClient proxy = new WCFTecnicos.TecnicosClient();
            WCFTecnicos.SHMC_EMPL[] tecnicosEncontrados = proxy.ListarTecnicos();

            Assert.AreEqual(1, tecnicosEncontrados[0].COD_TECN);
            Assert.AreEqual("Ivan Velarde", tecnicosEncontrados[0].ALF_EMPL);
        }
    }
}

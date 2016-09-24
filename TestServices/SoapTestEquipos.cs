using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestServices
{
    [TestClass]
    public class SoapTestEquipos
    {
        [TestMethod]
        public void TestObtenerEquipoOK()
        {
            WCFEquipos.EquiposClient proxy = new WCFEquipos.EquiposClient();
            WCFEquipos.SHMC_EQUI obtenerEquipo = proxy.ObtenerEquipo(1);

            Assert.AreEqual("abc", obtenerEquipo.ALF_SERI);
            Assert.AreEqual(1, obtenerEquipo.COD_ESTA);
            Assert.AreEqual(1, obtenerEquipo.COD_TIPO_UBIC);
            Assert.AreEqual(1, obtenerEquipo.COD_ALMA);
            Assert.AreEqual(1, obtenerEquipo.COD_TECN);
            Assert.AreEqual(1, obtenerEquipo.COD_PUNT_ATEN);
        }
        [TestMethod]
        public void TestModificarEquipoOK()
        {

        }
    }
}
